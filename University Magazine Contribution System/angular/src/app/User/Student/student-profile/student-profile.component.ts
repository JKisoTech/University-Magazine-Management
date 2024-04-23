import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserDto } from '../../../API/Admin/User/model';
import { StudentDTO } from '../../../API/Admin/Student/model';

@Component({
  selector: 'app-student-profile',
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {

  user: UserDto;
  student: StudentDTO;
  constructor(
    private studentService: StudentService,
    private userService: UserService,
    private authService : AuthenticationService,

  ){}

  ngOnInit(): void {
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
  

}
