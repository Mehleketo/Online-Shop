import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';
import { NoAuthGuard } from '../_guards/no.auth.guard';
import { AdminAuthGuard } from '../_guards/admin.auth.guard';

import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateDeliveryAddressComponent } from './addresses/create-delivery-address/create-delivery-address.component';
import { CreateUserAddressComponent } from './addresses/create-user-address/create-user-address.component';
import { EditDeliveryAddressComponent } from './addresses/edit-delivery-address/edit-delivery-address.component';
import { EditUserAddressComponent } from './addresses/edit-user-address/edit-user-address.component';
import { ManageDeliveryAddressesComponent } from './addresses/manage-delivery-addresses/manage-delivery-addresses.component';
import { ManageUserAddressesComponent } from './addresses/manage-user-addresses/manage-user-addresses.component';
import { ViewDeliveryAddressComponent } from './addresses/view-delivery-address/view-delivery-address.component';
import { ViewDeliveryAddressesComponent } from './addresses/view-delivery-addresses/view-delivery-addresses.component';
import { ViewUserAddressComponent } from './addresses/view-user-address/view-user-address.component';
import { ViewUserAddressesComponent } from './addresses/view-user-addresses/view-user-addresses.component';
import { CreateLoyaltyCardComponent } from './cards/create-loyalty-card/create-loyalty-card.component';
import { CreateRewardCardComponent } from './cards/create-reward-card/create-reward-card.component';
import { EditLoyaltyCardComponent } from './cards/edit-loyalty-card/edit-loyalty-card.component';
import { EditRewardCardComponent } from './cards/edit-reward-card/edit-reward-card.component';
import { ManageLoyaltyCardsComponent } from './cards/manage-loyalty-cards/manage-loyalty-cards.component';
import { ManageRewardCardsComponent } from './cards/manage-reward-cards/manage-reward-cards.component';
import { ViewLoyaltyCardComponent } from './cards/view-loyalty-card/view-loyalty-card.component';
import { ViewLoyaltyCardsComponent } from './cards/view-loyalty-cards/view-loyalty-cards.component';
import { ViewRewardCardComponent } from './cards/view-reward-card/view-reward-card.component';
import { ViewRewardCardsComponent } from './cards/view-reward-cards/view-reward-cards.component';

const routes: Routes = [
  { path: 'customer/dashoard', component: DashboardComponent, canActivate: [NoAuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
