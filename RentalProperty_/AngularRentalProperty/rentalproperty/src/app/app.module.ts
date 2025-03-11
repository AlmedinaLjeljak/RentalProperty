import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
//import {OsobljePageComponent} from "./osoblje-page/osoblje-page.component";
import {TwofPageComponent} from "./twof-page/twof-page.component";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { LoginPageComponent } from './login-page/login-page.component';
import {MyAuthInterceptor} from "./helpers/my-auth-interceptor.service";
import {FaqPageComponent} from "./faq-page/faq-page.component";
import {HomePageComponent} from "./home-page/home-page.component";
import {KorisnikPageComponent} from "./korisnik-page/korisnik-page.component";
import {AdministratorPageComponent} from "./administrator-page/administrator-page.component";
import {AutorizacijaGuardKorisnik} from "./helpers/autorizacija-guard-korisnik.service";
import {
  AutorizacijaGuardAdministrator
} from "./helpers/autorizacija-guard-administrator.service";
import {AdministratorPageGradoviComponent} from "./administrator-page-gradovi/administrator-page-gradovi.component";
import {AdministratorPageDrzaveComponent} from "./administrator-page-drzave/administrator-page-drzave.component";
//mport { AdministratorPageKategorijeComponent } from './administrator-page-kategorije/administrator-page-kategorije.component';
import { AdministratorPageFaqComponent } from './administrator-page-faq/administrator-page-faq.component';
import { AdministratorPageAdminComponent } from './administrator-page-admin/administrator-page-admin.component';
import { AdministratorPageRecenzijeComponent } from './administrator-page-recenzije/administrator-page-recenzije.component';
import { AdministratorPageKorisniciComponent } from './administrator-page-korisnici/administrator-page-korisnici.component';
import { HashLocationStrategy, LocationStrategy  } from '@angular/common';



@NgModule({
  declarations: [
    AppComponent,
    FaqPageComponent,
    //OsobljePageComponent,
    TwofPageComponent,
    HomePageComponent,
    LoginPageComponent,
    KorisnikPageComponent,
    AdministratorPageComponent,
    AdministratorPageGradoviComponent,
    AdministratorPageDrzaveComponent,
    //AdministratorPageKategorijeComponent,
    AdministratorPageFaqComponent,
    AdministratorPageAdminComponent,
    TwofPageComponent,
    AdministratorPageRecenzijeComponent,
    AdministratorPageKorisniciComponent,
   ],
    imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot([
        {path: '', redirectTo: '/HomePage', pathMatch: 'full' },
        {path:'HomePage', component: HomePageComponent },
        {path:'FAQPage', component: FaqPageComponent },
        //{path:'OsobljePage', component: OsobljePageComponent },
        {path:'TwofPage', component: TwofPageComponent },
        {path:'LoginPage', component: LoginPageComponent },
        {path:'KorisnikPage', component: KorisnikPageComponent, canActivate: [AutorizacijaGuardKorisnik] },
        {path:'AdministratorPage', component: AdministratorPageComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'AdministratorPageDrzave', component: AdministratorPageDrzaveComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'AdministratorPageGradovi', component: AdministratorPageGradoviComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'AdministratorPageFaq', component: AdministratorPageFaqComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'AdministratorPageAdmin', component: AdministratorPageAdminComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'AdministratorPageAdmin', component: AdministratorPageAdminComponent, canActivate: [AutorizacijaGuardAdministrator]  },
        {path:'2FPage', component: TwofPageComponent, canActivate: [AutorizacijaGuardKorisnik] },
        {path:'AdministratorPageRecenzije', component: AdministratorPageRecenzijeComponent, canActivate: [AutorizacijaGuardAdministrator] },
        {path:'AdministratorPageKorisnici', component: AdministratorPageKorisniciComponent, canActivate: [AutorizacijaGuardAdministrator] },
      ]),
    ],
    providers: [
      { provide: HTTP_INTERCEPTORS, useClass: MyAuthInterceptor, multi: true },
      {provide : LocationStrategy , useClass: HashLocationStrategy},
      AutorizacijaGuardKorisnik,
      AutorizacijaGuardAdministrator
    ],
    bootstrap: [AppComponent]
  })
  export class AppModule { }
  