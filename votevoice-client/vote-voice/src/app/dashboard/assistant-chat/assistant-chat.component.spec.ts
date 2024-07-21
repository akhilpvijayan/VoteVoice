import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssistantChatComponent } from './assistant-chat.component';

describe('AssistantChatComponent', () => {
  let component: AssistantChatComponent;
  let fixture: ComponentFixture<AssistantChatComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssistantChatComponent]
    });
    fixture = TestBed.createComponent(AssistantChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
