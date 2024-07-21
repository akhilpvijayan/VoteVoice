import { AuthService } from './../../Auth/auth.service';
import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile-side-bar',
  templateUrl: './profile-side-bar.component.html',
  styleUrls: ['./profile-side-bar.component.scss']
})
export class ProfileSideBarComponent implements OnInit{
  userDetails: any;
  userId = parseInt(this.userService.getUserId() ?? '0', 10);
  isLoggedIn = this.authService.isLoggedIn();

  constructor(
    private userService: UserService,
    private authService: AuthService
  ){}

  ngOnInit(): void {
    this.getUserDetails();
  }

  getUserDetails(){
    if(this.isLoggedIn){
      this.userService.getUser(this.userId).subscribe((res: any)=>{
        this.userDetails = res[0];
      });
    }
  }
}
