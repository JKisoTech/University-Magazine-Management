import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../API/authentication.service';
import { UserService } from '../../API/Admin/User/user.service';
import { UserDto } from '../../API/Admin/User/model';
import { FacultyDTO } from '../../API/Admin/falcuty/model';
import { FalcutyService } from '../../API/Admin/falcuty/falcuty.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrl: './student.component.scss'
})
export class StudentComponent implements OnInit{

    studentId: string | undefined;
    userRole: number;

  user: UserDto | null = null;
  showProfileTab = true;
  showDocumentsTab = false;
  showMyDocumentsTab = false;
  faculties: FacultyDTO[] = [];


  constructor(
    private authService: AuthenticationService, private userService : UserService,
    private facultyService : FalcutyService,
  ){}

  ngOnInit(): void {
    const loggedInUserName = this.authService.getLoggedInUserName();
      if (loggedInUserName) {
        this.userService.GetUserByLoginName(loggedInUserName).subscribe(
          (response) => {
            this.user = response;
            
            if (this.user?.role !== 1) {
              this.showMyDocumentsTab = false; // Hide "My Documents" tab if user's role is not 1
            }
          },
          (error) => {
            console.error('Failed to fetch user data:', error);
          }
        );
      }
      this.facultyService.GetAllFalcuty().subscribe(
        (faculties) => {
          this.faculties = faculties;
        },
        (error) => {
          console.error('Failed to fetch faculties:', error);
        }
      );
  }
  

  showProfile() {
    this.showProfileTab = true;
    this.showDocumentsTab = false;
    this.showMyDocumentsTab = false;
  }

  showDocuments() {
    this.showProfileTab = false;
    this.showDocumentsTab = true;
    this.showMyDocumentsTab = false;
  }

  showMyDocuments(){
    this.showProfileTab = false;
    this.showDocumentsTab = false;
    this.showMyDocumentsTab = true;
  }
}
