import { Component, OnInit , Inject} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../API/Admin/User/user.service';
import { MatDialog, MatDialogRef,  MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { UserDto } from '../../../API/Admin/User/model';

@Component({
  selector: 'app-edit-form-user',
  templateUrl: './edit-form-user.component.html',
  styleUrl: './edit-form-user.component.scss'
})
export class EditFormUserComponent implements OnInit {
  form: FormGroup;
  currentId: number;

  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditFormUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any // Inject MAT_DIALOG_DATA

  ){}

  ngOnInit(): void {
    this.buildForm();
    this.currentId = this.data.currentId;
  }
  buildForm() {
    this.form = this.fb.group({
      loginName: [this.data.user.loginName, [Validators.required]], // Populate form with user data
      fullName: [this.data.user.fullName, [Validators.required]],
      status: [this.data.user.status, [Validators.required]],
      password: [this.data.user.password, [Validators.required]],
      role: [this.data.user.role, [Validators.required]],
      falcuty: [this.data.user.falcuty, [Validators.required]],
    });
  }

  



}
