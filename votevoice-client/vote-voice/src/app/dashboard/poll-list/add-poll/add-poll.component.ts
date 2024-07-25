import { AuthService } from './../../../Auth/auth.service';
import { AddPollModalComponent } from './add-poll-modal/add-poll-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { LoginComponent } from 'src/app/login/login.component';

@Component({
  selector: 'app-add-poll',
  templateUrl: './add-poll.component.html',
  styleUrls: ['./add-poll.component.scss']
})
export class AddPollComponent implements OnInit{
  isLoggedIn = false;

constructor(private dialog: MatDialog,
  private authService: AuthService){}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.authService.isLoggedInObservable$.subscribe((isLoggedIn: any) => {
      this.isLoggedIn = isLoggedIn;
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
}
