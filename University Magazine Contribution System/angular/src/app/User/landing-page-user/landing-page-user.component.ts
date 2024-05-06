import { Component, OnInit } from '@angular/core';
import { ContributionDto } from '../../API/Admin/Contribution/model';
import { ContributionService } from '../../API/Admin/Contribution/contribution.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page-user',
  templateUrl: './landing-page-user.component.html',
  styleUrl: './landing-page-user.component.scss'
})
export class LandingPageUserComponent implements OnInit {

  contribution: ContributionDto[] = [];

  constructor(
    private contributionService: ContributionService,
    private router : Router,

  ){}

  ngOnInit(): void {
    this.contributionService.GetContributor().subscribe(
      (result: ContributionDto[]) => { // Specify the type as ContributionDto[]
        // Filter contributions with status = 3
        this.contribution = result.filter((contribution: ContributionDto) => contribution.status === 3);
      },
      (error) => {
        console.error('Failed to fetch contributions:', error);
      }
    );
  }
  

}
