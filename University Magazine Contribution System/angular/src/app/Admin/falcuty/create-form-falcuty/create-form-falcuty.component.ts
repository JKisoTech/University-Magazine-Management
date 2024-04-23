import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FacultyDTO } from '../../../API/Admin/falcuty/model';
import { FalcutyService } from '../../../API/Admin/falcuty/falcuty.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-create-form-falcuty',
  templateUrl: './create-form-falcuty.component.html',
  styleUrl: './create-form-falcuty.component.scss'
})
export class CreateFormFalcutyComponent implements OnInit {

  form : FormGroup;

  constructor(
    private falcutyService : FalcutyService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CreateFormFalcutyComponent>
  ){}

  ngOnInit(): void {
    this.buildForm();
  }
  buildForm(){
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: ['', [Validators.required]]
    })
  }

  
}
