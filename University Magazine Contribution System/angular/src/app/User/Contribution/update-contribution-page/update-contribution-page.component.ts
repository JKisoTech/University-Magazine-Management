import { Component, Inject, OnInit } from '@angular/core';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { UserDto } from '../../../API/Admin/User/model';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-update-contribution-page',
  templateUrl: './update-contribution-page.component.html',
  styleUrl: './update-contribution-page.component.scss'
})
export class UpdateContributionPageComponent implements OnInit {

  formGroup: FormGroup;
  user: UserDto;
  selectedFile: File | null = null;
  contribution: ContributionDto;

  constructor(
    private contributionService: ContributionService,
    private fb: FormBuilder,
    private userService : UserService,
    private authService: AuthenticationService,
    private route : ActivatedRoute,
    private router : Router,
    

  ){}

  ngOnInit(): void {
    this.buildForm();

    this.route.params.subscribe(params => {
      const contributionId = params['id'];
      if (contributionId) {
        this.contributionService.GetContributionbyId(contributionId).subscribe(
          (contribution) => {
            this.contribution = contribution; // Assign the contribution data
            this.populateForm(contribution);
          },
          (error) => {
            console.error('Failed to fetch contribution data:', error);
          }
        );
      }
    });
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
        id: ['', [Validators.required]],
        content: ['', [Validators.required]],
        title: ['', [Validators.required]],
        description: ['', [Validators.required]],
        type: ['', Validators.required],
    });
}
populateForm(contribution: ContributionDto) {
  this.formGroup.patchValue({
    id: contribution.contributionID,
    content: contribution.content,
    title: contribution.title,
    description: contribution.description,
  });
}
submitForm() {
  const id = this.formGroup.get('id')?.value;
  const content = this.formGroup.get('content')?.value;
  const title = this.formGroup.get('title')?.value;
  const description = this.formGroup.get('description')?.value;

  if (!this.selectedFile) {
    console.error('No file selected');
    return;
  }
  if (this.user && this.user.loginName) {
    const contributionData: ContributionDto = {
      contributionID: id,
      studentID: this.user.loginName,
      content: content,
      status: 1,
      title: title,
      description: description,
      type: this.selectedFile ? this.selectedFile.name : ''
    };

    this.contributionService.UpdateContributor(contributionData, this.selectedFile).subscribe(
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
