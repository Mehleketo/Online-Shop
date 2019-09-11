import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountsRoutingModule } from './accounts.routing.module';

import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AccountsRoutingModule
  ],
  declarations: [
    SignupComponent,
    SigninComponent,
    UserInfoComponent,
    ChangePasswordComponent,
    ForgotPasswordComponent
  ]
})
export class AccountsModule { }
