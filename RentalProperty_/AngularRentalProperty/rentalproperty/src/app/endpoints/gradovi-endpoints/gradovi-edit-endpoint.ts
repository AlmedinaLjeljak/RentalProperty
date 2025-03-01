
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class GradoviEditEndpoint implements  MyBaseEndpoint<GradoviEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: GradoviEditRequest): Observable<number> {
    let url=Config.adresa + `Grad-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface GradoviEditRequest {
  id: number
  naziv: string
}

