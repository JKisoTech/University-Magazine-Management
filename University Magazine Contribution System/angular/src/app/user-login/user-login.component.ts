import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../API/Admin/User/user.service';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {

  username: string;
  password: string;

  constructor(private router: Router, private userService: UserService) {}


  login() {
    // Simulate authentication (replace with actual logic)
    if (this.username === 'cordinator123' && this.password === '123456') {
        // Fetch user details (assuming you have a GetUserByUsername method in your UserService)
        this.userService.GetUserId(2).subscribe(
            (user: any) => {
                const userRole = user.role; // Assuming your user object has a 'role' property
                // Redirect based on user role
                switch (userRole) {
                    case 'Student':
                        this.router.navigate(['/student']);
                        break;
                    case 'Cordinator':
                        this.router.navigate(['/marketing-cordinator']);
                        break;
                    case 'Admin':
                        this.router.navigate(['/admin']);
                        break;
                    default:
                        // Handle other roles or unexpected cases
                        break;
                }
            },
            (error) => {
                console.error('Error fetching user details:', error);
            }
        );
    } else {
        // Invalid credentials
        alert('Invalid username or password. Please try again.');
    }
}

}
