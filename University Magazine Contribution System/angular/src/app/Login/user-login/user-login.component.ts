import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../API/Admin/User/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.scss'
})
export class UserLoginComponent{

  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, private userService: UserService) {
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

  const loginName = this.form.get('loginName')?.value; // Add null check
  const password = this.form.get('password')?.value; // Add null check

  if (!loginName || !password) {
      // Handle missing loginName or password
      console.error('Login failed: Missing loginName or password');
      return;
  }

  this.userService.UserLogin(loginName, password).subscribe(
      (response) => {
        
          // Handle successful login (store token, navigate, etc.)
          console.log('Login successful:', response);
          // Example: Redirect to dashboard
          this.router.navigate(['/']);
      },
      (error) => {
          // Handle login error (display error message, etc.)
          console.error('Login failed:', error);
      }
  );
}
}
