import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewUserAddressesComponent } from './view-user-addresses.component';

describe('ViewUserAddressesComponent', () => {
  let component: ViewUserAddressesComponent;
  let fixture: ComponentFixture<ViewUserAddressesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewUserAddressesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewUserAddressesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
