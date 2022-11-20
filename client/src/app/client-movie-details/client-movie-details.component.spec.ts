import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientMovieDetailsComponent } from './client-movie-details.component';

describe('ClientMovieDetailsComponent', () => {
  let component: ClientMovieDetailsComponent;
  let fixture: ComponentFixture<ClientMovieDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientMovieDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientMovieDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
