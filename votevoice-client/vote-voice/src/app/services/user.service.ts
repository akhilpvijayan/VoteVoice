import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
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

  getCountries() {
    return this.httpClient.get<any>(`${environment.apiUrl}user/country`);
  }

  getStates(countryId: number) {
    return this.httpClient.get<any>(`${environment.apiUrl}user/state/${countryId}`);
  }

  addUser(data: FormData) {
    return this.httpClient.post<any>(`${environment.apiUrl}user`, data);
  }

  updateUser(data: FormData, userId: number) {
    return this.httpClient.put<any>(`${environment.apiUrl}user/${userId}`, data);
  }

  isUsernameExists(username: string) {
    return this.httpClient.get<boolean>(`${environment.apiUrl}user/duplicate/username/${username}`);
  }

  isEmailExists(email: string) {
    return this.httpClient.get<boolean>(`${environment.apiUrl}user/duplicate/email/${email}`);
  }

  // Custom validator function to check if username already exists
  userNameExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.isUsernameExists(control.value).subscribe((res: boolean) => {
          resolve(res ? { userNameExists: true } : false);
        });
      }
    });
  }

  emailExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.isEmailExists(control.value).subscribe((res: boolean) => {
          resolve(res ? { emailExists: true } : false);
        });
      }
    });
  }
}
