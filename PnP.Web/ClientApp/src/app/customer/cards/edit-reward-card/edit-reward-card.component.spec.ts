import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRewardCardComponent } from './edit-reward-card.component';

describe('EditRewardCardComponent', () => {
  let component: EditRewardCardComponent;
  let fixture: ComponentFixture<EditRewardCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditRewardCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditRewardCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
