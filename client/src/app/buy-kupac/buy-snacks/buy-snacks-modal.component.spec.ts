import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuySnacksModalComponent } from './buy-snacks-modal.component';

describe('BuySnacksModalComponent', () => {
  let component: BuySnacksModalComponent;
  let fixture: ComponentFixture<BuySnacksModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BuySnacksModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BuySnacksModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
