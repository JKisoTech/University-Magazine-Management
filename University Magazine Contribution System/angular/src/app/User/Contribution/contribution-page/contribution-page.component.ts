import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { Observable } from 'rxjs';
import { UserDto } from '../../../API/Admin/User/model';
import { UploadContributionPageComponent } from '../upload-contribution-page/upload-contribution-page.component';
import { MatDialog } from '@angular/material/dialog';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
@Component({
  selector: 'app-contribution-page',
  templateUrl: './contribution-page.component.html',
  styleUrl: './contribution-page.component.scss'
})

export class ContributionPageComponent implements OnInit {
  
  user: UserDto | null = null;
  contribution: ContributionDto | null = null;
  contributionId: string | null = null;

  constructor(private authService: AuthenticationService, private userService : UserService,
    private dialog: MatDialog,
    private contributionService: ContributionService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
    this.route.params.subscribe(params => {
      this.contributionId = params['id'];
      if (this.contributionId) {
        this.contributionService.GetContributorId(this.contributionId).subscribe(
          (contribution) => {
            this.contribution = contribution;
          },
          (error) => {
            console.error('Failed to fetch contribution data:', error);
          }
        );
      }
    });
  }

}

  




