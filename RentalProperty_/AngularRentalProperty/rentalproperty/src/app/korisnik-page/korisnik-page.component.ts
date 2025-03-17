import { Component, OnInit } from '@angular/core';
import { MyAuthService } from "../services/MyAuthService";
import {
  KorisnikGetByIdEndpoint, KorisnikGetByIdResponse
} from "../endpoints/korisnik-endpoints/korisnik-get-endpoint";
import { KorisniciEditEndpoint, KorisniciEditRequest } from "../endpoints/korisnik-endpoints/korisnik-edit-endpoint";
import {
  GradGetAllResponse, GradGetAllResponseGrad, GradoviGetallEndpoint
} from "../endpoints/gradovi-endpoints/gradovi-getall-endpoint";
import {
  DrzavaGetAllResponse, DrzavaGetAllResponseDrzava, DrzavaGetAllEndpoint
} from "../endpoints/drzave-endpoints/drzave-getall-endpoint";
import {
  SpolGetAllEndpoint, SpolGetAllResponse, SpolGetAllResponseSpol
} from "../endpoints/spolovi-endpoints/spolovi-getall-endpoints";

@Component({
  selector: 'app-korisnik-page',
  templateUrl: './korisnik-page.component.html',
  styleUrls: ['./korisnik-page.component.css']
})
export class KorisnikPageComponent implements OnInit {

  constructor(
    private myAuthService: MyAuthService,
    private KorisnikGetByIdEndpoint: KorisnikGetByIdEndpoint,
    private KorisniciEditEndpoint: KorisniciEditEndpoint,
    private GradoviGetallEndpoint: GradoviGetallEndpoint,
    private DrzaveGetAllEndpoint: DrzavaGetAllEndpoint,
    private SpolGetAllEndpoint: SpolGetAllEndpoint
  ) {}

  public odabraniKorisnik: KorisnikGetByIdResponse | null = null;
  public odabraniKor: KorisniciEditRequest | null = null;
  spolovi: SpolGetAllResponseSpol[] = [];
  gradovi: GradGetAllResponseGrad[] = [];
  drzave: DrzavaGetAllResponseDrzava[] = [];
  id: number = 0;

  ngOnInit() {
    this.id = this.myAuthService.returnId()!;
    
    this.KorisnikGetByIdEndpoint.Handle(this.id).subscribe({
      next: (x) => {
        this.odabraniKorisnik = x;
        
        
        this.odabraniKor = {
          id: x.korisnikID,
          ime: x.ime,
          prezime: x.prezime,
          password: "",  
          username: x.username,
          brojTelefona: x.brojTelefona,
          slika: x.slika,
          gradID: 1,
          spolID: 1,
          drzavaID: 1
        };
      }
    });

    this.fetchSpolovi();
    this.fetchGradovi();
    this.fetchDrzave();
  }

  PreviewEdit() {
    var fileInput = document.getElementById("slika-input-edit") as HTMLInputElement;
    if (fileInput && fileInput.files && fileInput.files[0]) {
      var reader: FileReader = new FileReader();
      reader.onload = () => {
        if (this.odabraniKor) {
          this.odabraniKor.slika = reader.result?.toString() || "";
        }
      };
      reader.readAsDataURL(fileInput.files[0]);
    }
  }

  Save() {
    if (this.odabraniKor) {
      console.log("Podaci koji se šalju na backend:", this.odabraniKor);
      
      this.KorisniciEditEndpoint.Handle(this.odabraniKor).subscribe({
        next: () => {
          alert("Podaci uspješno ažurirani!");
        },
        error: (err) => {
          console.error("Greška prilikom ažuriranja:", err);
          alert("Greška prilikom ažuriranja korisnika!");
        }
      });
    }
  }
  

  private fetchSpolovi() {
    this.SpolGetAllEndpoint.Handle().subscribe((x: SpolGetAllResponse) => {
      this.spolovi = x.spolovi;
    });
  }

  private fetchGradovi() {
    this.GradoviGetallEndpoint.Handle().subscribe((x: GradGetAllResponse) => {
      this.gradovi = x.gradovi;
    });
  }

  private fetchDrzave() {
    this.DrzaveGetAllEndpoint.Handle().subscribe((x: DrzavaGetAllResponse) => {
      this.drzave = x.drzave;
    });
  }
}
