
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class FAQEditEndpoint implements  MyBaseEndpoint<FAQEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: FAQEditRequest): Observable<number> {
    let url=Config.adresa + `FAQ-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface FAQEditRequest {
  id: number
  pitanje: string
  odgovor: string
}

