import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { MatDialog } from '@angular/material/dialog';
import { UploadContributionPageComponent } from '../upload-contribution-page/upload-contribution-page.component';
import { Router } from '@angular/router';
import { UpdateContributionPageComponent } from '../update-contribution-page/update-contribution-page.component';







@Component({
  selector: 'app-view-all-contribution',
  templateUrl: './view-all-contribution.component.html',
  styleUrl: './view-all-contribution.component.scss'
})
export class ViewAllContributionComponent implements OnInit{

  getData: any;
  dataSource: MatTableDataSource<ContributionDto>;
  displayColumns: string [] = ['action','contributionID','studentID', 'title', 'type'];
  contribution: ContributionDto | null = null;

  constructor(
    private contributionService: ContributionService,
    private dialog: MatDialog,
    private router : Router
  ){}

  ngOnInit(): void {
    this.contributionService.GetContributor().subscribe((result) => {
      this.dataSource = new MatTableDataSource(result);
    })
  }

  OpenUploadContribution(): void {
    this.router.navigate(['/upload-contribution']);
 }
 viewContribution(contributionID: string) {
  this.router.navigate(['/contribution', contributionID]);
}
editContribution(id: string) {
  this.contributionService.GetContent(id).subscribe(
    (contribution) => {
      // Navigate to the update page with the contribution details
      const dialogRef = this.dialog.open(UpdateContributionPageComponent, {
        width: '400px',
        data: { contributionId: id, contributionData: contribution }
        
      });
      dialogRef.afterClosed().subscribe(() => {
        this.ngOnInit();
      })
    },
    (error) => {
      // Handle error
    }
  );
}

}
