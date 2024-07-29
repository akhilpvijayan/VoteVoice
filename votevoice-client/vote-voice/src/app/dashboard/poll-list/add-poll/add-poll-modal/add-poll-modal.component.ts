import { PollService } from './../../../../services/poll.service';
import { PollOption } from './../../../../interfaces/poll-option';
import { UserService } from './../../../../services/user.service';
import { Component, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ReloadService } from 'src/app/services/reload.service';

@Component({
  selector: 'app-add-poll-modal',
  templateUrl: './add-poll-modal.component.html',
  styleUrls: ['./add-poll-modal.component.scss']
})
export class AddPollModalComponent {
  addPollForm!: FormGroup;
  defaultHeight: number = 300;
  selectedFile: any;
  imageUrl: string | ArrayBuffer | null = null;
  formData = new FormData();
  hideNewPollOptionButton = false;
  wordCount: number = 0;
  userId = parseInt(this.userService.getUserId() ?? '0', 10);

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<AddPollModalComponent>,
    private userService: UserService,
    private pollService: PollService,
    private reloadService: ReloadService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.initializeForm();
    if (this.data?.pollDetails?.pollOptions) {
      this.patchPollOptions(this.data.pollDetails.pollOptions);
    }
  }

  initializeForm() {
    this.addPollForm = this.formBuilder.group({
      userId: this.userService.getUserId(),
      title: [this.data?.pollDetails?.title ?? '', [Validators.required, Validators.maxLength(100)]],
      description: [this.data?.pollDetails?.description ?? '', [Validators.required, Validators.maxLength(500)]],
      isActive: true,
      expiryDate: [this.data?.pollDetails?.expiryDate ?? '', Validators.required],
      pollOptions: this.formBuilder.array([])
    });
  }

  onPollOptionImageFileSelected(event: any, index: number) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const pollOptions = this.addPollForm.get('pollOptions') as FormArray;
        const pollOption = pollOptions.at(index) as FormGroup;
        pollOption.patchValue({
          pollImage: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  removePollOptionImage(index: number) {
    this.addPollForm.value.pollOptions[index].patchValue({
      pollImage: null,
      optionText: null
    })
  }

  get pollOptionForms() {
    return this.addPollForm.get('pollOptions') as FormArray;
  }

  addPollOption() {
    const pollOption = this.formBuilder.group({
      pollOptionId: [],
      optionText: ['', Validators.required],
      voteCount: [0],
      pollImage: ['', Validators.required],
    });

    this.pollOptionForms.push(pollOption);
    this.hideNewPollOptionButton = this.pollOptionForms.value.length > 3 ? true : false;
  }

  removePollOption(index: number) {
    this.pollOptionForms.removeAt(index);
    this.hideNewPollOptionButton = this.pollOptionForms.value.length > 3 ? true : false;
  }

  saveFileInfo(){
    const formData: FormData = new FormData();
    formData.append('userId', this.addPollForm.value.userId);
    formData.append('title', this.addPollForm.value.title);
    formData.append('description', this.addPollForm.value.description);
    formData.append('expiryDate', this.addPollForm.value.expiryDate);
    formData.append('isActive', this.addPollForm.value.isActive);
    if(this.data?.pollDetails?.pollId){
      this.addPollForm.value.pollOptions.forEach((option: any, index: number) => {
        formData.append(`pollOptions[${index}].optionText`, option.optionText);
        formData.append(`pollOptions[${index}].pollImage`, option.pollImage);
        formData.append(`pollOptions[${index}].voteCount`, option.voteCount);
        formData.append(`pollOptions[${index}].pollOptionId`, option.pollOptionId);
        formData.append(`pollOptions[${index}].pollId`, option.pollId);
      });
    }
    else{
      this.addPollForm.value.pollOptions.forEach((option: any, index: number) => {
        formData.append(`pollOptions[${index}].optionText`, option.optionText);
        formData.append(`pollOptions[${index}].pollImage`, option.pollImage);
        formData.append(`pollOptions[${index}].voteCount`, option.voteCount);
        formData.append(`pollOptions[${index}].pollOptionId`, option.pollOptionId);
        formData.append(`pollOptions[${index}].pollId`, option.pollId);
      });
    }

    return formData;
  }

  onSubmit() {
    if (this.addPollForm.valid && this.pollOptionForms.valid && this.pollOptionForms.length >= 2) {
      console.log(this.addPollForm.value);
      if(this.data?.pollDetails?.pollId != null){
        this.pollService.updatePoll(this.saveFileInfo(), this.data?.pollDetails?.pollId).subscribe((res: any) => {
          if (res) {
            this.toastr.warning(res.message);
            this.closeDialog();
            this.triggerUpdateReload(this.data?.pollDetails?.pollId);
          }
        })
      }
      else{
        this.pollService.addPoll(this.saveFileInfo()).subscribe((res: any) => {
          if (res) {
            this.toastr.success(res.message);
            this.closeDialog();
            this.triggerReload();
          }
        });
      }
    }
    else{
      this.addPollForm.markAllAsTouched();
    }
  }

  triggerUpdateReload(pollId : number): void {
    this.reloadService.reloadComponent('app-poll-list-update', { key: pollId });
  }

  triggerReload(): void {
    this.reloadService.reloadComponent('app-poll-list-add');
  }

  closeDialog(){
    this.dialogRef.close();
  }

  isString(value: any): boolean {
    return typeof value === 'string';
  }

  updateWordCount(): void {
    const descriptionControl = this.addPollForm.get('description');
    if (descriptionControl) {
      const text = descriptionControl.value;
      this.wordCount = text.length;

      if (this.wordCount > 500) {
        const trimmedText = text.slice(0, 500);
        descriptionControl.setValue(trimmedText, { emitEvent: false });
        this.wordCount = 500;
      }
    }
  }

  createPollOption(option: any): FormGroup {
    return this.formBuilder.group({
      optionText: [option.optionText],
      pollImage: [option.pollImage],
      voteCount: [option.voteCount],
      pollOptionId: [option.pollOptionId],
      pollId: [option.pollId]
    });
  }

  patchPollOptions(pollOptions: any[]): void {
    const pollOptionsArray = this.addPollForm.get('pollOptions') as FormArray;
    pollOptions.forEach(option => {
      pollOptionsArray.push(this.createPollOption(option));
    });
    this.hideNewPollOptionButton = this.addPollForm?.get('pollOptions')?.value?.length > 3 ? true : false;
  }
}