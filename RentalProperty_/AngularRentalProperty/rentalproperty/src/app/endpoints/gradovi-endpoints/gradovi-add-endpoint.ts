import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class GradAddEndpoint implements  MyBaseEndpoint<GradAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: GradAddRequest): Observable<void> {
    let url=Config.adresa + `Grad-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface GradAddRequest {
  naziv: string
}

