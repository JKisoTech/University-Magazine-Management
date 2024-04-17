import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../API/Admin/User/user.service';
import { AuthenticationService } from '../API/authentication.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {

  @Output() loginSuccess: EventEmitter<void> = new EventEmitter<void>();


  userRole$: Observable<number | null>;
  userRole: number | null = null; // Variable to store the user role


  constructor(private userService: UserService, private authService: AuthenticationService) { }

  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      if (isLoggedIn) {
        // If user is logged in, fetch the user role
        this.fetchUserRole();
      } else {
        // If user is not logged in, reset user role
     
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

  logout() {
    this.authService.logout();
  }

}
