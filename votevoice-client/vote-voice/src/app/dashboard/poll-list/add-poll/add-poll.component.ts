import { DarkModeService } from './../../../services/dark-mode.service';
import { UserService } from './../../../services/user.service';
import { AuthService } from './../../../Auth/auth.service';
import { AddPollModalComponent } from './add-poll-modal/add-poll-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, Input, OnInit } from '@angular/core';
import { LoginComponent } from 'src/app/login/login.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-poll',
  templateUrl: './add-poll.component.html',
  styleUrls: ['./add-poll.component.scss']
})
export class AddPollComponent implements OnInit{
  @Input() isFromProfile: boolean = false;
  isLoggedIn = false;
  isLoggedInUser = false;
  isDarkMode = this.darkModeService.isDarkModeEnabled();

constructor(private dialog: MatDialog,
  private authService: AuthService,
  private userservice: UserService,
  private route: ActivatedRoute,
  private darkModeService: DarkModeService){}

  ngOnInit(): void {
    this.route?.queryParams?.subscribe(params => {
      this.isLoggedInUser = params['userId'] === this.userservice.getUserId() ? true : false;
    });
    this.authService.isLoggedInObservable$.subscribe((isLoggedIn: any) => {
      this.isLoggedIn = isLoggedIn;
    });
    this.isLoggedIn = this.authService.isLoggedIn();
    this.subscribeDarkMode();
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

subscribeDarkMode(){
  this.darkModeService.darkMode$.subscribe((isDarkMode) => {
    this.isDarkMode = isDarkMode;
  });
}
}
