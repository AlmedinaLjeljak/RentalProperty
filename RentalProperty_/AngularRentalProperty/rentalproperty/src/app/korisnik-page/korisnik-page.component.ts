import {Component, OnInit} from '@angular/core';
import {MyAuthService} from "../services/MyAuthService";
import {KorisnikGetByIdEndpoint, KorisnikGetByIdResponse} from "../endpoints/korisnik-endpoints/korisnik-get-endpoint";



@Component({
  selector: 'app-korisnik-page',
  templateUrl: './korisnik-page.component.html',
  styleUrls: ['./korisnik-page.component.css']
})
export class KorisnikPageComponent implements OnInit{

  constructor(private myAuthService: MyAuthService,
              private KorisnikGetByIdEndpoint:KorisnikGetByIdEndpoint,
        ) {
  }




  public odabraniKorisnik : KorisnikGetByIdResponse | null = null;
  id:number = 0
  ngOnInit() {
    this.id = this.myAuthService.returnId()!;

    this.KorisnikGetByIdEndpoint.Handle(this.id).subscribe({
          next: x => {
            this.odabraniKorisnik = x;
          }
        }
    )

  }



}
