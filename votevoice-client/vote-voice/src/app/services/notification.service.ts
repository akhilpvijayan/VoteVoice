import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Notifications } from '../interfaces/notifications';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  
  constructor(
    private httpClient: HttpClient) { }

  getNotifications(userId: number, skip: number, take: number) {
    return this.httpClient.get<Notifications>(`${environment.apiUrl}notification/${userId}?skip=${skip}&take=${take}`);
  }

  getNotificationsForPreview(userId: number) {
    return this.httpClient.get<Notifications>(`${environment.apiUrl}notification/preview/${userId}`);
  }
}
