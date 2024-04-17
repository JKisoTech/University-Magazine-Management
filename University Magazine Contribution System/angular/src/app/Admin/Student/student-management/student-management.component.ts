import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { StudentDTO } from '../../../API/Admin/Student/model';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { MatDialog} from '@angular/material/dialog';
import { CreateStudentFormComponent } from '../create-student-form/create-student-form.component';







@Component({
  selector: 'app-student-management',
  templateUrl: './student-management.component.html',
  styleUrl: './student-management.component.scss'
})
export class StudentManagementComponent implements OnInit {

  getData: any;
  dataSourse: MatTableDataSource<StudentDTO>;
  displayColumns: string [] = ['action', 'studentID', 'studentName', 'dateOfBirth', 'email', 'phones', 'facultyID'];


  constructor(
    private studentService: StudentService,
    private dialog: MatDialog
  ){}

  ngOnInit(): void {
    this.studentService.GetStudent().subscribe((result) => {
      this.dataSourse = new MatTableDataSource(result);
    })
  }

  CreateStudent(): void { 
    const dialogRef = this.dialog.open(CreateStudentFormComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe(() => {
      this.ngOnInit();
    })
  }
}

