import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketSearchPageComponent } from './components/ticket-search-page/ticket-search-page.component';
const routes: Routes = [
  {path: '', component: TicketSearchPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
