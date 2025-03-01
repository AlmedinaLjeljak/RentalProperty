import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class FAQAddEndpoint implements  MyBaseEndpoint<FAQAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: FAQAddRequest): Observable<void> {
    let url=Config.adresa + `FAQ-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface FAQAddRequest {
  pitanje: string
  odgovor: string
}

