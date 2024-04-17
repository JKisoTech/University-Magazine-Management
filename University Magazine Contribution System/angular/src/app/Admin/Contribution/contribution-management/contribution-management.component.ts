import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';





@Component({
  selector: 'app-contribution-management',
  templateUrl: './contribution-management.component.html',
  styleUrl: './contribution-management.component.scss'
})
export class ContributionManagementComponent implements OnInit {


  dataSource: MatTableDataSource<ContributionDto>;
  displayColumns: string[] = ['contributionID', 'studentID', 'content', 'status', 'title', 'description', 'type' ];

  constructor(
    private contributionService: ContributionService,
  ){}

  ngOnInit(): void {
    this.contributionService.GetContributor().subscribe((result) => {
      this.dataSource = new MatTableDataSource(result);
    })
  }

}
