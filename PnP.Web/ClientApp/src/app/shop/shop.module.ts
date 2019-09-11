import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShopRoutingModule } from './shop.routing.module';

import { HomeComponent } from './home/home.component';

@NgModule({
  imports: [
    CommonModule,
    ShopRoutingModule
  ],
  declarations: [
    HomeComponent
  ]
})
export class ShopModule { }
