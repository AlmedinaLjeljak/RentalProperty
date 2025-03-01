import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class SpolGetAllEndpoint implements MyBaseEndpoint<void, SpolGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<SpolGetAllResponse> {
    let url = Config.adresa + 'Spol-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<SpolGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface SpolGetAllResponse{
  spolovi : SpolGetAllResponseSpol[];

}

export interface SpolGetAllResponseSpol {
  id: number
  naziv: string

}
