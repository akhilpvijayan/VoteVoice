import { DarkModeService } from './../services/dark-mode.service';
import { AuthService } from './../Auth/auth.service';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { ReloadService } from '../services/reload.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit{
  activeTabIndex = 0;
  isLoggedIn = false;
  isDarkMode = false;

  constructor(
    private authService: AuthService,
    private darkModeService: DarkModeService
  ){}

  ngOnInit(): void {
    this.authService.isLoggedInObservable$.subscribe((isLoggedInSubject: any) => {
      this.isLoggedIn = isLoggedInSubject;
    });
    this.darkModeService.darkMode$.subscribe((isDarkMode) => {
      this.isDarkMode = isDarkMode;
    });
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  onTabChange(event: MatTabChangeEvent) {
    this.activeTabIndex = event.index;
  }
}
