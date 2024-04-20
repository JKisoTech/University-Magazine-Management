import { Component, Inject, OnInit } from '@angular/core';
import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
import { ContributionDto } from '../../../API/Admin/Contribution/model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { UserDto } from '../../../API/Admin/User/model';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-update-contribution-page',
  templateUrl: './update-contribution-page.component.html',
  styleUrl: './update-contribution-page.component.scss'
})
export class UpdateContributionPageComponent implements OnInit {

  formGroup: FormGroup;
  user: UserDto | null = null;
  selectedFile: File | null = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private contributionService: ContributionService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<UpdateContributionPageComponent>,
    private userService : UserService,
    private authService: AuthenticationService,
    

  ){}

  ngOnInit(): void {
    this.buildForm();

    const contributionId = this.data.contributionId;
    if (contributionId) {
      this.contributionService.GetContent(contributionId).subscribe(
        (contribution) => {
          this.populateForm(contribution);
        },
        (error) => {
          console.error('Failed to fetch contribution data:', error);
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

  const contributionData: ContributionDto = {
    contributionID: id,
    studentID: id,
    content: content,
    status: 0,
    title: title,
    description: description,
    type: this.selectedFile.name
  };

  this.contributionService.UpdateContributor(contributionData, this.selectedFile).subscribe(
    (response) => {
       // Log the response
      this.dialogRef.close();
    },
    (error) => {
      // Handle the error here
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
