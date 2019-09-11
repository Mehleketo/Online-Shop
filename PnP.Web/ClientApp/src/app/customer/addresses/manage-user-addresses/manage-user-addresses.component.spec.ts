import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageUserAddressesComponent } from './manage-user-addresses.component';

describe('ManageUserAddressesComponent', () => {
  let component: ManageUserAddressesComponent;
  let fixture: ComponentFixture<ManageUserAddressesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageUserAddressesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageUserAddressesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
