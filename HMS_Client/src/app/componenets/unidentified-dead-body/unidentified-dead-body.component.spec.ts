import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnidentifiedDeadBodyComponent } from './unidentified-dead-body.component';

describe('UnidentifiedDeadBodyComponent', () => {
  let component: UnidentifiedDeadBodyComponent;
  let fixture: ComponentFixture<UnidentifiedDeadBodyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UnidentifiedDeadBodyComponent]
    });
    fixture = TestBed.createComponent(UnidentifiedDeadBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
