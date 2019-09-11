import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PetClubComponent } from './pet-club.component';

describe('PetClubComponent', () => {
  let component: PetClubComponent;
  let fixture: ComponentFixture<PetClubComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetClubComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetClubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
