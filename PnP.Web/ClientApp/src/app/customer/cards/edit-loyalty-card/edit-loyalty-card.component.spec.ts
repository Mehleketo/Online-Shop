import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLoyaltyCardComponent } from './edit-loyalty-card.component';

describe('EditLoyaltyCardComponent', () => {
  let component: EditLoyaltyCardComponent;
  let fixture: ComponentFixture<EditLoyaltyCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditLoyaltyCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditLoyaltyCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
