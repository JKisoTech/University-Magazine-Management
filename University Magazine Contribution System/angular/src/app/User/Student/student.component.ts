import { Component } from '@angular/core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrl: './student.component.scss'
})
<<<<<<< Updated upstream
export class StudentComponent{
=======
export class StudentComponent implements OnInit{

    studentId: string | undefined;
    userRole: number;

  user: UserDto | null = null;
  showProfileTab = true;
  showDocumentsTab = false;
  showMyDocumentsTab = false;
  showDashboardTab = false;
  faculties: FacultyDTO[] = [];

>>>>>>> Stashed changes

  constructor(

  ){}

<<<<<<< Updated upstream
  showProfileTab = true;
  showDocumentsTab = false;
=======
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
  
>>>>>>> Stashed changes

  showProfile() {
    this.showProfileTab = true;
    this.showDocumentsTab = false;
<<<<<<< Updated upstream
=======
    this.showMyDocumentsTab = false;
    this.showDashboardTab = false;
    sessionStorage.setItem('activeTab', 'profile')
>>>>>>> Stashed changes
  }

  showDocuments() {
    this.showProfileTab = false;
    this.showDocumentsTab = true;
<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
  }
}
