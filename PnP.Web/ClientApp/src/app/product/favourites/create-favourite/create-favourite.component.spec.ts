import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFavouriteComponent } from './create-favourite.component';

describe('CreateFavouriteComponent', () => {
  let component: CreateFavouriteComponent;
  let fixture: ComponentFixture<CreateFavouriteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateFavouriteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateFavouriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
