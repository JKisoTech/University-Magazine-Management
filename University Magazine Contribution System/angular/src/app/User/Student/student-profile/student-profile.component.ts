import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserDto } from '../../../API/Admin/User/model';
import { StudentDTO } from '../../../API/Admin/Student/model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-profile',
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {

  user: UserDto;
  student: StudentDTO;
  showPasswordChangeForm: boolean = false; // Flag to control display of the password change form
  oldPassword: string = '';
  newPassword: string = '';
  confirmPassword: string = '';
  passwordChangeForm: FormGroup;
  errorMessage: string = '';


  constructor(
    private studentService: StudentService,
    private userService: UserService,
    private authService : AuthenticationService,
    private formBuilder: FormBuilder,


  ){}

  ngOnInit(): void {
    this.buildPasswordChangeForm();
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe((result) => {
        this.user = result;
        if (this.user.role === 1 && this.user.loginName) {
          this.getStudentById(this.user.loginName);
        }
      })
    }
 
  }
  getStudentById(id: string): void {
    this.studentService.GetStudentById(id).subscribe((response) => {
      this.student = response;
      // Handle the student data here
      console.log(response);
    });
  }

  openPasswordChangeForm(): void {
    this.showPasswordChangeForm = true;
  }
  buildPasswordChangeForm(): void {
    this.passwordChangeForm = this.formBuilder.group({
      oldPassword: ['', Validators.required],
      newPassword: ['', Validators.required],
    });
  }

  changePassword(): void {
    // Perform validation checks on the password inputs
    if (this.passwordChangeForm.invalid) {
      // Display an error message or handle the form validation errors
      return;
    }
  
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      const { oldPassword, newPassword } = this.passwordChangeForm.value;
      this.userService.ChangePassword(loggedInUserName, oldPassword, newPassword).subscribe(
        () => {
          this.errorMessage = 'Change Password Successfully';
          alert(this.errorMessage);
          this.showPasswordChangeForm = false; // Hide the password change form
          this.passwordChangeForm.reset(); // Reset the form
        },
        (error) => {
          // Handle the error (e.g., display an error message)
          console.error(error);
          this.errorMessage = 'Your Old password is wrong';
          alert(this.errorMessage);
        }
      );
    }
  }
  

}
