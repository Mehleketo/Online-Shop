import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AccountsModule } from './accounts/accounts.module';
import { AdminModule } from './admin/admin.module';
import { CustomerModule } from './customer/customer.module';
import { ProductModule } from './product/product.module';
import { ShopModule } from './shop/shop.module';
import { SiteModule } from './site/site.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './_shared/components/header/header.component';
import { FooterComponent } from './_shared/components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' }
    ]),
    AccountsModule,
    AdminModule,
    CustomerModule,
    ProductModule,
    ShopModule,
    SiteModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
