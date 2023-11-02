import { TestBed } from '@angular/core/testing';

import { MedicineBillsService } from './medicine-bills.service';

describe('MedicineBillsService', () => {
  let service: MedicineBillsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicineBillsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
