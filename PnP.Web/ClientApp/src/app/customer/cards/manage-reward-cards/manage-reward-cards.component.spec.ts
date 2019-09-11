import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageRewardCardsComponent } from './manage-reward-cards.component';

describe('ManageRewardCardsComponent', () => {
  let component: ManageRewardCardsComponent;
  let fixture: ComponentFixture<ManageRewardCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageRewardCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageRewardCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
