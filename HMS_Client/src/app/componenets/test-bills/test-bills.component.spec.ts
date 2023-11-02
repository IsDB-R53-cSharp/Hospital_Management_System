import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestBillsComponent } from './test-bills.component';

describe('TestBillsComponent', () => {
  let component: TestBillsComponent;
  let fixture: ComponentFixture<TestBillsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TestBillsComponent]
    });
    fixture = TestBed.createComponent(TestBillsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
