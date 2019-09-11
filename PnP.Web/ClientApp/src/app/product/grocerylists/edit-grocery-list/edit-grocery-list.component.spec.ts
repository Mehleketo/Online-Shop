import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGroceryListComponent } from './edit-grocery-list.component';

describe('EditGroceryListComponent', () => {
  let component: EditGroceryListComponent;
  let fixture: ComponentFixture<EditGroceryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditGroceryListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGroceryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
