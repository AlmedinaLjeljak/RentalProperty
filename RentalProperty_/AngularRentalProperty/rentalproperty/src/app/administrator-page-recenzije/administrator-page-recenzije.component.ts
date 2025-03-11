import {Component, OnInit} from '@angular/core';
import {
  RecenzijaGetAllResponse, RecenzijaGetAllResponseRecenzija,
  RecenzijeGetallEndpoint
} from "../endpoints/recenzije-endpoints/recenzije-getall-endpoint";
import {RecenzijaAddEndpoint, RecenzijaAddRequest} from "../endpoints/recenzije-endpoints/recenzije-add-endpoint";
import {RecenzijeEditEndpoint, RecenzijeEditRequest} from "../endpoints/recenzije-endpoints/recenzije-edit-endpoint";


@Component({
  selector: 'app-administrator-page-recenzije',
  templateUrl: './administrator-page-recenzije.component.html',
  styleUrls: ['./administrator-page-recenzije.component.css']
})
export class AdministratorPageRecenzijeComponent implements OnInit{


  constructor(private RecenzijeGetallEndpoint:RecenzijeGetallEndpoint,
              private RecenzijaAddEndpoint:RecenzijaAddEndpoint,
              private RecenzijeEditEndpoint:RecenzijeEditEndpoint) {}

  recenzije: RecenzijaGetAllResponseRecenzija[] = [];
  PretragaNaziv: string = "";
  public odabranaRecenzija: RecenzijeEditRequest | null = null;

  public prikaziAdd:boolean = false;


  public novaRecenzija:RecenzijaAddRequest = {
    ime: "",
    prezime: "",
    slika: "",
    tekst: ""
  };

  ngOnInit() {

    this.fetchRecenzije();
  }


  Odaberi(x: RecenzijaGetAllResponseRecenzija) {
    this.odabranaRecenzija = {
      id: x.id,
      ime: x.ime,
      prezime: x.prezime,
      slika: x.slika,
      tekst: x.tekst
    } ;
  }


  GetFiltiraneRecenzije() {
    return this.recenzije.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }

  private fetchRecenzije() {
    this.RecenzijeGetallEndpoint.Handle().subscribe((x:RecenzijaGetAllResponse )=>{
      this.recenzije = x.recenzije;
    })
  }

  Preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.novaRecenzija!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  SaveNew() {
    this.RecenzijaAddEndpoint.Handle(this.novaRecenzija).subscribe((x)=>{
      this.fetchRecenzije();
      this.prikaziAdd = false;
      this.novaRecenzija.ime ="";
      this.novaRecenzija.prezime ="";
      this.novaRecenzija.slika ="";
      this.novaRecenzija.tekst ="";

    });
  }

  PreviewEdit() {
    // @ts-ignore
    var file = document.getElementById("slika-input-edit").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.odabranaRecenzija!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  Save() {
    this.RecenzijeEditEndpoint.Handle(this.odabranaRecenzija!).subscribe((x)=>{
      this.fetchRecenzije();
      this.odabranaRecenzija = null
    });
  }

  Close() {
    this.odabranaRecenzija = null;
    this.fetchRecenzije();
  }
}
