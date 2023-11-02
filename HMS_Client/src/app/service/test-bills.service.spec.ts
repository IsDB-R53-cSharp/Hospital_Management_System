import { TestBed } from '@angular/core/testing';

import { TestBillsService } from './test-bills.service';

describe('TestBillsService', () => {
  let service: TestBillsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestBillsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
