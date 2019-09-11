import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewGroceryListsComponent } from './view-grocery-lists.component';

describe('ViewGroceryListsComponent', () => {
  let component: ViewGroceryListsComponent;
  let fixture: ComponentFixture<ViewGroceryListsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewGroceryListsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewGroceryListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
