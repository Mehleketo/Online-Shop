import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRewardCardsComponent } from './view-reward-cards.component';

describe('ViewRewardCardsComponent', () => {
  let component: ViewRewardCardsComponent;
  let fixture: ComponentFixture<ViewRewardCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewRewardCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewRewardCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
