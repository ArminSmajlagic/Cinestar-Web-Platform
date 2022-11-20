import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetaljiFilmaComponent } from './detalji-filma.component';

describe('DetaljiFilmaComponent', () => {
  let component: DetaljiFilmaComponent;
  let fixture: ComponentFixture<DetaljiFilmaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetaljiFilmaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetaljiFilmaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
