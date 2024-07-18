import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getUserId():string | null {
    return localStorage.getItem('vote-voice-user-id');
  }
}
