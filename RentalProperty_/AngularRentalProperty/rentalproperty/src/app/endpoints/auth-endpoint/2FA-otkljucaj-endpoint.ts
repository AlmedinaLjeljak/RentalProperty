import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class AutentifikacijaTwoFOtkljucajEndpoint implements  MyBaseEndpoint<AutentifikacijaTwoFOtkljucajRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: AutentifikacijaTwoFOtkljucajRequest): Observable<void> {
    let url=Config.adresa + `Autentifikacija/2f-otkljucaj`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface AutentifikacijaTwoFOtkljucajRequest {
  kljuc:string
}

