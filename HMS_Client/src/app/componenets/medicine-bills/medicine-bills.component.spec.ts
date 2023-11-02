import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineBillsComponent } from './medicine-bills.component';

describe('MedicineBillsComponent', () => {
  let component: MedicineBillsComponent;
  let fixture: ComponentFixture<MedicineBillsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MedicineBillsComponent]
    });
    fixture = TestBed.createComponent(MedicineBillsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
