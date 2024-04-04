import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ContributionDto } from '../../API/Contribution/model';
import { ContributionService } from '../../API/Contribution/contribution.service';


@Component({
  selector: 'app-contribution-marketing-cordinator',
  templateUrl: './contribution-marketing-cordinator.component.html',
  styleUrl: './contribution-marketing-cordinator.component.scss'
})
export class ContributionMarketingCordinatorComponent implements OnInit  {

 getData: any;
 dataSource: MatTableDataSource<ContributionDto>;
 displayColumns: string [] = ['student_id', 'title', 'description', 'content', 'type', 'submittedDate', 'lastUpdate', 'status', 'expired', 'published', 'aggreeOnItem'];

 constructor(
  private contributionService : ContributionService
 ){}

 ngOnInit(): void {
   this.contributionService.GetAllContribution().subscribe((result) => {
    this.dataSource = new MatTableDataSource(result);
   })
 }

 
}
