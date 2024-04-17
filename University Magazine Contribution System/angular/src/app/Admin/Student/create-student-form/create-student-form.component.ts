import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { MatDialogRef } from '@angular/material/dialog';
import { StudentDTO } from '../../../API/Admin/Student/model';





@Component({
  selector: 'app-create-student-form',
  templateUrl: './create-student-form.component.html',
  styleUrl: './create-student-form.component.scss'
})
export class CreateStudentFormComponent implements OnInit{

  form: FormGroup;
  constructor(
    private studentService : StudentService,
    private dialogRef: MatDialogRef<CreateStudentFormComponent>,
    private fb: FormBuilder
  ){}

  ngOnInit(): void {
    this.buildForm();
  }


  Save(){
    this.studentService.CreateStudent(this.form.value).subscribe(() => {
      this.dialogRef.close();
    });
  }

  buildForm(){
    this.form = this.fb.group({
      studentID: ['', [Validators.required]],
      studentName: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      email: ['', [Validators.required]],
      phones: ['', [Validators.required]],
      facultyID : ['', [Validators.required]],
    })
  }
}
