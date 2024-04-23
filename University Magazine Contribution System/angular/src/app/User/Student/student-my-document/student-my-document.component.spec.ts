import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentMyDocumentComponent } from './student-my-document.component';

describe('StudentMyDocumentComponent', () => {
  let component: StudentMyDocumentComponent;
  let fixture: ComponentFixture<StudentMyDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StudentMyDocumentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentMyDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
