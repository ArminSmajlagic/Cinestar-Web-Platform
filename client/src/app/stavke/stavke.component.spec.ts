import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StavkeComponent } from './stavke.component';

describe('StavkeComponent', () => {
  let component: StavkeComponent;
  let fixture: ComponentFixture<StavkeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StavkeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StavkeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
