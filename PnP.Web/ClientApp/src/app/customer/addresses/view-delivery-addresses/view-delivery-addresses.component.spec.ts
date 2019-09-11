import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDeliveryAddressesComponent } from './view-delivery-addresses.component';

describe('ViewDeliveryAddressesComponent', () => {
  let component: ViewDeliveryAddressesComponent;
  let fixture: ComponentFixture<ViewDeliveryAddressesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDeliveryAddressesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDeliveryAddressesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
