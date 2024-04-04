import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserManagementComponent } from './Admin/user-management/user-management.component';
import { LandingPageUserComponent } from './User/landing-page-user/landing-page-user.component';
import { FalcutyComponent } from './Admin/falcuty/falcuty.component';
import { MarketingCordinatorPageComponent } from './Marketing-Cordinator/marketing-cordinator-page/marketing-cordinator-page.component';
import { ContributionMarketingCordinatorComponent } from './Marketing-Cordinator/contribution-marketing-cordinator/contribution-marketing-cordinator.component';
import { UserLoginComponent } from './user-login/user-login.component';

const routes: Routes = [
  { path: '', component: LandingPageUserComponent}, 
  {path: 'usermanagement', component: UserManagementComponent},
  { path : 'falcuty', component: FalcutyComponent},
  { path : 'marketing-cordinator', component: MarketingCordinatorPageComponent},
  { path: 'contribution-marketing-cordinator', component: ContributionMarketingCordinatorComponent},
  { path : 'user-login', component: UserLoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
