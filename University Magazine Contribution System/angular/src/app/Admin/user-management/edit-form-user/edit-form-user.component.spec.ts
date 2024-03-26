import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFormUserComponent } from './edit-form-user.component';

describe('EditFormUserComponent', () => {
  let component: EditFormUserComponent;
  let fixture: ComponentFixture<EditFormUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditFormUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditFormUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
