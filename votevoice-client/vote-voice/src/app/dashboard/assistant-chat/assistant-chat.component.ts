import { AiChatMessages } from './../../interfaces/ai-chat-messages';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-assistant-chat',
  templateUrl: './assistant-chat.component.html',
  styleUrls: ['./assistant-chat.component.scss'],
  animations: [
    trigger('openClose', [
      state('open', style({
        transform: 'translateY(0)',
        opacity: 1
      })),
      state('closed', style({
        transform: 'translateY(100%)',
        opacity: 0
      })),
      transition('closed => open', [
        animate('0.3s ease-out')
      ]),
      transition('open => closed', [
        animate('0.3s ease-in')
      ])
    ])
  ]
})
export class AssistantChatComponent {
  @Input() isAssistantOpen!: boolean;
  messageText: string = '';
  messages: AiChatMessages[] = [];

  get chatState() {
    return this.isAssistantOpen ? 'open' : 'closed';
  }
}
