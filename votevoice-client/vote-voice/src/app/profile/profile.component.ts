import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../Auth/auth.service';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Location } from '@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';
import { DarkModeService } from '../services/dark-mode.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit{
  activeTabIndex = 0;
  userDetails: any;
  isLoggedIn = false;
  userId: any = null;
  isDarkMode = this.darkModeService.isDarkModeEnabled();

  constructor(private userService: UserService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router,
    private spinner: NgxSpinnerService,
    public darkModeService: DarkModeService){}
  ngOnInit(): void {
    this.spinner.show();
    this.route.queryParams.subscribe(params => {
      this.userId = params['userId'];
      this.getUserDetails(this.userId);
    });
    this.authService.isLoggedInObservable$.subscribe((isLoggedInObservable: any) => {
      this.isLoggedIn = isLoggedInObservable;
      setTimeout(() => {
        this.getUserDetails(this.userId);
      }, 100);
    });
    this.subscribeDarkMode();
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  subscribeDarkMode(){
    this.darkModeService.darkMode$.subscribe((isDarkMode) => {
      this.isDarkMode = isDarkMode;
    });
  }

  onTabChange(event: MatTabChangeEvent) {
    this.activeTabIndex = event.index;
  }

  getUserDetails(userId: number){
    this.userService.getUser(userId).subscribe((res: any)=>{
      this.userDetails = res;
      this.spinner.hide();
    });
  }

  goBack(): void {
    if (window.history.length > 1) {
      this.location.back();
    } else {
      this.router.navigateByUrl('');
    }
  }
}
