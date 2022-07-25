import {Component, Injectable, Input, OnInit, ViewChild} from '@angular/core';


interface Ticket {
  passengerDocumentNumber: string,
      surname: string,
      name: string,
      sender: string,
      validationStatus: string,
      time: any,
      type: string,
      ticketNumber: string,
      departDatetime: any,
      airlineCode: string,
      cityFromName: string,
      cityToName: string,
}


@Component({
  selector: 'app-ticket-search-page',
  templateUrl: './ticket-search-page.component.html',
  styleUrls: ['./ticket-search-page.component.css']
})


export class TicketSearchPageComponent implements OnInit {

  
  Tickets: Ticket[] | undefined;
  public no_ticket_search_warning = false;
  
  noTicketSearchWarning(no_ticket_search: boolean){
    this.no_ticket_search_warning=no_ticket_search;
    console.log(no_ticket_search)
      
  }


  formationTable(data: any){
    if (Object.keys(data).length == 0) {
      console.log(data);
      
    } else {
      console.log(data);
      this.Tickets = data;
      // (<HTMLButtonElement>document.getElementById('by_doc_number_button')).disabled = true;
      // (<HTMLButtonElement>document.getElementById('by_ticket_number_button')).disabled = true;
      // (<HTMLInputElement>document.getElementById('by_ticket_number_checkbox')).disabled = true;
      // (<HTMLInputElement>document.getElementById('by_ticket_number_input')).value = '';
      
      // (<HTMLButtonElement>document.getElementById('SaveBtn')).disabled = false;
      
    }
  }

  
  constructor() { }

  ngOnInit() {
  }

}
