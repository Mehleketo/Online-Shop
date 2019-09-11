import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SiteRoutingModule } from './site.routing.module';

import { CareersComponent } from './careers/careers.component'
import { ContactUsComponent } from './contact-us/contact-us.component'
import { FaqsComponent } from './faqs/faqs.component'
import { OtherComponent } from './other/other.component'
import { PetClubComponent } from './pet-club/pet-club.component'
import { SmartShopperComponent } from './smart-shopper/smart-shopper.component'
import { StoreLocatorComponent } from './store-locator/store-locator.component'
import { WineClubComponent } from './wine-club/wine-club.component'

@NgModule({
  imports: [
    CommonModule,
    SiteRoutingModule
  ],
  declarations: [
    CareersComponent,
    ContactUsComponent,
    FaqsComponent,
    OtherComponent,
    PetClubComponent,
    SmartShopperComponent,
    SmartShopperComponent,
    StoreLocatorComponent,
    WineClubComponent
  ]
})
export class SiteModule { }
