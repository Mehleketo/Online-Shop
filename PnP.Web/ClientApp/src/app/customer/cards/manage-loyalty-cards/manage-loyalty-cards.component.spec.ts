import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageLoyaltyCardsComponent } from './manage-loyalty-cards.component';

describe('ManageLoyaltyCardsComponent', () => {
  let component: ManageLoyaltyCardsComponent;
  let fixture: ComponentFixture<ManageLoyaltyCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageLoyaltyCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageLoyaltyCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
