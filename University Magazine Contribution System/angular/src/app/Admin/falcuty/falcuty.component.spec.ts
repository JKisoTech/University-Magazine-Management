import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FalcutyComponent } from './falcuty.component';

describe('FalcutyComponent', () => {
  let component: FalcutyComponent;
  let fixture: ComponentFixture<FalcutyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FalcutyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FalcutyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
