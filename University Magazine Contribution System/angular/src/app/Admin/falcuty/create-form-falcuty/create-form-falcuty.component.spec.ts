import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFormFalcutyComponent } from './create-form-falcuty.component';

describe('CreateFormFalcutyComponent', () => {
  let component: CreateFormFalcutyComponent;
  let fixture: ComponentFixture<CreateFormFalcutyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateFormFalcutyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateFormFalcutyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
