import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserManagementComponent } from './Admin/user-management/user-management.component';
import { LandingPageUserComponent } from './User/landing-page-user/landing-page-user.component';
import { FalcutyComponent } from './Admin/falcuty/falcuty.component';

const routes: Routes = [
  { path: '', component: LandingPageUserComponent}, 
  {path: 'usermanagement', component: UserManagementComponent},
  { path : 'falcuty', component: FalcutyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
