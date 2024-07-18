import { PollOption } from './../../../../interfaces/poll-option';
import { UserService } from './../../../../services/user.service';
import { Component, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

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

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<AddPollModalComponent>,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.initializeForm();
    //this.imageUrl = this.data?.postDetails?.contentImage ?? this.imgConverter.convertImageToDataURL(this.data.postDetails.contentImage)
  }

  initializeForm() {
    this.addPollForm = this.formBuilder.group({
      content: [this.data?.postDetails?.content ?? '', Validators.required],
      userId: this.userService.getUserId(),
      title: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      isActive: true,
      expiryDate: [, Validators.required],
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

  removeProfileImage(index: number) {
    this.addPollForm.value.pollOptions[index].patchValue({
      pollImage: null
    })
  }

  get pollOptionForms() {
    return this.addPollForm.get('pollOptions') as FormArray;
  }

  addPollOption() {
    const pollOption = this.formBuilder.group({
      optionText: ['', Validators.required],
      voteCount: [0],
      pollImage: [null, Validators.required],
    });

    this.pollOptionForms.push(pollOption);
    this.hideNewPollOptionButton = this.pollOptionForms.value.length > 3 ? true : false;
  }

  removePollOption(index: number) {
    this.pollOptionForms.removeAt(index);
    this.hideNewPollOptionButton = this.pollOptionForms.value.length > 3 ? true : false;
  }

  saveFileInfo(){
    const formData : FormData =new FormData();
    formData.append('content', this.addPollForm.value.content);
    formData.append('contentImage', this.selectedFile);
    formData.append('userId', this.addPollForm.value.userId);
    if(this.data?.postDetails?.postId != null){
      formData.append('postId', this.data.postDetails.postId);
    };
    return formData;
  }

  onSubmit() {
    if (this.addPollForm.valid) {
      if(this.data?.postDetails?.postId != null){
        // this.postService.updatePost(this.saveFileInfo()).subscribe((res: any) => {
        //   if (res) {
        //     this.toastr.warning("Post updated successfully");
        //     this.closeDialog();
        //     this.triggerUpdateReload(this.data?.postDetails?.postId);
        //     this.spinner.hide();
        //   }
        // })
      }
      else{
        // this.postService.addPost(this.saveFileInfo()).subscribe((res: any) => {
        //   if (res) {
        //     this.toastr.success("New post created successfully");
        //     this.closeDialog();
        //     this.triggerReload();
        //     this.spinner.hide();
        //   }
        // });
      }
    }
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
}