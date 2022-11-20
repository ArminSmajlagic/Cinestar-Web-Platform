import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StavkaComponent } from './stavka.component';

describe('StavkaComponent', () => {
  let component: StavkaComponent;
  let fixture: ComponentFixture<StavkaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StavkaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StavkaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
