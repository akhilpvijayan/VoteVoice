import { AddPollModalComponent } from './add-poll-modal/add-poll-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { Component } from '@angular/core';

@Component({
  selector: 'app-add-poll',
  templateUrl: './add-poll.component.html',
  styleUrls: ['./add-poll.component.scss']
})
export class AddPollComponent {
constructor(private dialog: MatDialog){}

addPoll(){
  this.dialog.open(AddPollModalComponent,{
    width:'70%',
    height:'95%',
    hasBackdrop: true,
    panelClass: 'custom-dialog-container',
    enterAnimationDuration: '300ms',
    exitAnimationDuration: '300ms',
  });
}
}
