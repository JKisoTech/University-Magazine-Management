import { Component, OnInit } from '@angular/core';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { UserDto } from '../../../API/Admin/User/model';
import { FalcutyService } from '../../../API/Admin/falcuty/falcuty.service';

@Component({
  selector: 'app-student-documents',
  templateUrl: './student-documents.component.html',
  styleUrl: './student-documents.component.scss'
})
export class StudentDocumentsComponent implements OnInit {


  contribution: ContributionDto[] = [];
  user: UserDto;
  constructor(
    private contributionService: ContributionService,
    private router : Router,
    private authService: AuthenticationService,
    private userService: UserService,
    private facultyService: FalcutyService

  ){}

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
          if (this.user.role === 2) {
            const facultyID = this.user.facultyID;
            if (facultyID) {
              this.facultyService.GetContributionbyFaculty(facultyID).subscribe(
                (result) => {
                  this.contribution = result;
                },
                (error) => {
                  console.error('Failed to fetch contributions:', error);
                }
              );
            } else {
              console.error('Faculty ID is undefined.');
            }
          } else if (this.user.role === 3) {
            this.contributionService.GetContributor().subscribe(
              (result) => {
                this.contribution = result;
              },
              (error) => {
                console.error('Failed to fetch contributions:', error);
              }
            );
          } else if (this.user.role === 1) {
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
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
  }
  viewContribution(contributionID: string) {
    this.router.navigate(['/contribution', contributionID]);
  }
  confirmApprove(contribution: ContributionDto): void {
    if (contribution.status !== 2) {
      alert('Contribution still not public by Student.');
      return;
    }
  
    const confirmed = confirm('Are you sure you want to make this contribution Approve?');
    if (confirmed) {
      contribution.status = 3;
      this.contributionService.UpdateContributorStatus(contribution).subscribe(
        () => {
          // Status updated successfully
          console.log('Contribution status updated successfully.');
        },
        (error) => {
          console.error('Failed to update contribution status:', error);
        }
      );
    }
  }

}
