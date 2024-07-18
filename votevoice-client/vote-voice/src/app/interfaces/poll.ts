import { PollOption } from './poll-option';
export class Poll {
    userId!: number;
    title!: string;
    description!: number;
    isActive!: boolean;
    firstName!: string;
    lastName!: string;
    profileImage!: any;
    expiryDate!: Date;
    pollOptions!: PollOption[];
}