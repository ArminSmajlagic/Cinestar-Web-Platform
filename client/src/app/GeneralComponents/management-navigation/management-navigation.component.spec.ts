import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementNavigationComponent } from './management-navigation.component';

describe('ManagementNavigationComponent', () => {
  let component: ManagementNavigationComponent;
  let fixture: ComponentFixture<ManagementNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagementNavigationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagementNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
