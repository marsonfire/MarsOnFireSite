import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})

export class GamesService {
  private http = inject(HttpClient);

  getGames(){
    return this.http.get(`${environment.apiUrl}/games`);
  }
}
