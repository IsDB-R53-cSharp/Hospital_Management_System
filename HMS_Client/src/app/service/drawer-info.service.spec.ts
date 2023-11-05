import { TestBed } from '@angular/core/testing';

import { DrawerInfoService } from './drawer-info.service';

describe('DrawerInfoService', () => {
  let service: DrawerInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DrawerInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
