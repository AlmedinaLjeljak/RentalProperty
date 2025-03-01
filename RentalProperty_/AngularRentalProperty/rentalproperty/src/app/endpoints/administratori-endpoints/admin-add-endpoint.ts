import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class AdministratorAddEndpoint implements  MyBaseEndpoint<AdministratorAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: AdministratorAddRequest): Observable<void> {
    let url=Config.adresa + `Administrator-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface AdministratorAddRequest {
  ime: string
  prezime: string
  username: string
  password: string
}

