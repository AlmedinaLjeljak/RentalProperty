import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Config} from "./config";
import { Router} from "@angular/router";
import {MyAuthService} from "./services/MyAuthService";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(public router:Router, public httpClient: HttpClient,public MyAuthService : MyAuthService) {
    this.router.navigate(['/HomePage']);

  }

  ngOnInit():void {

  }

  Logout() {
    let token = window.localStorage.getItem("my-auth-token")??"";
    window.localStorage.setItem("my-auth-token","");

    let url=Config.adresa+`Autentifikacija/Logout`
    this.httpClient.post(url, {}, {
      headers:{
        "my-auth-token": token
      }
    }).subscribe(x=>{
      //alert("Uspješno ste se odjavili");
    })

    this.router.navigate(["/LoginPage"])
  }
}
