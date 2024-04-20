import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentViewDocumentComponent } from './student-view-document.component';

describe('StudentViewDocumentComponent', () => {
  let component: StudentViewDocumentComponent;
  let fixture: ComponentFixture<StudentViewDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StudentViewDocumentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentViewDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
