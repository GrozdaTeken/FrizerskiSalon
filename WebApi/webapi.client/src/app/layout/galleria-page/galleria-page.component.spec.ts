import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GalleriaPageComponent } from './galleria-page.component';

describe('GalleriaPageComponent', () => {
  let component: GalleriaPageComponent;
  let fixture: ComponentFixture<GalleriaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GalleriaPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GalleriaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
