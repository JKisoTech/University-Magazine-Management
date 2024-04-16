import { Component, OnInit } from '@angular/core';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { MatDialogRef } from '@angular/material/dialog';
import { UserDto } from '../../../API/Admin/User/model';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-upload-contribution-page',
  templateUrl: './upload-contribution-page.component.html',
  styleUrls: ['./upload-contribution-page.component.scss'],
})
export class UploadContributionPageComponent implements OnInit{

  formGroup: FormGroup;
  user: UserDto | null = null;




  constructor(
    private contributionService: ContributionService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<UploadContributionPageComponent>,
    private userService : UserService,
    private authService: AuthenticationService

  ){}

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
          this.buildForm();
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
  }

  buildForm() {
    this.formGroup = this.fb.group({
      contributionID: ['', [Validators.required]],
      studentID: ['', [Validators.required]],
      status: [true, [Validators.required]],
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      type: ['', [Validators.required]],
    });
  }

  Save() {
    
  }
  
 
}
