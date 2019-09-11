import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';
import { NoAuthGuard } from '../_guards/no.auth.guard';
import { AdminAuthGuard } from '../_guards/admin.auth.guard';

import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: 'admin/dashboard', component: DashboardComponent, canActivate: [AdminAuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
