import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmationPopupModalComponent } from './confirmation-popup-modal.component';

describe('ConfirmationPopupModalComponent', () => {
  let component: ConfirmationPopupModalComponent;
  let fixture: ComponentFixture<ConfirmationPopupModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConfirmationPopupModalComponent]
    });
    fixture = TestBed.createComponent(ConfirmationPopupModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
