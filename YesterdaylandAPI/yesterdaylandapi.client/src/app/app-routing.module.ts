import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventListComponent } from './components/event-list/event-list.component';
import { TicketPurchaseComponent } from './components/ticket-purchase/ticket-purchase.component';
import { CustomerTicketsComponent } from './components/customer-tickets/customer-tickets.component';

//ROTES to application
const routes: Routes = [
  { path: 'events', component: EventListComponent },
  { path: 'purchase', component: TicketPurchaseComponent },
  { path: 'tickets', component: CustomerTicketsComponent },
  { path: '', redirectTo: '/events', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
