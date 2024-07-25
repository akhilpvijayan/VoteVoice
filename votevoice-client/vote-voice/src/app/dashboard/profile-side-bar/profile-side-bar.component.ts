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
    private dialog: MatDialog
  ){}

  ngOnInit(): void {
    this.getUserDetails();
    this.authService.isLoggedInObservable$.subscribe((isLoggedInObservable: any) => {
      this.isLoggedIn = isLoggedInObservable;
      this.getUserDetails();
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
      height:'95%',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
    });
  }
}
