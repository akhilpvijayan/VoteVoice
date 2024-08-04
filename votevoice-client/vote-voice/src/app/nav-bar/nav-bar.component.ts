import { SignalrService } from './../services/signalr.service';
import { UserService } from './../services/user.service';
import { LoginComponent } from './../login/login.component';
import { AuthService } from './../Auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { DarkModeService } from '../services/dark-mode.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationPopupModalComponent } from '../shared/confirmation-popup-modal/confirmation-popup-modal.component';
import { AddPollModalComponent } from '../dashboard/poll-list/add-poll/add-poll-modal/add-poll-modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  isOpen = false;
  isLoggedIn = false;
  userDetails: any;
  notifications: { message: string, timestamp: Date }[] = [];
  userId =parseInt(this.userService.getUserId() ?? '0', 10)

  constructor(public darkModeService: DarkModeService,
    private authService: AuthService,
    private dialog: MatDialog,
    private router: Router,
    private userService: UserService,
    private signalRService: SignalrService) {}

  ngOnInit(): void {
    this.notifications = [
      { message: 'New comment on your post', timestamp: new Date() },
      { message: 'You have a new follower', timestamp: new Date() },
      { message: 'Server maintenance scheduled for tonight', timestamp: new Date() }
    ];
    this.signalRService.startConnection();
    this.signalRService.addReceiveNotificationListener((targetUser: number, message: string) => {
      if(this.userId == targetUser){
        console.log(message);
      }
    });  
    this.authService.isLoggedInObservable$.subscribe((isLoggedInSubject: any) => {
      this.isLoggedIn = isLoggedInSubject;
      setTimeout(() => {
        this.userId = parseInt(this.userService.getUserId() ?? '0', 10)
        this.getUserDetails();
      }, 100);
    });
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getUserDetails();
  }

  getUserDetails(){
    this.userService.getUser(this.userId).subscribe((res: any)=>{
      this.userDetails = res;
    })
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

  addPoll(){
    if(this.isLoggedIn){
      this.dialog.open(AddPollModalComponent,{
        width:'70%',
        height:'auto',
        hasBackdrop: true,
        panelClass: 'custom-dialog-container',
        enterAnimationDuration: '300ms',
        exitAnimationDuration: '300ms',
      });
    }
    else{
      this.dialog.open(LoginComponent,{
        width:'70%',
        height:'auto',
        hasBackdrop: true,
        panelClass: 'custom-dialog-container',
        enterAnimationDuration: '300ms',
        exitAnimationDuration: '300ms',
      });
    }
  }

  showProfile() {
    this.router.navigate(['profile'], { queryParams: { userId: this.userService.getUserId() } });
  }

  signOut(){
    const dialogRef = this.dialog.open(ConfirmationPopupModalComponent, {
      width: 'auto',
      height: 'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      data: {
        message: 'Are you sure want to LogOut?.'
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.authService.signOut();
      }
    });
  }

  goToDashboard(){
    this.router.navigateByUrl('');
  }
}
