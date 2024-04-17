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


const routes: Routes = [
  { path: '', component: LandingPageUserComponent}, 
  {path: 'usermanagement', component: UserManagementComponent},
  { path : 'falcuty', component: FalcutyComponent},
  { path : 'userlogin', component: UserLoginComponent},
  { path: 'contribution', component: ContributionPageComponent, canActivate: [AuthenticationGuard]},
  { path: 'contribution-management', component: ContributionManagementComponent},
  { path: 'user-profile', component: UserProfileComponent},
  { path: 'view-all-contribution', component: ViewAllContributionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
