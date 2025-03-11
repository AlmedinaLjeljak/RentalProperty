import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class DrzavaAddEndpoint implements  MyBaseEndpoint<DrzavaAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: DrzavaAddRequest): Observable<void> {
    let url=Config.adresa + `Drzava-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface DrzavaAddRequest {
  naziv: string
}

