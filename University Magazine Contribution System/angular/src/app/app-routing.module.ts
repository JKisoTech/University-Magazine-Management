import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserManagementComponent } from './Admin/user-management/user-management.component';
import { LandingPageUserComponent } from './User/landing-page-user/landing-page-user.component';
import { FalcutyComponent } from './Admin/falcuty/falcuty.component';
import { UserLoginComponent } from './Login/user-login/user-login.component';
import { ContributionPageComponent } from './User/Contribution/contribution-page/contribution-page.component';
import { HeaderComponent } from './header/header.component';
import { ContributionManagementComponent } from './Admin/Contribution/contribution-management/contribution-management.component';
import { AuthenticationGuard } from './authentication.guard';
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { ViewAllContributionComponent } from './User/Contribution/view-all-contribution/view-all-contribution.component';
import { UpdateContributionPageComponent } from './User/Contribution/update-contribution-page/update-contribution-page.component';
import { UploadContributionPageComponent } from './User/Contribution/upload-contribution-page/upload-contribution-page.component';
import { StudentManagementComponent } from './Admin/Student/student-management/student-management.component';
import { StudentProfileComponent } from './User/Student/student-profile/student-profile.component';
import { StudentViewDocumentComponent } from './User/Student/student-view-document/student-view-document.component';


const routes: Routes = [
  { path: '', component: LandingPageUserComponent}, 
  {path: 'usermanagement', component: UserManagementComponent},
  { path : 'falcuty', component: FalcutyComponent},
  { path : 'userlogin', component: UserLoginComponent},
  { path: 'contribution/:id', component: ContributionPageComponent, canActivate: [AuthenticationGuard]},
  { path: 'contribution-management', component: ContributionManagementComponent},
  { path: 'user-profile', component: UserProfileComponent},
  { path: 'view-all-contribution', component: ViewAllContributionComponent},
  { path : 'upload-contribution', component: UploadContributionPageComponent},
  { path: 'admin/studentmanagement', component : StudentManagementComponent},
  { path: 'student-profile', component: StudentProfileComponent},
  { path: 'student-view-document', component: StudentViewDocumentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
