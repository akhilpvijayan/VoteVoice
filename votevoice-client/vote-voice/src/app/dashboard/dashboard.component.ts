import { AuthService } from './../Auth/auth.service';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit{
  activeTabIndex = 0;
  isLoggedIn = false;
  isAssistantOpen = false;

  constructor(
    private authService: AuthService
  ){}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  onTabChange(event: MatTabChangeEvent) {
    this.activeTabIndex = event.index;
  }

  openChat() {
    this.isAssistantOpen = !this.isAssistantOpen;
  }
}
