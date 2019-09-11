import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewGroceryListItemsComponent } from './view-grocery-list-items.component';

describe('ViewGroceryListItemsComponent', () => {
  let component: ViewGroceryListItemsComponent;
  let fixture: ComponentFixture<ViewGroceryListItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewGroceryListItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewGroceryListItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
