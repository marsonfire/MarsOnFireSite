import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { GamesService } from './services/games.service';

interface Game {
  name: string;
  description: string;
  releaseDate: string;
  link: string;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatTableModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit{
  private gamesService = inject(GamesService)
  protected myGames = signal<Game[]>([]);
  protected columnsToDisplay = ['name'];

  ngOnInit(){
    this.gamesService.getGames().subscribe(data => {
      this.myGames.set(data as Game[]);
    });
  }
}
