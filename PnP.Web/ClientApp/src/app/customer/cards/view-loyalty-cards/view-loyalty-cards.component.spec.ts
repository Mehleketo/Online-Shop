import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewLoyaltyCardsComponent } from './view-loyalty-cards.component';

describe('ViewLoyaltyCardsComponent', () => {
  let component: ViewLoyaltyCardsComponent;
  let fixture: ComponentFixture<ViewLoyaltyCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewLoyaltyCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewLoyaltyCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
