import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGroceryListItemComponent } from './create-grocery-list-item.component';

describe('CreateGroceryListItemComponent', () => {
  let component: CreateGroceryListItemComponent;
  let fixture: ComponentFixture<CreateGroceryListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateGroceryListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGroceryListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
