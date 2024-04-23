import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../API/Admin/User/user.service';
import { AuthenticationService } from '../API/authentication.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {

  @Output() loginSuccess: EventEmitter<void> = new EventEmitter<void>();

  loggedInUserName: string | null = null; // Variable to store the logged-in user's name
  userRole$: Observable<number | null>;
  userRole: number | null = null; // Variable to store the user role
  isLoggedIn$: Observable<boolean>; // Observable to track login status


  constructor(private userService: UserService, private authService: AuthenticationService ,
    private router : Router,
  ) { }

  ngOnInit(): void {
    this.isLoggedIn$ = this.authService.isLoggedIn$; // Assign the Observable to isLoggedIn$
    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      if (isLoggedIn) {
        // If user is logged in, fetch the user role and name
        this.fetchUserRole();
        this.loggedInUserName = this.authService.getLoggedInUserName();
      } else {
        // If user is not logged in, reset user role and name
        this.loggedInUserName = null;
      }
    });
  }

  fetchUserRole(): void {
    const loginName: string | null = this.authService.getLoggedInUserName();
    console.log('Login name:', loginName); // Debug message
    if (loginName) {
      this.userRole$ = this.userService.GetUserRole(loginName);
    } else {
      console.error('Failed to fetch user role: Login name not available');
      
    }
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']); // Redirect to the home page
  }

}
