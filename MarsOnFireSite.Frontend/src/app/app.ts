import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { GamesService } from './services/games.service';
import { catchError, finalize, of } from 'rxjs';

//setup the Game object for our table
interface Game {
  steamAppId: string
  name: string;
  shortDescription: string;
  releaseDate: string;
  price: string
  link: string;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatTableModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit{

  //setup signals and variables 
  isLoading = signal<boolean>(true);
  error = signal<string | null>(null);
  myGames = signal<Game[]>([]);

  //these are the columns we'll use for mat-table
  columnsToDisplay = ['steamAppId', 'name', 'shortDescription', 'releaseDate', "price", 'link'];

  //We will call the GamesService which will be used to actually make the API call to the backend
  private gamesService = inject(GamesService)
  
  //init - as soon as the app starts, this is called
  ngOnInit(){
    //error occurs because we call the Steam API in the backend, but nothing is ready yet, so it fails. Use a Loading signal to not get a debugging error
    //Then, we can display the table and game data when its ready
    this.isLoading.set(true);

    //If it doesn't work, we'll display an error, otherwise, set our game data and make sure we're not loading anymore
    this.gamesService.getGames().pipe(
      catchError(e => {
        this.error.set("Failed to get games!");
        return of ([]);
    }),
    finalize(() => 
      this.isLoading.set(false)))
    .subscribe(data => {
      this.myGames.set(data as Game[]);
    });
  }
}

