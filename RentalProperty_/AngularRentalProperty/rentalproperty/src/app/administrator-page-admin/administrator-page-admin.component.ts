import {Component, OnInit} from '@angular/core';
import {
  AdministratorGetAllEndpoint, AdministratorGetAllResponse,
  AdministratorGetAllResponseAdministrator
} from "../endpoints/administratori-endpoints/admin-getall-endpoint";
import {
  AdministratoriEditEndpoint,
  AdministratoriEditRequest
} from "../endpoints/administratori-endpoints/admin-edit-endpoint";
import {
  AdministratorAddEndpoint,
  AdministratorAddRequest
} from "../endpoints/administratori-endpoints/admin-add-endpoint";

@Component({
  selector: 'app-administrator-page-admin',
  templateUrl: './administrator-page-admin.component.html',
  styleUrls: ['./administrator-page-admin.component.css']
})
export class AdministratorPageAdminComponent implements OnInit{

  constructor(private AdministratorGetAllEndpoint:AdministratorGetAllEndpoint,
              private AdministratoriEditEndpoint:AdministratoriEditEndpoint,
              private AdministratorAddEndpoint:AdministratorAddEndpoint) {

  }


  administratori: AdministratorGetAllResponseAdministrator[] = [];
  PretragaNaziv: string = "";
  public odabraniAdmin: AdministratoriEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public noviAdmin:AdministratorAddRequest = {
    ime: "",
    prezime: "",
    username: "",
    password:""
  };

  ngOnInit():void {

    this.fetchAdministrator();
  }

  GetFiltiraniAdministratori() {
    return this.administratori.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.username.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Save() {
    this.AdministratoriEditEndpoint.Handle(this.odabraniAdmin!).subscribe((x)=>{
      this.fetchAdministrator();
      this.odabraniAdmin = null
    })
  }

  Close() {
    this.odabraniAdmin = null
    this.ngOnInit();
  }

  Odaberi(x: AdministratorGetAllResponseAdministrator) {
    this.odabraniAdmin = {
      id: x.id,
      ime: x.ime,
      prezime: x.prezime,
      username:x.username,
      password:x.password
    } ;
  }

  SaveNew() {
    this.AdministratorAddEndpoint.Handle(this.noviAdmin).subscribe((x)=>{
      this.fetchAdministrator();
      this.prikaziAdd = false;
      this.noviAdmin.ime ="";
      this.noviAdmin.prezime ="";
      this.noviAdmin.username ="";
      this.noviAdmin.password ="";
    })
  }

  private fetchAdministrator() {
    this.AdministratorGetAllEndpoint.Handle().subscribe((x:AdministratorGetAllResponse )=>{
      this.administratori = x.administrator;
    })
  }
}
