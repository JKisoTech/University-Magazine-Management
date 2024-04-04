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
import { StudentPageComponent } from './Student/student-page/student-page.component';
import { MarketingCordinatorPageComponent } from './Marketing-Cordinator/marketing-cordinator-page/marketing-cordinator-page.component';
import { ManagerPageComponent } from './Manager/manager-page/manager-page.component';
import { HeaderMarketingCordinatorComponent } from './Marketing-Cordinator/header-marketing-cordinator/header-marketing-cordinator.component';
import { ContributionMarketingCordinatorComponent } from './Marketing-Cordinator/contribution-marketing-cordinator/contribution-marketing-cordinator.component';
import { UserLoginComponent } from './user-login/user-login.component';


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
    StudentPageComponent,
    MarketingCordinatorPageComponent,
    ManagerPageComponent,
    HeaderMarketingCordinatorComponent,
    ContributionMarketingCordinatorComponent,
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
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
