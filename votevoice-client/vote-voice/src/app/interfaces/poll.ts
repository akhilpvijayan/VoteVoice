import { PollOption } from './poll-option';
export class Poll {
    pollId!: number;
    userId!: number;
    title!: string;
    description!: number;
    isActive!: boolean;
    firstName!: string;
    lastName!: string;
    profileImage!: any;
    expiryDate!: Date;
    totalVotes!: number;
    pollOptions!: PollOption[];
}