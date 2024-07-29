import { AuthService } from './../Auth/auth.service';
import { UserService } from './../services/user.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  signUpForm!: FormGroup;
  countries: any;
  states: any;
  isPasswordConfirmed = false;

  constructor(
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<SignupComponent>,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService,
    private authService: AuthService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.userService.getCountries().subscribe((res: any)=>{
      this.countries = res;
    });
    this.subscribeToFormChanges();
  }

  initializeForm() {
    this.signUpForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['', Validators.required,[this.emailExists.bind(this)]],
      username: ['', Validators.required,[this.userNameExists.bind(this)]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      profileImage: ['', Validators.required],
      countryId: [, Validators.required],
      stateId: [, Validators.required],
      region: ['', Validators.required],
      userBio: ['', [Validators.required, Validators.maxLength(100)]],
      gender: ['Male', Validators.required],
      roleId: [2]
    });
  }

  login() {
    this.closeDialog();
    this.dialog.open(LoginComponent, {
      width: '70%',
      height: 'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
    });
  }

  subscribeToFormChanges(): void {
    const countryControl = this.signUpForm.get('countryId');
    if (countryControl !== null) {
      countryControl.valueChanges.subscribe((selectedCountry: any) => {
        if (selectedCountry !== null) {
          this.signUpForm.patchValue({
            stateId: null
          });
          this.getStateByCountryId(selectedCountry);
        }
      });
    }

    const confirmPasswordControl = this.signUpForm.get('confirmPassword');
    if (confirmPasswordControl !== null) {
      confirmPasswordControl.valueChanges.subscribe((password: any) => {
        if (password !== null && this.signUpForm?.value?.password === password) {
          this.isPasswordConfirmed = true;
        }
        else{
          this.isPasswordConfirmed = false;
        }
      });
    }

    const passwordControl = this.signUpForm.get('password');
    if (passwordControl !== null) {
      passwordControl.valueChanges.subscribe((password: any) => {
        if (password !== null && this.signUpForm?.value?.confirmPassword === password) {
          this.isPasswordConfirmed = true;
        }
        else{
          this.isPasswordConfirmed = false;
        }
      });
    }
  }

  onPollOptionImageFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.signUpForm.patchValue({
          profileImage: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  getStateByCountryId(countryId: number){
    this.userService.getStates(countryId).subscribe((res: any)=>{
      this.states = res;
    })
  }

  userNameExists(control: AbstractControl) {
    return this.userService.userNameExists(control);
  }

  emailExists(control: AbstractControl) {
    return this.userService.emailExists(control);
  }

  saveFileInfo(){
    const formData: FormData = new FormData();
    formData.append('firstName', this.signUpForm.value.firstName);
    formData.append('lastName', this.signUpForm.value.lastName);
    formData.append('email', this.signUpForm.value.email);
    formData.append('username', this.signUpForm.value.username);
    formData.append('password', this.signUpForm.value.password);
    formData.append('profileImage', this.signUpForm.value.profileImage);
    formData.append('countryId', this.signUpForm.value.countryId);
    formData.append('stateId', this.signUpForm.value.stateId);
    formData.append('region', this.signUpForm.value.region);
    formData.append('userBio', this.signUpForm.value.userBio);
    formData.append('gender', this.signUpForm.value.gender);
    formData.append('roleId', this.signUpForm.value.roleId);
    return formData;
  }

  onSubmit() {
    if (this.signUpForm.valid) {
      console.log(this.signUpForm.value);
      if(this.data?.pollDetails?.pollId != null){
        this.userService.updateUser(this.saveFileInfo(), this.data?.userDetails?.userId).subscribe((res: any) => {
          if (res) {
            this.toastr.warning(res.message);
            this.closeDialog();
            //this.triggerUpdateReload(this.data?.pollDetails?.pollId);
          }
        })
      }
      else{
        this.userService.addUser(this.saveFileInfo()).subscribe((res: any) => {
          if (res) {
            this.toastr.success(res.message);
            this.authService.setToken(res.token);
            this.authService.setUser(res.userId);
            this.authService.setRefreshToken(res.refreshToken);
            this.signUpForm.reset();
            this.closeDialog();
          }
        });
      }
    }
    else{
      this.signUpForm.markAllAsTouched();
    }
  }


  closeDialog() {
    this.dialogRef.close();
  }
}
