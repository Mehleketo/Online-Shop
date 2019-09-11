import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewLoyaltyCardComponent } from './view-loyalty-card.component';

describe('ViewLoyaltyCardComponent', () => {
  let component: ViewLoyaltyCardComponent;
  let fixture: ComponentFixture<ViewLoyaltyCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewLoyaltyCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewLoyaltyCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
