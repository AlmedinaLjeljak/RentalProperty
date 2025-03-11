import {Component, OnInit} from '@angular/core';

import {
  FaqGetallEndpoint,
  FAQGetAllResponse,
  FAQGetAllResponseFAQ
} from "../endpoints/faq-endpoints/faq-getall-endpoint";
import {FAQEditEndpoint, FAQEditRequest} from "../endpoints/faq-endpoints/faq-edit-endpoint";

import {FAQAddEndpoint, FAQAddRequest} from "../endpoints/faq-endpoints/faq-add-endpoint";

@Component({
  selector: 'app-administrator-page-faq',
  templateUrl: './administrator-page-faq.component.html',
  styleUrls: ['./administrator-page-faq.component.css']
})
export class AdministratorPageFaqComponent implements OnInit{

  constructor(private FaqGetallEndpoint:FaqGetallEndpoint,
              private FAQEditEndpoint:FAQEditEndpoint,
              private FAQAddEndpoint:FAQAddEndpoint) {

  }

  faq: FAQGetAllResponseFAQ[] = [];
  PretragaNaziv: string = "";
  public odabraniFAQ: FAQEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public noviFAQ:FAQAddRequest = {
    pitanje: "",
    odgovor: "",
  };

  ngOnInit():void {

    this.fetchFAQ();
  }

  GetFiltiraniFAQ() {
    return this.faq.filter(x=> x.pitanje.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.odgovor.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Close() {
    this.odabraniFAQ = null
    this.ngOnInit();
  }

  Save() {
    this.FAQEditEndpoint.Handle(this.odabraniFAQ!).subscribe((x)=>{
      this.fetchFAQ();
      this.odabraniFAQ = null
    })
  }

  Odaberi(x: FAQGetAllResponseFAQ) {
    this.odabraniFAQ = {
      id: x.id,
      pitanje: x.pitanje,
      odgovor: x.odgovor
    } ;
  }

  SaveNew() {
    this.FAQAddEndpoint.Handle(this.noviFAQ).subscribe((x)=>{
      this.fetchFAQ();
      this.prikaziAdd = false;
      this.noviFAQ.pitanje ="";
      this.noviFAQ.odgovor ="";
    })
  }

  private fetchFAQ() {
    this.FaqGetallEndpoint.Handle().subscribe((x:FAQGetAllResponse )=>{
      this.faq = x.faq;
    });
  }
}
