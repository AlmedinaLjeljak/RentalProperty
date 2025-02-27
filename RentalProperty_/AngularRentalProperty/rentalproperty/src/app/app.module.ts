import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";

@NgModule({
  declarations: [
    AppComponent  ],
    imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot([
        {path: '', redirectTo: '/HomePage', pathMatch: 'full' },
        //{path:'HomePage', component: HomePageComponent },
      ]),
    ],
    providers: [
      //{ provide: HTTP_INTERCEPTORS, useClass: MyAuthInterceptor, multi: true },
      //{provide : LocationStrategy , useClass: HashLocationStrategy},
      //AutorizacijaGuardKorisnik,
      //AutorizacijaGuardAdministrator
    ],
    bootstrap: [AppComponent]
  })
  export class AppModule { }
  