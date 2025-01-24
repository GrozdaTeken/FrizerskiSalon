import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarBelowComponent } from './navbar-below.component';

describe('NavbarBelowComponent', () => {
  let component: NavbarBelowComponent;
  let fixture: ComponentFixture<NavbarBelowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NavbarBelowComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavbarBelowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
