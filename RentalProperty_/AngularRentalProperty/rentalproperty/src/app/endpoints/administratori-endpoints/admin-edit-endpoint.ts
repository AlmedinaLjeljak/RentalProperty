
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class AdministratoriEditEndpoint implements  MyBaseEndpoint<AdministratoriEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: AdministratoriEditRequest): Observable<number> {
    let url=Config.adresa + `Administrator-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface AdministratoriEditRequest {
  id: number
  ime: string
  prezime: string
  username: string
  password: string
}

