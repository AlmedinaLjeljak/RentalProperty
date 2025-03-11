import {Component, OnInit} from '@angular/core';
import {
  FaqGetallEndpoint,
  FAQGetAllResponse,
  FAQGetAllResponseFAQ
} from "../endpoints/faq-endpoints/faq-getall-endpoint";


@Component({
  selector: 'app-faq-page',
  templateUrl: './faq-page.component.html',
  styleUrls: ['./faq-page.component.css']
})
export class FaqPageComponent implements OnInit{
  constructor(private FAQgetAllEndpoint:FaqGetallEndpoint) {

  }

  faq: FAQGetAllResponseFAQ[] = [];

  ngOnInit():void {

    this.fetchFAQ();
  }

  private fetchFAQ() {
    this.FAQgetAllEndpoint.Handle().subscribe((x:FAQGetAllResponse )=>{
      this.faq = x.faq;
    });
  }
}
