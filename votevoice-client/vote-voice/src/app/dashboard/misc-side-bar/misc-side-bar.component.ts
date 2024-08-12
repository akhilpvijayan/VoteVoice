import { DarkModeService } from './../../services/dark-mode.service';
import { MiscService } from './../../services/misc.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-misc-side-bar',
  templateUrl: './misc-side-bar.component.html',
  styleUrls: ['./misc-side-bar.component.scss']
})
export class MiscSideBarComponent implements OnInit{
advice!: string;
isDarkMode = this.darkModeService.isDarkModeEnabled();

  constructor(private miscService: MiscService,
    private darkModeService: DarkModeService){}

  ngOnInit(): void {
    this.miscService.getAdvice().subscribe((res: any)=>{
      this.advice = res.slip.advice;
    });
    this.darkModeService.darkMode$.subscribe((isDarkMode) => {
      this.isDarkMode = isDarkMode;
    });
  }

}
