import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPollModalComponent } from './add-poll-modal.component';

describe('AddPollModalComponent', () => {
  let component: AddPollModalComponent;
  let fixture: ComponentFixture<AddPollModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddPollModalComponent]
    });
    fixture = TestBed.createComponent(AddPollModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
