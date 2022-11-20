import { TestBed } from '@angular/core/testing';

import { NotificationMiddlewareService } from './notification-middleware.service';

describe('NotificationMiddlewareService', () => {
  let service: NotificationMiddlewareService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NotificationMiddlewareService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
