import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDiscountsTodayComponent } from './view-discounts-today.component';

describe('ViewDiscountsTodayComponent', () => {
  let component: ViewDiscountsTodayComponent;
  let fixture: ComponentFixture<ViewDiscountsTodayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDiscountsTodayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDiscountsTodayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
