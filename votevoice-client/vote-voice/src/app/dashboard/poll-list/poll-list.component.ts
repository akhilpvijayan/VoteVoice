import { PollOption } from './../../interfaces/poll-option';
import { Poll } from './../../interfaces/poll';
import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { PollService } from 'src/app/services/poll.service';

@Component({
  selector: 'app-poll-list',
  templateUrl: './poll-list.component.html',
  styleUrls: ['./poll-list.component.scss']
})
export class PollListComponent implements OnInit {
  loading = false;
  showResults = false;
  userId = parseInt(this.userService.getUserId() ?? '0', 10);
  polls!: Poll[];

  constructor(private pollService: PollService,
    private userService: UserService) { }

  ngOnInit(): void {
    this.pollService.getAllPolls(0, 10).subscribe((res: any) => {
      this.polls = res;
    })
  }

  vote(pollId: number, pollOptionId: number) {
    this.loading = false;
    this.showResults = true;

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
      } else {
        console.error('Poll option not found');
      }
    } else {
      console.error('Poll not found');
    }
  }

}
