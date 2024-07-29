import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from './../../Auth/auth.service';
import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { LoginComponent } from 'src/app/login/login.component';

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
    private authService: AuthService,
    private dialog: MatDialog,
    private router: Router
  ){}

  ngOnInit(): void {
    this.getUserDetails();
    this.authService.isLoggedInObservable$.subscribe((isLoggedInObservable: any) => {
      this.isLoggedIn = isLoggedInObservable;
      setTimeout(() => {
        this.userId = parseInt(this.userService.getUserId() ?? '0', 10)
        this.getUserDetails();
      }, 100);
    });
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  getUserDetails(){
    if(this.isLoggedIn){
      this.userService.getUser(this.userId).subscribe((res: any)=>{
        this.userDetails = res[0];
      });
    }
  }

  login(){
    this.dialog.open(LoginComponent,{
      width:'70%',
      height:'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
    });
  }

  showProfile() {
    this.router.navigate(['profile'], { queryParams: { userId: this.userService.getUserId() } });
  }
}
