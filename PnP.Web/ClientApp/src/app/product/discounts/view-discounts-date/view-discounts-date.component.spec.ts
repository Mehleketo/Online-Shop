import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDiscountsDateComponent } from './view-discounts-date.component';

describe('ViewDiscountsDateComponent', () => {
  let component: ViewDiscountsDateComponent;
  let fixture: ComponentFixture<ViewDiscountsDateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDiscountsDateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDiscountsDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
