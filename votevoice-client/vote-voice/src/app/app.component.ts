import { DarkModeService } from './services/dark-mode.service';
import { Component, Inject, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  title = 'vote-voice';

  darkModeService: DarkModeService = Inject(DarkModeService);
}
