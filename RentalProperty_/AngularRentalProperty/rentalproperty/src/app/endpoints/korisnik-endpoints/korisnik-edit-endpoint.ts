
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class KorisniciEditEndpoint implements  MyBaseEndpoint<KorisniciEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: KorisniciEditRequest): Observable<number> {
    let url=Config.adresa + `Korisnik-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface KorisniciEditRequest {
  id: number
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

