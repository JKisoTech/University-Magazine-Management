import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../API/Admin/User/user.service';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../API/authentication.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.scss'
})
export class UserLoginComponent{
    @Output() loginSuccess: EventEmitter<void> = new EventEmitter<void>();


  form: FormGroup;

  constructor(private formBuilder: FormBuilder,    private authService: AuthenticationService  // Inject AuthenticationService
  , private router: Router, private userService: UserService) {
    this.form = this.formBuilder.group({
        loginName: ['', Validators.required],
        password: ['', Validators.required],
    });
}


login(): void {
  if (this.form.invalid) {
    // Handle form validation errors (display messages, etc.)
    return;
  }

  const loginName = this.form.get('loginName')?.value;
  const password = this.form.get('password')?.value;

  if (!loginName || !password) {
    console.error('Login failed: Missing loginName or password');
    return;
  }

  this.userService.UserLogin(loginName, password).subscribe(
    () => {
      // Emit event upon successful login
      this.authService.setLoggedIn(true, loginName);
      this.loginSuccess.emit();
      // Handle successful login (store token, navigate, etc.)
      console.log('Login successful');
      this.router.navigate(['/contribution']); // Redirect to dashboard or desired route
    },
    (error) => {
      // Handle login error (display error message, etc.)
      console.error('Login failed:', error);
    }
  );
}
}
