import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../API/Admin/User/user.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { UserDto } from '../../../API/Admin/User/model';



@Component({
  selector: 'app-create-form-user',
  templateUrl: './create-form-user.component.html',
  styleUrl: './create-form-user.component.scss'
})
export class CreateFormUserComponent implements OnInit {


  form: FormGroup;
  dataSource: MatTableDataSource<UserDto>;

  constructor(
    private userService: UserService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<CreateFormUserComponent>,
    
  ){}
  ngOnInit(): void {
    this.buildForm(); 
    
  }

  // Save( ){
  //   this.userService.CreateUser(this.form.value).subscribe(() => {
  //     this.dialogRef.close();
  //   })
  // }
  buildForm() {
    this.form = this.fb.group({
      loginName: [ '' , [Validators.required]],
      fullName: ['' , [Validators.required]],
      status: ['', [Validators.required]],
      password: [ '', [Validators.required]],
      role: [ '', [Validators.required]],
      falcuty: [ '', [Validators.required]],
    })
  }


}
