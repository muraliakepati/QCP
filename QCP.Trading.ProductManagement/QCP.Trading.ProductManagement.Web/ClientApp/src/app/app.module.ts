import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgxSpinnerModule } from "ngx-spinner";
import { ChartModule } from "primeng/chart"

import {NgxPermissionsModule } from 'ngx-permissions'
import { TableModule } from 'primeng/table';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { ProductManagementComponent } from './product-management/product-management.component';
import { SalesManagementComponent } from './sales-management/sales-management.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CustomerComponent,
    ProductComponent,
    ProductManagementComponent,
    SalesManagementComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxPermissionsModule.forRoot(),
    TableModule,
    NgxSpinnerModule,
    ChartModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'products', component: ProductComponent },
      { path: 'customers', component: CustomerComponent },
      { path: 'productmanagement', component: ProductManagementComponent },
      { path: 'salesmanagement', component: SalesManagementComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
