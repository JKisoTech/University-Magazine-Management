import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { FalcutyDTO } from '../../API/Admin/falcuty/model';
import { FalcutyService } from '../../API/Admin/falcuty/falcuty.service';
import { MatDialog} from '@angular/material/dialog';
import { CreateFormFalcutyComponent } from './create-form-falcuty/create-form-falcuty.component';
import { EditFormFalcutyComponent } from './edit-form-falcuty/edit-form-falcuty.component';




@Component({
  selector: 'app-falcuty',
  templateUrl: './falcuty.component.html',
  styleUrl: './falcuty.component.scss'
})
export class FalcutyComponent implements OnInit {

  form: FormGroup;
  currentId: number;
  dataSource: MatTableDataSource<FalcutyDTO>;
  displayColumns: string[] = [ 'facultyID', 'facultyName'];

  constructor(
    private fb: FormBuilder,
    private falcutyService: FalcutyService,
    private dialog: MatDialog
  ){}

  ngOnInit(): void {
    this.falcutyService.GetAllFalcuty().subscribe((result) => {
      this.dataSource = new MatTableDataSource(result);
    })
  }


}
