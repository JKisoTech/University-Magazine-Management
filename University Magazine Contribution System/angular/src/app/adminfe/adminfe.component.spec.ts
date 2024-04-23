import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminfeComponent } from './adminfe.component';

describe('AdminfeComponent', () => {
  let component: AdminfeComponent;
  let fixture: ComponentFixture<AdminfeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminfeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminfeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
