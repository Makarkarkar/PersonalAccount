import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {saveAs} from "file-saver";
import {environment} from "src/environments/environment";

interface AirlineCompany{
        id:number,
        name: string,
        nameEn: string,
        icaoCode: string,
        iataCode:string,
        rfCode: string,
        country: string,
}

@Component({
  selector: 'app-print-by-doc-number',
  templateUrl: './print-by-doc-number.component.html',
  styleUrls: ['./print-by-doc-number.component.css']
})
export class PrintByDocNumberComponent implements OnInit {
  AirlineCompanies: AirlineCompany[] | undefined

  constructor(private http: HttpClient) { }

  public printByDocNumber(){
    (<HTMLDivElement>document.getElementById('loader')).style.display = '';
    const options: {
      headers?: HttpHeaders;
      observe?: 'body';
      params?: HttpParams;
      reportProgress?: boolean;
      responseType: 'arraybuffer';
      withCredentials?: boolean;
    } = {
      responseType: 'arraybuffer'
    };
    
    var doc_number = (<HTMLInputElement>document.querySelector("#by_doc_number_input")).value;
    console.log(doc_number)
    var airline_companies = (<HTMLSelectElement>document.getElementById("airlines_select_doc"));
    var airline_company = airline_companies.options[airline_companies.selectedIndex].value
    console.log(airline_company)
     return this.http.post(environment.apiUrl + "by_doc_number_print",{
      DocNumber: doc_number,
      AirlineCompanyIataCode : airline_company
     }, options)
     .subscribe(data =>{
      console.log(data)
      const blob = new Blob([data], {type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'});
      const fileName = airline_company + 'airlineReport.xlsx';
      console.log(fileName);
      saveAs(blob,fileName);
      (<HTMLDivElement>document.getElementById('wrong_time_request_message')).style.display = 'none';
      (<HTMLDivElement>document.getElementById('loader')).style.display = 'none';
      }
      )
}

  ngOnInit(): void {
    this.http.post(environment.apiUrl + "list_airline_companies", {headers: {
      'Content-Type': 'application/json',
      Accept: 'application/json'
      }
    })
     .subscribe((data: any) => {
       return this.AirlineCompanies = data;
     });
  }

}
