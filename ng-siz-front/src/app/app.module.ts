import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import {MatCardModule} from '@angular/material/card'
import {MatInputModule} from '@angular/material/input'
import {MatButtonModule} from '@angular/material/button'
import {MatTableModule} from '@angular/material/table'
import {MatFormFieldModule} from '@angular/material/form-field';
import { TicketSearchPageComponent } from './components/ticket-search-page/ticket-search-page.component';
import { SearchByDocNumberComponent } from './components/search-by-doc-number/search-by-doc-number.component';
import { SearchByTicketNumberComponent } from './components/search-by-ticket-number/search-by-ticket-number.component';
import { AirlinesSortComponent } from './components/airlines-sort/airlines-sort.component';
import { PrintByTicketNumberComponent } from './components/print-by-ticket-number/print-by-ticket-number.component';
import { PrintByDocNumberComponent } from './components/print-by-doc-number/print-by-doc-number.component';
import { InterceptorService } from './services/interceptor.service';
// import { InterceptorComponent } from './components/interceptor/interceptor.component';

@NgModule({
  declarations: [
    AppComponent,
    TicketSearchPageComponent,
    SearchByDocNumberComponent,
    SearchByTicketNumberComponent,
    AirlinesSortComponent,
    PrintByTicketNumberComponent,
    PrintByDocNumberComponent,
    
    // InterceptorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,

    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatFormFieldModule
  ],
  providers: [{provide:String, useValue: "dummy"},
  SearchByDocNumberComponent,
  SearchByTicketNumberComponent,
  PrintByTicketNumberComponent,
  PrintByDocNumberComponent,
  {provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true}
],
  bootstrap: [AppComponent]
})
export class AppModule { }
