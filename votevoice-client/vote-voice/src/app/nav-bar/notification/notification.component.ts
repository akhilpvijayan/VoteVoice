import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Notifications } from 'src/app/interfaces/notifications';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit{
  @Input() showNotification!: boolean;
  @Input() notifications!: Notifications[];

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  showProfile(userId: number | undefined) {
    if(userId){
      this.showNotification = false;
      this.router.navigate(['profile'], { queryParams: { userId: userId } });
    }
  }

  get notificationState() {
    return this.showNotification ? 'open' : 'closed';
  }
}
