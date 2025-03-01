import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class RecenzijaAddEndpoint implements  MyBaseEndpoint<RecenzijaAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: RecenzijaAddRequest): Observable<void> {
    let url=Config.adresa + `Recenzija-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface RecenzijaAddRequest {
  ime: string
  prezime: string
  tekst: string
  slika: string | undefined
}

