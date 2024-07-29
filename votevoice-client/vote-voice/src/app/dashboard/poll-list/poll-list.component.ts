import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../../Auth/auth.service';
import { ConfirmationPopupModalComponent } from './../../shared/confirmation-popup-modal/confirmation-popup-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { PollOption } from './../../interfaces/poll-option';
import { Poll } from './../../interfaces/poll';
import { UserService } from './../../services/user.service';
import { Component, Input, OnInit } from '@angular/core';
import { PollService } from 'src/app/services/poll.service';
import { ToastrService } from 'ngx-toastr';
import { AddPollModalComponent } from './add-poll/add-poll-modal/add-poll-modal.component';
import { ReloadService } from 'src/app/services/reload.service';
import { Subscription } from 'rxjs';
import { LoginComponent } from 'src/app/login/login.component';

@Component({
  selector: 'app-poll-list',
  templateUrl: './poll-list.component.html',
  styleUrls: ['./poll-list.component.scss']
})
export class PollListComponent implements OnInit {
  @Input() isFromMyPolls: boolean = false;
  loading = false;
  showResults = false;
  skip = 0;
  take = 6;
  userId = parseInt(this.userService.getUserId() ?? '0', 10);
  polls!: Poll[];
  isLoggedIn = false;

  private reloadSubscription: Subscription;
  constructor(private pollService: PollService,
    private userService: UserService,
    private toastr: ToastrService,
    private reloadService: ReloadService,
    private dialog: MatDialog,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute) { 
      this.reloadSubscription = this.reloadService.getReloadObservable()
      .subscribe(reloadData => {
        if (reloadData.componentName === 'app-poll-list-update') {
          this.loadUpdatedPoll(reloadData.data);
        }
        if (reloadData.componentName === 'app-poll-list-add') {
          this.loadPolls();
        }
      });
    }

  ngOnInit(): void {
    this.loading = true;
    //If clicks from profile button, get the userId from url
    this.route?.queryParams?.subscribe(params => {
      this.userId = parseInt(params['userId'] ?? this.userId, 10);
    });
    this.loadPolls();
    this.authService.isLoggedInObservable$.subscribe((isLoggedInSubject: any) => {
      this.isLoggedIn = isLoggedInSubject;
    });
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  loadPolls(){
    if(this.isFromMyPolls){
      this.pollService.getPollsByUser(this.skip, this.take, this.userId).subscribe((res: any) => {
        this.polls = res;
        this.loading = false;
      });
    }
    else{
      this.pollService.getAllPolls(this.skip, this.take).subscribe((res: any) => {
        this.polls = res;
        this.loading = false;
      });
    }
  }

  // Detect scroll event and load more posts when the user reaches the bottom
  onWindowScroll() {
    this.skip += this.take;
    this.loadPolls();
    }

  vote(pollId: number, pollOptionId: number) {
    if(this.isLoggedIn){
      this.loading = false;

      // Find the index of the poll by pollId
      const currentPollIndex = this.polls.findIndex(poll => poll.pollId === pollId);
  
      if (currentPollIndex !== -1) {
        // Find the specific poll option within the found poll by pollOptionId
        const currentPoll = this.polls[currentPollIndex];
        const currentPollOption = currentPoll.pollOptions.find(option => option.pollOptionId === pollOptionId);
  
        if (currentPollOption) {
          // Increment the vote count for the founded poll option
          currentPollOption.voteCount += 1;
          currentPoll.totalVotes += 1;
          currentPoll.showResults = true;
        } else {
          console.error('Poll option not found');
        }
      } else {
        console.error('Poll not found');
      }
    }
    else{
      this.login();
    }
  }

  login(){
    this.dialog.open(LoginComponent,{
      width:'70%',
      height:'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
    });
  }

  updatePoll(pollId: number){
    this.dialog.open(AddPollModalComponent,{
      width:'70%',
      height:'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      data: {
        pollDetails: this.polls.find((poll: any) => poll.pollId === pollId)
      }
    });
  }

  loadUpdatedPoll(poll: any){
    this.loading = true;
    this.pollService.getPoll(poll.key).subscribe((res: any)=>{
      if(res){
        const indexToUpdate = this.polls.findIndex((item: any) => item.pollId === poll.key);
        if (indexToUpdate !== -1) {
          this.polls[indexToUpdate] = res;
        }
        this.loading = false;
      }
    });
  }

  deletePoll(pollId: number){
    const dialogRef = this.dialog.open(ConfirmationPopupModalComponent, {
      width: 'auto',
      height: 'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      data: {
        message: 'Are you sure want to Delete this post?.'
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.loading = true;
        this.pollService.deletePoll(pollId).subscribe((res: any)=>{
          const indexToUpdate = this.polls.findIndex((item: any) => item.pollId === pollId);
            if (indexToUpdate !== -1) {
              this.polls.splice(indexToUpdate, 1);
            }
          this.loading = false;
          this.toastr.success(res.message);
        })
      }
    });
  }
  
  showProfile(userId: number) {
    this.router.navigate(['profile'], { queryParams: { userId: userId } });
  }
}
