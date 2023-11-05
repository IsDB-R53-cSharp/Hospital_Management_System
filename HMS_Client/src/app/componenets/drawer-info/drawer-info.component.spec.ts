import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawerInfoComponent } from './drawer-info.component';

describe('DrawerInfoComponent', () => {
  let component: DrawerInfoComponent;
  let fixture: ComponentFixture<DrawerInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DrawerInfoComponent]
    });
    fixture = TestBed.createComponent(DrawerInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
