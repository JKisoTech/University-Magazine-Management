import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserContronllerComponent } from './user-contronller.component';

describe('UserContronllerComponent', () => {
  let component: UserContronllerComponent;
  let fixture: ComponentFixture<UserContronllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserContronllerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserContronllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
