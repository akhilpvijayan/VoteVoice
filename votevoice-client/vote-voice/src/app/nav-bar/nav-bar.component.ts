import { LoginComponent } from './../login/login.component';
import { AuthService } from './../Auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { DarkModeService } from '../services/dark-mode.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationPopupModalComponent } from '../shared/confirmation-popup-modal/confirmation-popup-modal.component';
import { AddPollModalComponent } from '../dashboard/poll-list/add-poll/add-poll-modal/add-poll-modal.component';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  isOpen = false;
  isLoggedIn = false;

  constructor(public darkModeService: DarkModeService,
    private authService: AuthService,
    private dialog: MatDialog) {}

  ngOnInit(): void {
    this.authService.isLoggedInObservable$.subscribe((isLoggedInSubject: any) => {
      this.isLoggedIn = isLoggedInSubject;
    });
    this.isLoggedIn = this.authService.isLoggedIn();
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
      height:'95%',
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
        height:'95%',
        hasBackdrop: true,
        panelClass: 'custom-dialog-container',
        enterAnimationDuration: '300ms',
        exitAnimationDuration: '300ms',
      });
    }
    else{
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
}
