import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { MatDialog } from '@angular/material/dialog';
import { UploadContributionPageComponent } from '../upload-contribution-page/upload-contribution-page.component';







@Component({
  selector: 'app-view-all-contribution',
  templateUrl: './view-all-contribution.component.html',
  styleUrl: './view-all-contribution.component.scss'
})
export class ViewAllContributionComponent implements OnInit{

  getData: any;
  dataSource: MatTableDataSource<ContributionDto>;
  displayColumns: string [] = ['contributionID','studentID', 'title', 'type'];

  constructor(
    private contributionService: ContributionService,
    private dialog: MatDialog,
  ){}

  ngOnInit(): void {
    this.contributionService.GetContributor().subscribe((result) => {
      this.dataSource = new MatTableDataSource(result);
    })
  }

  OpenUploadContribution(): void {
    const dialogRef = this.dialog.open(UploadContributionPageComponent, {
     width: '400px'
   });
   dialogRef.afterClosed().subscribe(() => {
     this.ngOnInit();
   })
 }

}
