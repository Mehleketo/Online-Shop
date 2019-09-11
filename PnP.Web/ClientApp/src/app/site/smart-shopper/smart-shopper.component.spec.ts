import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmartShopperComponent } from './smart-shopper.component';

describe('SmartShopperComponent', () => {
  let component: SmartShopperComponent;
  let fixture: ComponentFixture<SmartShopperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmartShopperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmartShopperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
