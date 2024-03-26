import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFormFalcutyComponent } from './edit-form-falcuty.component';

describe('EditFormFalcutyComponent', () => {
  let component: EditFormFalcutyComponent;
  let fixture: ComponentFixture<EditFormFalcutyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditFormFalcutyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditFormFalcutyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
