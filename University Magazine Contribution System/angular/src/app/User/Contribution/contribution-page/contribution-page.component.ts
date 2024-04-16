import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { Observable } from 'rxjs';
import { UserDto } from '../../../API/Admin/User/model';
import { UploadContributionPageComponent } from '../upload-contribution-page/upload-contribution-page.component';
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-contribution-page',
  templateUrl: './contribution-page.component.html',
  styleUrl: './contribution-page.component.scss'
})

export class ContributionPageComponent implements OnInit {
  
  user: UserDto | null = null;


  constructor(private authService: AuthenticationService, private userService : UserService,
    private dialog: MatDialog,

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

  }

  



}
