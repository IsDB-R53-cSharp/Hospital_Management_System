import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TakenServicesComponent } from './taken-services.component';

describe('TakenServicesComponent', () => {
  let component: TakenServicesComponent;
  let fixture: ComponentFixture<TakenServicesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TakenServicesComponent]
    });
    fixture = TestBed.createComponent(TakenServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
