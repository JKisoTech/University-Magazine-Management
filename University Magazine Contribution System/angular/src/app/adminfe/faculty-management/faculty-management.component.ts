import { Component, OnInit } from '@angular/core';
import { FacultyDTO } from '../../API/Admin/falcuty/model';
import { UserService } from '../../API/Admin/User/user.service';
import { FormBuilder } from '@angular/forms';
import { FalcutyService } from '../../API/Admin/falcuty/falcuty.service';

@Component({
  selector: 'app-faculty-management',
  templateUrl: './faculty-management.component.html',
  styleUrl: './faculty-management.component.scss'
})
export class FacultyManagementComponent implements OnInit {

  pageSize = 5;
  faculty: FacultyDTO[] = [];
  currentPage = 1;
  paginatedfaculty: FacultyDTO[] = [];

  constructor(
    private facultyService: FalcutyService

  ){}

  ngOnInit(): void {
    this.facultyService.GetAllFalcuty().subscribe((result) => {
      this.faculty = result;
      this.paginateFaculty();
    })
    
  }

  paginateFaculty(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedfaculty = this.faculty.slice(startIndex, endIndex);
  }
  
  setCurrentPage(page: number): void {
    this.currentPage = page;
    this.paginateFaculty();
  }
  
  getPageNumbers(): number[] {
    const totalPages = Math.ceil(this.faculty.length / this.pageSize);
    return Array.from({ length: totalPages }, (_, i) => i + 1);
  }

  hasNextPage(): boolean {
    const totalPages = Math.ceil(this.faculty.length / this.pageSize);
    return totalPages > 1;
  }


  
}
