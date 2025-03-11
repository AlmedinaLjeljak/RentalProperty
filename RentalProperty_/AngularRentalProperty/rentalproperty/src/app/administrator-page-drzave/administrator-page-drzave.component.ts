import {Component, OnInit} from '@angular/core';
import {
  DrzavaGetAllResponse,
  DrzavaGetAllResponseDrzava,
  DrzavaGetAllEndpoint
} from "../endpoints/drzave-endpoints/drzave-getall-endpoint";
import {DrzavaEditEndpoint, DrzavaEditRequest} from "../endpoints/drzave-endpoints/drzave-edit-endpoint";
import {DrzavaAddEndpoint, DrzavaAddRequest} from "../endpoints/drzave-endpoints/drzave-add-endpoint";

@Component({
  selector: 'app-administrator-page-drzave',
  templateUrl: './administrator-page-drzave.component.html',
  styleUrls: ['./administrator-page-drzave.component.css']
})
export class AdministratorPageDrzaveComponent implements OnInit{

  constructor(private DrzavegetAllEndpoint:DrzavaGetAllEndpoint,
              private DrzavaEditEndpoint:DrzavaEditEndpoint,
              private DrzavaAddEndpoint:DrzavaAddEndpoint) {

  }
  drzave: DrzavaGetAllResponseDrzava[] = [];
  PretragaNaziv: string = "";
  public odabranaDrzava: DrzavaEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public novaDrzava:DrzavaAddRequest = {
    naziv: ""
  };
  ngOnInit():void {

    this.fetchDrzave();
  }

  GetFiltiraneDrzave() {
    return this.drzave.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Save() {
    this.DrzavaEditEndpoint.Handle(this.odabranaDrzava!).subscribe((x)=>{
      this.fetchDrzave();
      this.odabranaDrzava = null
    })
  }

  Close() {
    this.odabranaDrzava= null
    this.ngOnInit();
  }

  Odaberi(x: DrzavaGetAllResponseDrzava) {
    this.odabranaDrzava = {
      id: x.id,
      naziv: x.naziv,
    } ;
  }

  SaveNew() {
    this.DrzavaAddEndpoint.Handle(this.novaDrzava).subscribe((x)=>{
      this.fetchDrzave();
      this.prikaziAdd = false;
      this.novaDrzava.naziv ="";
    })
  }

  private fetchDrzave() {
    this.DrzavegetAllEndpoint.Handle().subscribe((x:DrzavaGetAllResponse )=>{
      this.drzave = x.drzave;
    });
  }
}
