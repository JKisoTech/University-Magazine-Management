import { Component, OnInit } from '@angular/core';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { MatDialogRef } from '@angular/material/dialog';
import { UserDto } from '../../../API/Admin/User/model';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';

import { convert } from 'libreoffice-convert';
import { Router } from '@angular/router';




@Component({
  selector: 'app-upload-contribution-page',
  templateUrl: './upload-contribution-page.component.html',
  styleUrls: ['./upload-contribution-page.component.scss'],
})
export class UploadContributionPageComponent implements OnInit{

  formGroup: FormGroup;
  user: UserDto ;
  selectedFile: File ;
   baseUrl = 'https://localhost:7101/api/Contribution';
   





  constructor(
    private contributionService: ContributionService,
    private fb: FormBuilder,
    private userService : UserService,
    private authService: AuthenticationService,
    private router: Router,
    

  ){}

  ngOnInit(): void {
    this.buildForm();
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
          this.formGroup.patchValue({
            user_id: this.user.loginName
          });
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
  }
  buildForm() {
    this.formGroup = this.fb.group({
        content: ['', [Validators.required]],
        title: ['', [Validators.required]],
        description: ['', [Validators.required]],
        type: ['', Validators.required],
    });
}

submitForm() {
  const content = this.formGroup.get('content')?.value;
  const title = this.formGroup.get('title')?.value;
  const description = this.formGroup.get('description')?.value;

  // Check if user_id is available
  if (this.user && this.user.loginName) {
    const contributionData: ContributionDto = {
      contributionID: '',
      studentID: this.user.loginName,
      content: content,
      status: 0,
      title: title,
      description: description,
      type: this.selectedFile ? this.selectedFile.name : ''
    };

    this.contributionService.PostContribution(contributionData, this.selectedFile).subscribe(
      (response) => {
        this.router.navigate(['/student-page']);
      },
      (error) => {
        console.error('Error submitting contribution:', error);
      }
    );
  } else {
    console.error('User loginName not available.');
  }
}

  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }
 
}
