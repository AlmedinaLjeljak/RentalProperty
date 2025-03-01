import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class GradoviGetallEndpoint implements MyBaseEndpoint<void, GradGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<GradGetAllResponse> {
    let url = Config.adresa + 'Grad-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<GradGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface GradGetAllResponse{
  gradovi : GradGetAllResponseGrad[];

}

export interface GradGetAllResponseGrad {
  id: number
  naziv: string

}
