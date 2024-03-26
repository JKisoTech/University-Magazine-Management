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
  displayColumns: string[] = ['action', 'name', 'description'];

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

  CreateFalcuty(): void {
    const dialogRef = this.dialog.open(CreateFormFalcutyComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe(() => {
      this.ngOnInit();
    })
  }

  EditFalcuty(id: number) {
    this.falcutyService.GetFalcutyId(id).subscribe((response) => {
      this.currentId = id;
      const dialogRef = this.dialog.open(EditFormFalcutyComponent, {
        width: '400px',
        data: { falcuty: response, currenId: this.currentId},
      });

      dialogRef.afterClosed().subscribe(() => {
        this.ngOnInit();
      })
    })
  }
  DeleteFalcuty(id: number) {
    this.falcutyService.DeleteFalcuty(id).subscribe(() => {
      this.ngOnInit();
    })
  }


}
