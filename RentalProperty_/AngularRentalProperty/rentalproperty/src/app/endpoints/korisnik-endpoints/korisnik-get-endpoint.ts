import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";


@Injectable({providedIn: 'root'})
export class KorisnikGetByIdEndpoint implements  MyBaseEndpoint<number, KorisnikGetByIdResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(korisnikid: number): Observable<KorisnikGetByIdResponse> {
    let url=Config.adresa+`Korisnik-GetById/${korisnikid}`;
    return this.httpClient.get<KorisnikGetByIdResponse>(url);
  }
}

export interface KorisnikGetByIdResponse {
  korisnikID: number
  ime: string
  prezime: string
  slika: string
  brojTelefona: string
  nazivGrada: string
  nazivSpola: string
  nazivDrzave: string
  username: string

}

