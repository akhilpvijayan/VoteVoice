import { NotificationService } from './../services/notification.service';
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
import { Notifications } from '../interfaces/notifications';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  isLoggedIn = false;
  userDetails: any;
  isDarkMode = this.darkModeService.isDarkModeEnabled();
  showNotification = false;
  isAssistantOpen = false;
  unReadCount = 0;
  notifications: Notifications[] = [];
  userId =parseInt(this.userService.getUserId() ?? '0', 10)

  constructor(public darkModeService: DarkModeService,
    private authService: AuthService,
    private dialog: MatDialog,
    private router: Router,
    private userService: UserService,
    private signalRService: SignalrService,
    private notificationService: NotificationService) {}

  ngOnInit(): void {
    this.subscribeSignalR();  
    this.subscribeAuth()
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getUserDetails();
    if(this.isLoggedIn){
      this.getNotifications();
    }
    this.darkModeService.darkMode$.subscribe((isDarkMode) => {
      this.isDarkMode = isDarkMode;
    });
  }

  subscribeSignalR(){
    this.signalRService.startConnection();
    this.signalRService.addReceiveNotificationListener((notification: Notifications) => {
      if(this.userId == notification.targetUserId){
        if(this.notifications?.length === 3){
          this.notifications.splice(2, 1); // Remove the third notification
          this.notifications.unshift(notification); // Add the new notification as the first element
        } else {
          this.notifications.unshift(notification);
        }
      }
    });
  }

  //subscribe for logged in or logged out changes
  subscribeAuth(){
    this.authService.isLoggedInObservable$.subscribe((isLoggedInSubject: any) => {
      this.isLoggedIn = isLoggedInSubject;
      setTimeout(() => {
        this.userId = parseInt(this.userService.getUserId() ?? '0', 10)
        this.getUserDetails();
        this.getNotifications();
      }, 100);
    });
  }

  getUserDetails(){
    this.userService.getUser(this.userId).subscribe((res: any)=>{
      this.userDetails = res;
    })
  }

  //get notifications for preview
  getNotifications(){
    this.notificationService.getNotificationsForPreview(this.userId).subscribe((res: any)=>{
      if(res[0]){
        this.notifications.push(res);
        this.unReadCount = this.notifications?.filter(x => x.isRead).length;
      }
    })
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

  openChat() {
    this.isAssistantOpen = !this.isAssistantOpen;
    this.showNotification = false;
  }

  showNotificationBar(){
    this.showNotification = !this.showNotification;
    this.isAssistantOpen = false;
  }

  toggleDarkMode() {
    this.darkModeService.toggleDarkMode();
  }
}
