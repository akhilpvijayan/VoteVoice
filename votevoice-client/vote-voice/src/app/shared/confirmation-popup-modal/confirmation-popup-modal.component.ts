import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-popup-modal',
  templateUrl: './confirmation-popup-modal.component.html',
  styleUrls: ['./confirmation-popup-modal.component.scss']
})
export class ConfirmationPopupModalComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<ConfirmationPopupModalComponent>){}

  ngOnInit(): void {
    console.log(this.data.message);
  }

  closeDialog(isConfirm: boolean){
    this.dialogRef.close(isConfirm);
  }
}
