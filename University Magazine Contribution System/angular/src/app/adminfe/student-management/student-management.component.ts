import { Component, OnInit } from '@angular/core';
import { StudentDTO } from '../../API/Admin/Student/model';
import { StudentService } from '../../API/Admin/Student/student.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-student-management',
  templateUrl: './student-management.component.html',
  styleUrl: './student-management.component.scss'
})
export class StudentManagementComponent implements OnInit {
  pageSize = 5;
  student: StudentDTO[] = [];
  currentPage = 1;
  paginatedStudent: StudentDTO[] = [];

  constructor(
    private studentService : StudentService
  ){}
  
  ngOnInit(): void {
    this.studentService.GetStudent().subscribe((result) => {
      this.student = result;
      this.paginateStudent();
    })
  }

  paginateStudent(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedStudent = this.student.slice(startIndex, endIndex);
  }

  setCurrentPage(page: number): void {
    this.currentPage = page;
    this.paginateStudent();
  }
  getPageNumbers(): number[] {
    const totalPages = Math.ceil(this.student.length / this.pageSize);
    return Array.from({ length: totalPages }, (_, i) => i + 1);
  }

  hasNextPage(): boolean {
    const totalPages = Math.ceil(this.student.length / this.pageSize);
    return totalPages > 1;
  }

}
