import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';
import { NoAuthGuard } from '../_guards/no.auth.guard';
import { AdminAuthGuard } from '../_guards/admin.auth.guard';

import { CareersComponent } from './careers/careers.component'
import { ContactUsComponent } from './contact-us/contact-us.component'
import { FaqsComponent } from './faqs/faqs.component'
import { OtherComponent } from './other/other.component'
import { PetClubComponent } from './pet-club/pet-club.component'
import { SmartShopperComponent } from './smart-shopper/smart-shopper.component'
import { StoreLocatorComponent } from './store-locator/store-locator.component'
import { WineClubComponent } from './wine-club/wine-club.component'

const routes: Routes = [
  { path: 'careers', component: CareersComponent, canActivate: [NoAuthGuard] },
  { path: 'faqs', component: FaqsComponent, canActivate: [NoAuthGuard] },
  { path: 'other', component: OtherComponent, canActivate: [NoAuthGuard] },
  { path: 'petclub', component: PetClubComponent, canActivate: [NoAuthGuard] },
  { path: 'smartshopper', component: SmartShopperComponent, canActivate: [NoAuthGuard] },
  { path: 'storelocator', component: StoreLocatorComponent, canActivate: [NoAuthGuard] },
  { path: 'wineclub', component: WineClubComponent, canActivate: [NoAuthGuard] },
  { path: 'contactus', component: ContactUsComponent, canActivate: [NoAuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SiteRoutingModule { }
