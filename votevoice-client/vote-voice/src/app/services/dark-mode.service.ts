import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DarkModeService {
  private isDarkMode = false;

  darkModeSignal = signal<string>('null');
  constructor() {
    // this.isDarkMode = localStorage.getItem('dark-mode') === 'true';
    // this.updateBodyClass();
  }

  updateDarkMode(){
    this.darkModeSignal.update((value)=> (value === 'dark' ? 'null' : 'dark'));
  }

  toggleDarkMode() {
    this.isDarkMode = !this.isDarkMode;
    localStorage.setItem('dark-mode', this.isDarkMode.toString());
    this.updateBodyClass();
  }

  private updateBodyClass() {
    if (this.isDarkMode) {
      document.body.classList.add('dark');
      console.log('Dark mode enabled');
    } else {
      document.body.classList.remove('dark');
      console.log('Dark mode disabled');
    }
  }

  isDarkModeEnabled(): boolean {
    return this.isDarkMode;
  }
}
