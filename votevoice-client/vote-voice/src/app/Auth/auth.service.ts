import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TokenApi } from '../interfaces/token-api';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedInObservable$: Observable<boolean> = this.isLoggedInSubject.asObservable();
  
  constructor(
    private httpClient: HttpClient,
    private router: Router) { }

  signUp(userDetails: any){
    return this.httpClient.post<any>(`${environment.apiUrl}user`, userDetails);
  }

  login(userCredentials: any){
    const headers = new HttpHeaders().set('X-Skip-Interceptor', 'true');
    return this.httpClient.post<any>(`${environment.apiUrl}login`, userCredentials,{ headers });
  }

  setToken(tokenValue: string){
    localStorage.setItem('vote-voice-token', tokenValue);
    this.isLoggedInSubject.next(true);
  }

  setUser(userId: number){
    localStorage.setItem('vote-voice-user-id', userId.toString());
  }

  getToken(){
    return localStorage.getItem('vote-voice-token');
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('vote-voice-token'); //if token returns true, else false
  }

  signOut(){
    localStorage.clear();
    this.isLoggedInSubject.next(false);
  }

  renewToken(tokenApi: TokenApi){
    const headers = new HttpHeaders().set('X-Skip-Interceptor', 'true');
    return this.httpClient.post<any>(`${environment.apiUrl}refreshtoken`, tokenApi,{ headers });
  }

  setRefreshToken(tokenValue: string){
    localStorage.setItem('vote-voice-refresh-token', tokenValue);
  }

  getRefreshToken(){
    return localStorage.getItem('vote-voice-refresh-token');
  }
}
