import { Component } from '@angular/core';

@Component({
  selector: 'app-poll-list',
  templateUrl: './poll-list.component.html',
  styleUrls: ['./poll-list.component.scss']
})
export class PollListComponent {
  pollOptions = [
    { text: 'Cristiano Ronaldo', image: 'https://akcdn.detik.net.id/visual/2024/06/15/soccer-friendly-por-irlreport_169.jpeg?w=400&q=90', votes: 0 },
    { text: 'Zlatan Ibrahimovic', image: 'https://d2x51gyc4ptf2q.cloudfront.net/content/uploads/2023/06/08132451/Zlatan-Ibrahimovic.jpg', votes: 0 },
    { text: 'Toni Kroos', image: 'https://i2-prod.football.london/incoming/article27030444.ece/ALTERNATES/s1200b/0_Kroos.jpg', votes: 0 },
    { text: 'Lional Messi', image: 'https://hips.hearstapps.com/hmg-prod/images/lionel-messi-celebrates-after-their-sides-third-goal-by-news-photo-1686170172.jpg?crop=0.66653xw:1xh;center,top&resize=640:*', votes: 0 }
  ];
  loading = false;
  showResults = false;
  totalVotes = 0;

  vote(option: any) {
    this.loading = true;
    setTimeout(() => {
      this.loading = false;
      this.showResults = true;
      option.votes += 1; // Increment vote count
      this.totalVotes = this.pollOptions.reduce((acc, opt) => acc + opt.votes, 0);
    }, 1000);
  }
}
