import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../Auth/auth.service';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Location } from '@angular/common';


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

  constructor(private userService: UserService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router){}
  ngOnInit(): void {
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
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  onTabChange(event: MatTabChangeEvent) {
    this.activeTabIndex = event.index;
  }

  getUserDetails(userId: number){
    this.userService.getUser(userId).subscribe((res: any)=>{
      this.userDetails = res[0];
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
