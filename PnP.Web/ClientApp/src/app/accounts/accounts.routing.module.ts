import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';
import { NoAuthGuard } from '../_guards/no.auth.guard';
import { AdminAuthGuard } from '../_guards/admin.auth.guard';

import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

const routes: Routes = [
  { path: 'signin', component: SigninComponent, canActivate: [NoAuthGuard] },
  { path: 'signup', component: SignupComponent, canActivate: [NoAuthGuard] },
  { path: 'userinfo', component: UserInfoComponent, canActivate: [AuthGuard] },
  { path: 'changepassword', component: ChangePasswordComponent, canActivate: [AuthGuard] },
  { path: 'forgotpassword', component: ForgotPasswordComponent, canActivate: [NoAuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsRoutingModule { }
