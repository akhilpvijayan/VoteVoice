import { DarkModeService } from './services/dark-mode.service';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'vote-voice';

  darkModeService: DarkModeService = Inject(DarkModeService);
}
