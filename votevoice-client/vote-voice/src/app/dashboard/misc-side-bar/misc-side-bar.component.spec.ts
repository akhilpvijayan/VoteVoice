import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiscSideBarComponent } from './misc-side-bar.component';

describe('MiscSideBarComponent', () => {
  let component: MiscSideBarComponent;
  let fixture: ComponentFixture<MiscSideBarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MiscSideBarComponent]
    });
    fixture = TestBed.createComponent(MiscSideBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
