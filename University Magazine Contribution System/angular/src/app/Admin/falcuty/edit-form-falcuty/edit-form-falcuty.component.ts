import { Component, OnInit , Inject} from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FalcutyService } from '../../../API/Admin/falcuty/falcuty.service';
import { MatDialogRef,  MAT_DIALOG_DATA } from '@angular/material/dialog';



@Component({
  selector: 'app-edit-form-falcuty',
  templateUrl: './edit-form-falcuty.component.html',
  styleUrl: './edit-form-falcuty.component.scss'
})
export class EditFormFalcutyComponent implements OnInit {

  form: FormGroup;
  currentId: number;

  constructor(
    private falcutyService: FalcutyService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditFormFalcutyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ){}

  ngOnInit(): void {
    this.buildForm();
    this.currentId = this.data.currenId;
  }

  buildForm(){
    this.form = this.fb.group({
      name: [this.data.falcuty.name , [Validators.required]],
      description: [this.data.falcuty.description, [Validators.required]],
    });
  }

  SaveEdit(){
    this.falcutyService.UpdateFalcuty(this.currentId, this.form.value).subscribe(() => {
      this.dialogRef.close();
    })
  }
}
