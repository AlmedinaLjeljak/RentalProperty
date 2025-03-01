import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class FaqGetallEndpoint implements MyBaseEndpoint<void, FAQGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<FAQGetAllResponse> {
    let url = Config.adresa + 'FAQ-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<FAQGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface FAQGetAllResponse{
  faq : FAQGetAllResponseFAQ[];

}

export interface FAQGetAllResponseFAQ {
  id: number
  pitanje: string
  odgovor: string
}
