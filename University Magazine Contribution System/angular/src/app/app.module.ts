import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserManagementComponent } from './Admin/user-management/user-management.component';
import { Header2Component } from './Admin/header/header.component';
import { LandingPageUserComponent } from './User/landing-page-user/landing-page-user.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CreateFormUserComponent } from './Admin/user-management/create-form-user/create-form-user.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { FalcutyComponent } from './Admin/falcuty/falcuty.component';
import { EditFormUserComponent } from './Admin/user-management/edit-form-user/edit-form-user.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { EditFormFalcutyComponent } from './Admin/falcuty/edit-form-falcuty/edit-form-falcuty.component';
import { CreateFormFalcutyComponent } from './Admin/falcuty/create-form-falcuty/create-form-falcuty.component';
import { UserLoginComponent } from './Login/user-login/user-login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LandingPageComponent,
    UserManagementComponent,
    Header2Component,
    LandingPageUserComponent,
    CreateFormUserComponent,
    FalcutyComponent,
    EditFormUserComponent,
    EditFormFalcutyComponent,
    CreateFormFalcutyComponent,
    UserLoginComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTableModule,
    HttpClientModule,
    MatButtonModule,
    MatDialogModule,
    MatMenuModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule
    
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
