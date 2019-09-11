import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewGroceryListComponent } from './view-grocery-list.component';

describe('ViewGroceryListComponent', () => {
  let component: ViewGroceryListComponent;
  let fixture: ComponentFixture<ViewGroceryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewGroceryListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewGroceryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
