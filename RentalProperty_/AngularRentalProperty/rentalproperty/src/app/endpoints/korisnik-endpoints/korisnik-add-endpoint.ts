import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class KorisnikAddEndpoint implements  MyBaseEndpoint<KorisnikAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: KorisnikAddRequest): Observable<void> {
    let url=Config.adresa + `Korisnik-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface KorisnikAddRequest {
  ime: string
  prezime: string
  username: string
  password: string
  slika: string | undefined
  brojTelefona: string
  gradID: number
  spolID: number
  drzavaID: number
}

