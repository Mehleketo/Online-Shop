import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRewardCardComponent } from './view-reward-card.component';

describe('ViewRewardCardComponent', () => {
  let component: ViewRewardCardComponent;
  let fixture: ComponentFixture<ViewRewardCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewRewardCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewRewardCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
