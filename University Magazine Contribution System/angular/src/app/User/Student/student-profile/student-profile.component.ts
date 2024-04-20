import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../../API/Admin/Student/student.service';
import { AuthenticationService } from '../../../API/authentication.service';
import { UserService } from '../../../API/Admin/User/user.service';
import { StudentDTO } from '../../../API/Admin/Student/model';

@Component({
  selector: 'app-student-profile',
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {

  student: StudentDTO | null = null;

  constructor(
    private studentSerivce : StudentService,
    private authService: AuthenticationService, 
    private userService : UserService,
  ){}

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName){
      this.studentSerivce.GetStudentById(loggedInUserName).subscribe((response) => {
        this.student = response;
      })
    }
  }
}
