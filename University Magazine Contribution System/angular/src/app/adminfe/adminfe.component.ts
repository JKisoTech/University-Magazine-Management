import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../API/authentication.service';
import { UserService } from '../API/Admin/User/user.service';
import { FalcutyService } from '../API/Admin/falcuty/falcuty.service';
import { UserDto } from '../API/Admin/User/model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-adminfe',
  templateUrl: './adminfe.component.html',
  styleUrl: './adminfe.component.scss'
})
export class AdminfeComponent implements OnInit {

  user: UserDto | null = null;

  showUserControllerTab = true;
  showDasboardTab = false;
  showDocumentsTab = false;
  showFacultyTab = false;
  showStudentTab = false;
  isLoggedIn$: Observable<boolean>; // Observable to track login status
  loggedInUserName: string | null = null; // Variable to store the logged-in user's name


  constructor(
    private authService: AuthenticationService, private userService : UserService,
    private facultyService : FalcutyService,
    private router : Router
  ){}

  ngOnInit(): void {
    this.isLoggedIn$ = this.authService.isLoggedIn$; 
    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      if (isLoggedIn) {
        // If user is logged in, fetch the user role and name
        this.loggedInUserName = this.authService.getLoggedInUserName();
      } else {
        // If user is not logged in, reset user role and name
        this.loggedInUserName = null;
      }
    });
  }


  showUserController() {
    this.showUserControllerTab = true;
    this.showDasboardTab = false;
    this.showDocumentsTab = false;
    this.showFacultyTab = false;
    this.showStudentTab = false;
    sessionStorage.setItem('activeTab', 'usercontroller');

  }

  showDocuments() {
    this.showUserControllerTab = false;
    this.showDasboardTab = false;
    this.showDocumentsTab = true;
    this.showFacultyTab = false;
    this.showStudentTab = false;
    sessionStorage.setItem('activeTab', 'documents');

  }

  showDashboard(){
    this.showUserControllerTab = false;
    this.showDasboardTab = true;
    this.showDocumentsTab = false;
    this.showFacultyTab = false;
    this.showStudentTab = false;
    sessionStorage.setItem('activeTab', 'dashboard');

  }
  showFacultyManagement(){
    this.showUserControllerTab = false;
    this.showDasboardTab = false;
    this.showDocumentsTab = false;
    this.showFacultyTab = true;
    this.showStudentTab = false;
    sessionStorage.setItem('activeTab', 'faculty');
  }
  showStudentManagement(){
    this.showUserControllerTab = false;
    this.showDasboardTab = false;
    this.showDocumentsTab = false;
    this.showFacultyTab = false;
    this.showStudentTab = true;
    sessionStorage.setItem('activeTab', 'student');
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']); // Redirect to the home page
  }

  isActiveTab(tabName: string): boolean {
    const activeTab = sessionStorage.getItem('activeTab');
    return activeTab === tabName;
  }

}
