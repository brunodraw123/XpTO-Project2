import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from '../component/customer/customer.component';
import { KitchenComponent } from '../component/kitchen/kitchen.component';

@NgModule({
  declarations: [
    AppComponent,
    KitchenComponent,
    CustomerComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,FormsModule,
    AppRoutingModule, RouterModule.forRoot(
      [
        { path: "kitchen", component: KitchenComponent, providers: [] },
        { path: "customer", component: CustomerComponent, providers: [] }
      ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
