import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TfaGetAllResponse, TfaGetAllResponseTfa, TfasGetallEndpoint } from "../endpoints/tfas-endpoints/tfas-getall-endpoint";
import { MyAuthService } from "../services/MyAuthService";
import {
  AutentifikacijaTwoFOtkljucajEndpoint,
  AutentifikacijaTwoFOtkljucajRequest
} from "../endpoints/auth-endpoint/2FA-otkljucaj-endpoint";

@Component({
  selector: 'app-twof-page',
  templateUrl: './twof-page.component.html',
  styleUrls: ['./twof-page.component.css']
})
export class TwofPageComponent implements OnInit {

  constructor(
    private TfagetAllEndpoint: TfasGetallEndpoint,
    private myAuthService: MyAuthService,
    private router: Router,
    private AutentifikacijaTwoFOtkljucajEndpoint:AutentifikacijaTwoFOtkljucajEndpoint
  ) {}

  public kljuc:AutentifikacijaTwoFOtkljucajRequest = {
    kljuc:''
  }

  tfas: TfaGetAllResponseTfa[] = [];
  id: number = 0;
  verifikacijskiKod: string = '';
  uspjesnaVerifikacija: boolean = false;
  neuspjesnaVerifikacija: boolean = false;
  showDots: boolean = false;

  ngOnInit(): void {
    this.id = this.myAuthService.returnId()!;
    this.fetchTfas();
  }

  private fetchTfas() {
    this.TfagetAllEndpoint.Handle().subscribe((x: TfaGetAllResponse) => {
      this.tfas = x.tfas;
    });
  }

  provjeriKod() {
    const provjeriKod = this.tfas.some(tfa => tfa.twoFKey === this.verifikacijskiKod);

    if (provjeriKod) {
      this.uspjesnaVerifikacija = true;
      this.kljuc.kljuc = this.verifikacijskiKod;

      this.AutentifikacijaTwoFOtkljucajEndpoint.Handle(this.kljuc!).subscribe((x)=>{

      });

      this.showDots = true;
      setTimeout(() => {
        this.showDots = false; // Hide dots
        this.router.navigate(['/KorisnikPage']);
      }, 3000);
    } else {
      this.neuspjesnaVerifikacija = true;

      this.uspjesnaVerifikacija = false;

      setTimeout(() => {
        this.neuspjesnaVerifikacija = false;
      }, 1500);
    }
  }
}
