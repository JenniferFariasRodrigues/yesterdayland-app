import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventListComponent } from './components/event-list/event-list.component';
import { TicketPurchaseComponent } from './components/ticket-purchase/ticket-purchase.component';
import { CustomerTicketsComponent } from './components/customer-tickets/customer-tickets.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerService } from './services/customer.service';
import { EventService } from './services/event.service';

@NgModule({
  declarations: [
    AppComponent,
    TicketPurchaseComponent,
    CustomerTicketsComponent,
    EventListComponent,
    CustomerListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
