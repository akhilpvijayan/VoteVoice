import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from  '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatBadgeModule} from '@angular/material/badge';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialogModule } from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PollListComponent } from './dashboard/poll-list/poll-list.component';
import { ProfileSideBarComponent } from './dashboard/profile-side-bar/profile-side-bar.component';
import { AddPollComponent } from './dashboard/poll-list/add-poll/add-poll.component';
import { AddPollModalComponent } from './dashboard/poll-list/add-poll/add-poll-modal/add-poll-modal.component';
import { LoaderSkeletonComponent } from './loader-skeleton/loader-skeleton.component';
import { ConfirmationPopupModalComponent } from './shared/confirmation-popup-modal/confirmation-popup-modal.component';
import { AssistantChatComponent } from './dashboard/assistant-chat/assistant-chat.component';
import { ProfileComponent } from './profile/profile.component';
import { SignupComponent } from './signup/signup.component';
import { MiscSideBarComponent } from './dashboard/misc-side-bar/misc-side-bar.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { MatTooltipModule } from '@angular/material/tooltip';
import { NotificationComponent } from './nav-bar/notification/notification.component';
import { NgxCaptchaModule } from 'ngx-captcha';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavBarComponent,
    DashboardComponent,
    PollListComponent,
    ProfileSideBarComponent,
    AddPollComponent,
    AddPollModalComponent,
    LoaderSkeletonComponent,
    ConfirmationPopupModalComponent,
    AssistantChatComponent,
    ProfileComponent,
    SignupComponent,
    MiscSideBarComponent,
    NotificationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    BrowserAnimationsModule,
    MatDialogModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatBadgeModule,
    MatListModule,
    MatCardModule,
    MatTabsModule,
    FormsModule,
    NgxSpinnerModule,
    MatTooltipModule,
    NgxCaptchaModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
