import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class TfasGetallEndpoint implements MyBaseEndpoint<void, TfaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<TfaGetAllResponse> {
    let url = Config.adresa + 'Tfa-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<TfaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}
export interface TfaGetAllResponse{
  tfas : TfaGetAllResponseTfa[];
}

export interface TfaGetAllResponseTfa {
  id: number
  twoFKey: string
}
