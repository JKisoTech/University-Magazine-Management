import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { UserDto } from '../../API/Admin/User/model';
import { UserService } from '../../API/Admin/User/user.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

import { CreateFormUserComponent } from './create-form-user/create-form-user.component';
import { EditFormUserComponent } from './edit-form-user/edit-form-user.component';


@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.scss'
})
export class UserManagementComponent implements OnInit {

  form: FormGroup;
  getData: any;
  currentId: number;
  isEditOpen = false;
  isModalOpen = false;
  dataSource: MatTableDataSource<UserDto>;
  displayColumns: string [] = ['action' , 'loginName', 'fullName', 'status', 'password','role','facultyId'];


  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private dialog: MatDialog
  ){}

  ngOnInit(): void {
    this.userService.GetAllUser().subscribe((result) => {
      this.dataSource = new MatTableDataSource(result);
    })
  }

  
  CreateUser(): void {
     const dialogRef = this.dialog.open(CreateFormUserComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe(() => {
      this.ngOnInit();
    })
  }

  
  

  edituser(id :number){
    this.userService.GetUserId(id).subscribe((response) => {
      this.currentId = id;
      const dialogRef = this.dialog.open(EditFormUserComponent, {
        width: '400px',
        data: { user: response, currentId: this.currentId },
      });

      dialogRef.afterClosed().subscribe(() => {
        this.ngOnInit();
      })
    })
  }

  

}
