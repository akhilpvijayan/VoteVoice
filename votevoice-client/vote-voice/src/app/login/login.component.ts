import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../Auth/auth.service';
import { ReloadService } from '../services/reload.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup;
  isInvalidUser = false;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<LoginComponent>,
    private router: Router,
    private reloadService: ReloadService){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.isInvalidUser = false;
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next: (result: any) => {
          if (result !== null && (result.accessToken || result.refreshToken)) {
            this.authService.setToken(result.token);
            this.authService.setUser(result.user);
            this.authService.setRefreshToken(result.refreshToken);
            this.toastr.success(result.message);
            this.loginForm.reset();
            this.closeDialog();
            this.router.navigateByUrl('');
          } else {
            this.toastr.error('Login failed: Invalid response from server.');
          }
        },
        error: (err: any) => {
          if (err.status == 404) {
            this.toastr.error('Invalid credentials.');
            this.isInvalidUser = true;
          }
          else {
            this.toastr.error('An error occurred during login.');
          }
        }
      });

    }
  }

  closeDialog(){
    this.dialogRef.close();
  }
}
