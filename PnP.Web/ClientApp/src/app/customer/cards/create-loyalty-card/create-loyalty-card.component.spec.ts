import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLoyaltyCardComponent } from './create-loyalty-card.component';

describe('CreateLoyaltyCardComponent', () => {
  let component: CreateLoyaltyCardComponent;
  let fixture: ComponentFixture<CreateLoyaltyCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateLoyaltyCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateLoyaltyCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
