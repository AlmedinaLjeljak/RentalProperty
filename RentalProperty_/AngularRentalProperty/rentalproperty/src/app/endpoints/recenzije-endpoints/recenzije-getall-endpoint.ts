import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class RecenzijeGetallEndpoint implements MyBaseEndpoint<void, RecenzijaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<RecenzijaGetAllResponse> {
    let url = Config.adresa + 'Recenzija-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<RecenzijaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface RecenzijaGetAllResponse{
  recenzije : RecenzijaGetAllResponseRecenzija[];
}

export interface RecenzijaGetAllResponseRecenzija {
  id: number
  ime: string
  prezime: string
  tekst: string
  slika: string
}

