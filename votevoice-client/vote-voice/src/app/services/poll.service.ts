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

  getPoll(pollId: number) {
    return this.httpClient.get<any>(`${environment.apiUrl}poll/${pollId}`);
  }

  getPollsByUser(skip: number, take: number, userId: number) {
    return this.httpClient.get<any>(`${environment.apiUrl}poll/user/${userId}?skip=${skip}&take=${take}`);
  }

  addPoll(data: FormData) {
    return this.httpClient.post<any>(`${environment.apiUrl}poll`, data);
  }

  updatePoll(data: FormData, pollId: number) {
    return this.httpClient.put<any>(`${environment.apiUrl}poll/${pollId}`, data);
  }

  deletePoll(pollId: number) {
    return this.httpClient.delete<any>(`${environment.apiUrl}poll/${pollId}`);
  }
}
