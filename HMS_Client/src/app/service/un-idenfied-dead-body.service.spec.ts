import { TestBed } from '@angular/core/testing';

import { UnIdenfiedDeadBodyService } from './un-idenfied-dead-body.service';

describe('UnIdenfiedDeadBodyService', () => {
  let service: UnIdenfiedDeadBodyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnIdenfiedDeadBodyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
