import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjekcijeComponent } from './projekcije.component';

describe('ProjekcijeComponent', () => {
  let component: ProjekcijeComponent;
  let fixture: ComponentFixture<ProjekcijeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjekcijeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjekcijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
