import {Component, OnInit} from '@angular/core';
import {
  KorisnikGetAllEndpoint, KorisnikGetAllResponse,
  KorisnikGetAllResponseKorisnik
} from "../endpoints/korisnik-endpoints/korisnici-getall-endpoint";
import {
  GradGetAllResponse,
  GradGetAllResponseGrad,
  GradoviGetallEndpoint
} from "../endpoints/gradovi-endpoints/gradovi-getall-endpoint";
import {
  DrzavaGetAllResponse,
  DrzavaGetAllResponseDrzava,
  DrzavaGetAllEndpoint
} from "../endpoints/drzave-endpoints/drzave-getall-endpoint";
import {
  SpolGetAllEndpoint,
  SpolGetAllResponse,
  SpolGetAllResponseSpol
} from "../endpoints/spolovi-endpoints/spolovi-getall-endpoints";
import {KorisnikAddEndpoint, KorisnikAddRequest} from "../endpoints/korisnik-endpoints/korisnik-add-endpoint";
import {KorisniciEditEndpoint, KorisniciEditRequest} from "../endpoints/korisnik-endpoints/korisnik-edit-endpoint";
import {HttpClient} from "@angular/common/http";
import {Config} from "../config";

@Component({
  selector: 'app-administrator-page-korisnici',
  templateUrl: './administrator-page-korisnici.component.html',
  styleUrls: ['./administrator-page-korisnici.component.css']
})
export class AdministratorPageKorisniciComponent implements OnInit{

  constructor(private KorisnikGetAllEndpoint:KorisnikGetAllEndpoint,
              private GradoviGetallEndpoint:GradoviGetallEndpoint,
              private DrzaveGetAllEndpoint:DrzavaGetAllEndpoint,
              private SpolGetAllEndpoint:SpolGetAllEndpoint,
              private KorisnikAddEndpoint:KorisnikAddEndpoint,
              private KorisniciEditEndpoint:KorisniciEditEndpoint,
              private HttpClient:HttpClient) {
  }

  korisnici: KorisnikGetAllResponseKorisnik[] = [];
  spolovi: SpolGetAllResponseSpol[] = [];
  gradovi: GradGetAllResponseGrad[] = [];
  drzave: DrzavaGetAllResponseDrzava[] = [];
  PretragaNaziv: string = "";

  pdfIzvjestaj:any;

  public odabraniKorisnik: KorisniciEditRequest | null = null;
  public prikaziAdd:boolean = false;
  public noviKorisnik:KorisnikAddRequest = {
    ime: "",
    prezime: "",
    username: "",
    password: "",
    slika: "",
    brojTelefona: "",
    gradID: 1,
    spolID: 1,
    drzavaID: 1


  };


  ngOnInit() {

    this.fetchKorisnici();
    this.fetchSpolovi();
    this.fetchGradovi();
    this.fetchDrzave();
  }

  Odaberi(x: KorisnikGetAllResponseKorisnik) {
    this.odabraniKorisnik = {
      id: x.id,
      ime: x.ime,
      prezime: x.prezime,
      password: x.password,
      username: x.username,
      brojTelefona: x.brojTelefona,
      slika: x.slika,
      gradID: x.gradID,
      spolID: x.spolID,
      drzavaID: x.drzavaID
    } ;
  }

  GetFiltiraniKorisnici() {
    return this.korisnici.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.username.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }

  private fetchKorisnici() {
    this.KorisnikGetAllEndpoint.Handle().subscribe((x:KorisnikGetAllResponse )=>{
      this.korisnici = x.korisnici;
    });
  }

  Preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.noviKorisnik!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }   

  private fetchSpolovi() {
    this.SpolGetAllEndpoint.Handle().subscribe((x:SpolGetAllResponse )=>{
      this.spolovi = x.spolovi;
    });
  }

  private fetchGradovi() {
    this.GradoviGetallEndpoint.Handle().subscribe((x:GradGetAllResponse )=>{
      this.gradovi = x.gradovi;
    });
  }
  private fetchDrzave() {
    this.DrzaveGetAllEndpoint.Handle().subscribe((x:DrzavaGetAllResponse )=>{
      this.drzave = x.drzave;
    });
  }



  SaveNew() {
    this.KorisnikAddEndpoint.Handle(this.noviKorisnik).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.noviKorisnik.ime ="";
      this.noviKorisnik.prezime ="";
      this.noviKorisnik.username ="";
      this.noviKorisnik.password ="";
      this.noviKorisnik.slika ="";
      this.noviKorisnik.brojTelefona ="";
      this.noviKorisnik.brojTelefona ="";
      this.noviKorisnik.gradID =1;
      this.noviKorisnik.spolID =1;
      this.noviKorisnik.drzavaID=1;


    });
  }

  Close() {
    this.odabraniKorisnik = null
    this.prikaziAdd = false;
    this.ngOnInit();
  }

  PreviewEdit() {
    // @ts-ignore
    var file = document.getElementById("slika-input-edit").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.odabraniKorisnik!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  Save() {
    this.KorisniciEditEndpoint.Handle(this.odabraniKorisnik!).subscribe((x)=>{
      this.fetchKorisnici();
      this.odabraniKorisnik = null
    });
  }


  GenerisiIzvjesaj() {
    const urlIzvjestaj = Config.adresa+'Report1/Index/PDFReport';
    window.open(urlIzvjestaj, '_blank');

  }

  GenerisiIzvjestaj2() {
    const urlIzvjestaj = Config.adresa+'Report1/Index2/ExcelReport';
    window.open(urlIzvjestaj, '_blank');
  }
}
