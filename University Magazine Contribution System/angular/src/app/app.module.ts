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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { ContributionPageComponent } from './User/Contribution/contribution-page/contribution-page.component';
import { ContributionManagementComponent } from './Admin/Contribution/contribution-management/contribution-management.component';
import { AuthenticationService } from './API/authentication.service';
import { AuthenticationGuard } from './authentication.guard';
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { UploadContributionPageComponent } from './User/Contribution/upload-contribution-page/upload-contribution-page.component';
import { ViewAllContributionComponent } from './User/Contribution/view-all-contribution/view-all-contribution.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { UpdateContributionPageComponent } from './User/Contribution/update-contribution-page/update-contribution-page.component';
import { StudentManagementComponent } from './Admin/Student/student-management/student-management.component';
import { CreateStudentFormComponent } from './Admin/Student/create-student-form/create-student-form.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { StudentProfileComponent } from './User/Student/student-profile/student-profile.component';
import { SideBarComponent } from './User/Student/side-bar/side-bar.component';
import { StudentViewDocumentComponent } from './User/Student/student-view-document/student-view-document.component';


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
    UserLoginComponent,
    ContributionPageComponent,
    ContributionManagementComponent,
    UserProfileComponent,
    UploadContributionPageComponent,
    ViewAllContributionComponent,
    UpdateContributionPageComponent,
    StudentManagementComponent,
    CreateStudentFormComponent,
    StudentProfileComponent,
    SideBarComponent,
    StudentViewDocumentComponent

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
    MatCheckboxModule,
    FormsModule,
    ReactiveFormsModule,
    PdfViewerModule
    
  ],
  providers: [
    provideAnimationsAsync(),
    AuthenticationService,
    AuthenticationGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
