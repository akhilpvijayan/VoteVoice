import { Notifications } from './../interfaces/notifications';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private hubConnection!: signalR.HubConnection;

  constructor() { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.signalRUrl +'notificationHub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addReceiveNotificationListener = (callback: (notification: Notifications) => void) => {
    this.hubConnection.on('ReceiveNotification', callback);
  }

  public SendNotification = (user: number, message: string) => {
    this.hubConnection.invoke('ReceiveNotification', user, message)
      .catch(err => console.error(err));
  }

  public connectionListner = (callback: (connection: any) => void) => {
    this.hubConnection.on('Connection', callback);
  }
}
