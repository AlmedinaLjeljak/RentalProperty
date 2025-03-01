
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class RecenzijeEditEndpoint implements  MyBaseEndpoint<RecenzijeEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: RecenzijeEditRequest): Observable<number> {
    let url=Config.adresa + `Recenzija-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface RecenzijeEditRequest {
  id: number
  ime: string
  prezime: string
  tekst: string
  slika: string | undefined
}

