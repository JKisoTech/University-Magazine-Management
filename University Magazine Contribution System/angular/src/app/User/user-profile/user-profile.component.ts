import { Component, OnInit } from '@angular/core';
import { UserService } from '../../API/Admin/User/user.service';
import { UserDto } from '../../API/Admin/User/model';
import { AuthenticationService } from '../../API/authentication.service';





@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent implements OnInit {

  user: UserDto | null = null;


  constructor(
    private userService: UserService,
    private authService: AuthenticationService
  ) {}

  ngOnInit() {
    const loggedInUserName = this.authService.getLoggedInUserName();
    if (loggedInUserName) {
      this.userService.GetUserByLoginName(loggedInUserName).subscribe(
        (response) => {
          this.user = response;
        },
        (error) => {
          console.error('Failed to fetch user data:', error);
        }
      );
    }
  }


}
