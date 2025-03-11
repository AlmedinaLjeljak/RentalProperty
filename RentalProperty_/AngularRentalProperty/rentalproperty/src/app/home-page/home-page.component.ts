import {Component, OnInit} from '@angular/core';
import {
  RecenzijaGetAllResponse,
  RecenzijaGetAllResponseRecenzija,
  RecenzijeGetallEndpoint
} from "../endpoints/recenzije-endpoints/recenzije-getall-endpoint";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit{

  constructor(
              private RecenzijegetAllEndpoint:RecenzijeGetallEndpoint) {

  }

  recenzije: RecenzijaGetAllResponseRecenzija[] = [];
  ngOnInit():void {


    this.fetchRecenzije();
  }


  private fetchRecenzije() {
    this.RecenzijegetAllEndpoint.Handle().subscribe((x:RecenzijaGetAllResponse )=>{
      this.recenzije = x.recenzije;
    });
  }


}
