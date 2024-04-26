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
  showDashboardTab = false;
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
            const activeTab = sessionStorage.getItem('activeTab');
            if (activeTab) {
            this.showProfileTab = activeTab === 'profile';
            this.showDocumentsTab = activeTab === 'documents';
            this.showMyDocumentsTab = activeTab === 'myDocuments';
            this.showDashboardTab = activeTab === 'dashboard';
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
    this.showDashboardTab = false;
    sessionStorage.setItem('activeTab', 'profile');

  }

  showDocuments() {
    this.showProfileTab = false;
    this.showDocumentsTab = true;
    this.showMyDocumentsTab = false;
    this.showDashboardTab = false;
    sessionStorage.setItem('activeTab', 'documents');

  }

  showMyDocuments(){
    this.showProfileTab = false;
    this.showDocumentsTab = false;
    this.showMyDocumentsTab = true;
    this.showDashboardTab = false;
    sessionStorage.setItem('activeTab', 'myDocuments');

  }
  showDashboard(){
    this.showProfileTab = false;
    this.showDocumentsTab = false;
    this.showMyDocumentsTab = false;
    this.showDashboardTab = true;
    sessionStorage.setItem('activeTab', 'dashboard');

  }
  isActiveTab(tabName: string): boolean {
    const activeTab = sessionStorage.getItem('activeTab');
    return activeTab === tabName;
  }
}
