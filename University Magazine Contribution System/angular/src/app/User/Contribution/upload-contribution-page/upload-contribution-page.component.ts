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




@Component({
  selector: 'app-upload-contribution-page',
  templateUrl: './upload-contribution-page.component.html',
  styleUrls: ['./upload-contribution-page.component.scss'],
})
export class UploadContributionPageComponent implements OnInit{

  formGroup: FormGroup;
  user: UserDto | null = null;
  selectedFile: File ;
   baseUrl = 'https://localhost:7101/api/Contribution';
   





  constructor(
    private contributionService: ContributionService,
    private fb: FormBuilder,
    private userService : UserService,
    private authService: AuthenticationService,
    

  ){}

  ngOnInit(): void {
    this.buildForm();
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
  buildForm() {
    this.formGroup = this.fb.group({
        user_id: ['', [Validators.required]],
        content: ['', [Validators.required]],
        title: ['', [Validators.required]],
        description: ['', [Validators.required]],
        type: ['', Validators.required],
    });
}

submitForm() {
  const user_id = this.formGroup.get('user_id')?.value;
  const content = this.formGroup.get('content')?.value;
  const title = this.formGroup.get('title')?.value;
  const description = this.formGroup.get('description')?.value;

  const contributionData: ContributionDto = {
      contributionID: user_id,
      studentID: user_id,
      content: content,
      status: 0,
      title: title,
      description: description,
      type: this.selectedFile ? this.selectedFile.name : ''
  };

  this.contributionService.PostContribution(contributionData, this.selectedFile ).subscribe(
      (response) => {
        this.ngOnInit();
      },
      (error) => {
        console.error('Error submitting contribution:', error);

      }
  );
}

  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }
 
}
