import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class AdministratorGetAllEndpoint implements MyBaseEndpoint<void, AdministratorGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<AdministratorGetAllResponse> {
    let url = Config.adresa + 'Administrator-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<AdministratorGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface AdministratorGetAllResponse{
  administrator : AdministratorGetAllResponseAdministrator[];

}

export interface AdministratorGetAllResponseAdministrator {
  id: number
  ime: string
  prezime: string
  username: string
  password: string

}
