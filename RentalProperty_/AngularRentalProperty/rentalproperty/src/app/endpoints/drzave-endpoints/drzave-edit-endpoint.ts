
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class DrzavaEditEndpoint implements  MyBaseEndpoint<DrzavaEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: DrzavaEditRequest): Observable<number> {
    let url=Config.adresa + `Drzava-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface DrzavaEditRequest {
  id: number
  naziv: string
}

