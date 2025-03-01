import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class KorisnikGetAllEndpoint implements MyBaseEndpoint<void, KorisnikGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<KorisnikGetAllResponse> {
    let url = Config.adresa + 'Korisnik-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<KorisnikGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface KorisnikGetAllResponse{
  korisnici : KorisnikGetAllResponseKorisnik[];

}

export interface KorisnikGetAllResponseKorisnik {
  id: number
  ime: string
  prezime: string
  username: string
  password: string
  slika: string
  brojTelefona: string
  nazivGrada: string
  nazivSpol:string
  nazivDrzave: string
  gradID: number
  drzavaID: number
  spolID: number
}
