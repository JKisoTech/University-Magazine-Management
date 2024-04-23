import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { UserDto } from '../../../API/Admin/User/model';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-my-document',
  templateUrl: './student-my-document.component.html',
  styleUrl: './student-my-document.component.scss'
})
export class StudentMyDocumentComponent implements OnInit {

  user: UserDto ;
  contributions: ContributionDto[] = [];

  constructor(
    private authService: AuthenticationService, 
    private userService : UserService,
    private studentService: StudentService,
    private contributionService: ContributionService,
    private router : Router,
  ){}

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
          this.contributionService.GetContributor().subscribe((result) => {
            this.contributions = result.filter(
              (contribution: ContributionDto) => contribution.studentID === this.user.loginName
            );
          },
          (error) => {
            console.error('Failed to fetch contributions:', error);
          });
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
  }
  confirmPublic(contribution: ContributionDto): void {
    const confirmed = confirm('Are you sure you want to make this contribution public?');
    if (confirmed) {
      contribution.status = 2; // Update the status to 2 (Public)
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
  
  viewContribution(contributionID: string) {
    this.router.navigate(['/contribution', contributionID]);
  }

}
