import { TestBed } from '@angular/core/testing';

import { TakenServicesService } from './taken-services.service';

describe('TakenServicesService', () => {
  let service: TakenServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TakenServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
