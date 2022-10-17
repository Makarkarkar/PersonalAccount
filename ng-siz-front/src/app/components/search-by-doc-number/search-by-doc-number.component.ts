import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DataAll } from '../models/fromBack/DataAll';
import { ByDocNumber } from '../models/toBack/ByDocNumber';
import {environment} from "src/environments/environment";



@Component({
  selector: 'app-search-by-doc-number',
  templateUrl: './search-by-doc-number.component.html',
  styleUrls: ['./search-by-doc-number.component.css']
})
export class SearchByDocNumberComponent implements OnInit {
  @Output() docNumber = new EventEmitter<any>();
  @Output() noTicketSearch = new EventEmitter<boolean>()
  public byDocNumber?: ByDocNumber;
  public dataAlls?: DataAll[];
  constructor(private http: HttpClient) { }
  public docInput:string = '';
  
  
  
  public clearTicketNumberInput(){
    return (<HTMLInputElement>document.getElementById('by_ticket_number_input')).value = '';
  }
   
  public getByDocNumber(){
    (<HTMLTableElement>document.getElementById('ticket_table')).style.display = 'none';
    this.noTicketSearch.emit(false);
    (<HTMLDivElement>document.getElementById('loader')).style.display = '';
    var doc_number = (<HTMLInputElement>document.querySelector("#by_doc_number_input")).value;
    console.log(doc_number);
     return this.http.post(environment.apiUrl + "by_doc_number/",{
      DocNumber: doc_number
     }, {headers: {
      'Content-Type': 'application/json',
      Accept: 'application/json'
    }
  })
     .subscribe(
      data => {
        if (Object.keys(data).length == 0) {
          this.noTicketSearch.emit(true);
          (<HTMLDivElement>document.getElementById('wrong_number_message')).style.display = 'none';
          (<HTMLDivElement>document.getElementById('loader')).style.display = 'none';
          (<HTMLDivElement>document.getElementById('wrong_time_request_message')).style.display = 'none';
        } else {
          (<HTMLDivElement>document.getElementById('wrong_time_request_message')).style.display = 'none';
          (<HTMLDivElement>document.getElementById('wrong_number_message')).style.display = 'none';
          (<HTMLDivElement>document.getElementById('loader')).style.display = 'none';
          (<HTMLTableElement>document.getElementById('ticket_table')).style.display = '';
          (<HTMLDivElement>document.getElementById('print_by_doc_number_div')).style.display = '';
          (<HTMLDivElement>document.getElementById('print_by_ticket_number_div')).style.display = 'none';
          //this.docInput = '';
          //(<HTMLButtonElement>document.getElementById('reload_button')).style.display = '';
          
          this.docNumber.emit(data);
          //console.log(data)
        }
      }
    );
  }
  ngOnInit(): void {
  }

}