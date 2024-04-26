  import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
  import { AuthenticationService } from '../../../API/authentication.service';
  import { UserService } from '../../../API/Admin/User/user.service';
  import { Observable } from 'rxjs';
  import { UserDto } from '../../../API/Admin/User/model';
  import { UploadContributionPageComponent } from '../upload-contribution-page/upload-contribution-page.component';
  import { MatDialog } from '@angular/material/dialog';
  import { ContributionService } from '../../../API/Admin/Contribution/contribution.service';
  import { ActivatedRoute, Router } from '@angular/router';
  import { ContributionDto } from '../../../API/Admin/Contribution/model';
  import { StudentService } from '../../../API/Admin/Student/student.service';
  import { StudentDTO } from '../../../API/Admin/Student/model';
  import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
  import Docx from 'docx';
  import { PDFDocument } from 'pdf-lib';
import { CommentDTO } from '../../../API/Admin/Contribution/commentDTO';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';





  @Component({
    selector: 'app-contribution-page',
    templateUrl: './contribution-page.component.html',
    styleUrl: './contribution-page.component.scss'
  })

  export class ContributionPageComponent implements OnInit {
    
    

    user: UserDto | null = null;
    contribution: ContributionDto | null = null;
    contributionId: string ;
    student: StudentDTO | null = null;
    pdfSrc: SafeResourceUrl | null = null;
  studentId: string | undefined ;
  comments: CommentDTO[] = [] ;
  formGroup : FormGroup;

    constructor(private authService: AuthenticationService, private userService : UserService,
      private dialog: MatDialog,
      private contributionService: ContributionService,
      private route: ActivatedRoute,
      private studentService: StudentService,
      private sanitizer: DomSanitizer,
      private changeDetectorRef: ChangeDetectorRef,
      private fb : FormBuilder,

      private router: Router
    ) { }

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
    
      this.route.params.subscribe(params => {
        this.contributionId = params['id'];
        if (this.contributionId) {
          this.contributionService.GetContent(this.contributionId).subscribe(
            (pdfContent) => {
              const pdfUrl = `https://localhost:7101/api/Contribution/GetContent?Id=${this.contributionId}`;
              this.pdfSrc = this.sanitizer.bypassSecurityTrustResourceUrl(pdfUrl);
            },
            (error) => {
              console.error('Failed to fetch PDF content:', error);
            }
          );
    
          this.contributionService.GetContributionbyId(this.contributionId).subscribe(
            (response) => {
              this.contribution = response;
              const studentId = this.contribution?.studentID; // Retrieve studentID from contribution
              if (studentId) {
                // Fetch student data using studentID
                this.studentService.GetStudentById(studentId).subscribe(
                  (studentResponse) => {
                    this.student = studentResponse;
                  },
                  (error) => {
                    console.error('Failed to fetch student data:', error);
                  }
                );
              }
              this.contributionService.GetComments(this.contributionId).subscribe(
                (response) => {
                  this.comments = response;
                  console.log(response);
                },
                (error) => {
                  console.error('Failed to fetch comments:', error);
                }
              );
            },

            (error) => {
              console.error('Failed to fetch contribution data:', error);
            }
          );
        }
      });
    }

    buildForm(){
      this.formGroup = this.fb.group({
        title: ['', [Validators.required]],
        comment: ['', [Validators.required]],
      })
    }

    commentForm() {
      const title = this.formGroup.get('title')?.value;
      const comment = this.formGroup.get('comment')?.value;
  
      if (this.user && this.user.loginName) {
        const commentData: CommentDTO = {
          coordinatorID: this.user.loginName,
          contributionID: this.contribution?.contributionID || '',
          title: title,
          comments: comment,
          commentDate: '',
        };
  
        this.contributionService.UpdateComment(commentData).subscribe(
          (response) => {
            this.router.navigate(['/contribution', this.contributionId]);
          },
          (error) => {
            console.error('Error submitting comment:', error);
          }
        );
      } else {
        console.error('User loginName not available.');
      }
    }
    

   
    
    

  }

    




