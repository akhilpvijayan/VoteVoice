import { Poll } from './../interfaces/poll';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PollService {

  constructor(
    private httpClient: HttpClient) { }

    getAllPolls(skip: number, take: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}poll?skip=${skip}&take=${take}`);
    }

  addPoll(data: FormData){
    return this.httpClient.post<any>(`${environment.apiUrl}poll`, data);
  }
}
