import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDeliveryAddressComponent } from './edit-delivery-address.component';

describe('EditDeliveryAddressComponent', () => {
  let component: EditDeliveryAddressComponent;
  let fixture: ComponentFixture<EditDeliveryAddressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditDeliveryAddressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditDeliveryAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
