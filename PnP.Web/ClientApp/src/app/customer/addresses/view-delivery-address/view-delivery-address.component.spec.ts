import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDeliveryAddressComponent } from './view-delivery-address.component';

describe('ViewDeliveryAddressComponent', () => {
  let component: ViewDeliveryAddressComponent;
  let fixture: ComponentFixture<ViewDeliveryAddressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDeliveryAddressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDeliveryAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
