import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class DrzavaGetAllEndpoint implements MyBaseEndpoint<void, DrzavaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<DrzavaGetAllResponse> {
    let url = Config.adresa + 'Drzava-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<DrzavaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface DrzavaGetAllResponse{
  drzave : DrzavaGetAllResponseDrzava[];

}

export interface DrzavaGetAllResponseDrzava {
  id: number
  naziv: string

}
