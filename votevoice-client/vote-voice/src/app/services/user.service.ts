import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getUser(userId: number) {
    return this.httpClient.get<any>(`${environment.apiUrl}user/${userId}`);
  }

  getUserId():string | null {
    return localStorage.getItem('vote-voice-user-id');
  }
}
