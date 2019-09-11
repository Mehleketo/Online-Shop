import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WineClubComponent } from './wine-club.component';

describe('WineClubComponent', () => {
  let component: WineClubComponent;
  let fixture: ComponentFixture<WineClubComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WineClubComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WineClubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
