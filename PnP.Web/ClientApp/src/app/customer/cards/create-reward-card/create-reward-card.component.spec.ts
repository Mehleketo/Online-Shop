import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateRewardCardComponent } from './create-reward-card.component';

describe('CreateRewardCardComponent', () => {
  let component: CreateRewardCardComponent;
  let fixture: ComponentFixture<CreateRewardCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateRewardCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateRewardCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
