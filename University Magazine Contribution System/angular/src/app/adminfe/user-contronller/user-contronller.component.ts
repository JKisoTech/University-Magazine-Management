  import { Component, OnInit, ViewChild } from '@angular/core';
  import { UserService } from '../../API/Admin/User/user.service';
  import { MatTableDataSource } from '@angular/material/table';
  import { UserDto } from '../../API/Admin/User/model';
  import { MatPaginator } from '@angular/material/paginator';
  import { MatDialog } from '@angular/material/dialog';
  import { FormBuilder, FormGroup, Validators } from '@angular/forms';
  import { FalcutyService } from '../../API/Admin/falcuty/falcuty.service';
  import { FacultyDTO } from '../../API/Admin/falcuty/model';

  @Component({
    selector: 'app-user-contronller',
    templateUrl: './user-contronller.component.html',
    styleUrl: './user-contronller.component.scss'
  })
  export class UserContronllerComponent implements OnInit{

    pageSize = 5;
    user: UserDto[] = [];
    currentPage = 1;
    paginatedUsers: UserDto[] = [];
    isFormVisible = false; 
    form: FormGroup;
    faculty: FacultyDTO[] = [];
    isEditFormVisible = false;




    constructor(
      private userService: UserService,
      private fb: FormBuilder,
      private facultyService: FalcutyService

    ){}

    ngOnInit(): void {
      this.buildForm(); 
      this.userService.GetAllUser().subscribe((result) => {
        this.user = result;
        this.paginateUsers();
      })
      this.facultyService.GetAllFalcuty().subscribe((result) => {
        this.faculty = result;
      })
      
    }

    getRoleText(role: number | undefined): string {
      if (typeof role === 'undefined') {
        return '';
      }
    
      switch (role) {
        case 0:
          return 'Admin';
        case 1:
          return 'Student';
        case 2:
          return 'Coordinator';
        case 3:
          return 'Marketing';
        default:
          return '';
      }
    }

    paginateUsers(): void {
      const startIndex = (this.currentPage - 1) * this.pageSize;
      const endIndex = startIndex + this.pageSize;
      this.paginatedUsers = this.user.slice(startIndex, endIndex);
    }
    
    setCurrentPage(page: number): void {
      this.currentPage = page;
      this.paginateUsers();
    }
    
    getPageNumbers(): number[] {
      const totalPages = Math.ceil(this.user.length / this.pageSize);
      return Array.from({ length: totalPages }, (_, i) => i + 1);
    }

    hasNextPage(): boolean {
      const totalPages = Math.ceil(this.user.length / this.pageSize);
      return totalPages > 1;
    }
    openForm(): void {
      this.isFormVisible = true;
    }

    closeForm(): void {
      this.isFormVisible = false;
      this.isEditFormVisible = false;
    }

    buildForm() {
      this.form = this.fb.group({
        loginName: [ '' , [Validators.required]],
        fullName: ['' , [Validators.required]],
        status: [ true, [Validators.required]],
        role: [ 0, [Validators.required]],
        password: [''],
        email: ['', [Validators.required]],
        
        facultyID: [null],
      });
    }
    Save( ){
      const facultyID = this.form.value.facultyID;
      this.userService.CreateUser(this.form.value, facultyID).subscribe(() => {
      this.closeForm();
      this.ngOnInit();
      });
    }
    editUser(userData: UserDto): void {
      this.form.setValue({
        loginName: userData.loginName,
        fullName: userData.fullName,
        status: userData.status,
        role: userData.role,
        email: userData.email,
        facultyID: userData.facultyID
      });
      this.isEditFormVisible = true;
    }
    SaveEdit(): void {
      const loginName = this.form.value.loginName;
      const updatedUserData = this.form.value;
      this.userService.UpdateUser(loginName, updatedUserData).subscribe(() => {
        this.closeForm();
        this.ngOnInit();
      });
    }
    updateUserStatus(userData: UserDto): void {
      const newStatus = !userData.status; // Toggle the status
    
      if (userData.loginName) {
        this.userService.UpdateUserStatus(userData.loginName, newStatus).subscribe(() => {
          // Update the user's status in the local data
          userData.status = newStatus;
        }, (error) => {
          // Handle error
        });
      } else {
        // Handle the case when loginName is undefined
        console.error("User loginName is undefined.");
      }
    }

    

  }
