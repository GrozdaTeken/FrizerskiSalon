import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogReservationConformationComponent } from './dialog-reservation-conformation.component';

describe('DialogReservationConformationComponent', () => {
  let component: DialogReservationConformationComponent;
  let fixture: ComponentFixture<DialogReservationConformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DialogReservationConformationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogReservationConformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
