import { AuthService } from './../Auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { DarkModeService } from '../services/dark-mode.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  isOpen = false;
  isLoggedIn = false;

  constructor(public darkModeService: DarkModeService,
    private authService: AuthService) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  toggleDarkMode() {
    this.darkModeService.updateDarkMode();
  }

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  search(){
    console.log('Search works');
  }

  signOut(){
    this.authService.signOut();
  }
}
