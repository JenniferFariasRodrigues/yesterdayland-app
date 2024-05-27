  import { Component, OnInit } from '@angular/core';
  import { Customer } from '../../models/customer.model';
  import { ApiService } from '../../services/api.service';
  import { Ticket } from '../../models/ticket.model';

  @Component({
    selector: 'app-ticket-purchase',
    templateUrl: './ticket-purchase.component.html',
    styleUrl: './ticket-purchase.component.css'
  })

  export class TicketPurchaseComponent implements OnInit {
    customers: Customer[] = [];
    events: Event[] = [];
    selectedCustomer: Customer | undefined;
    selectedEvent: Event | undefined;

    constructor(private apiService: ApiService) {}

    ngOnInit(): void {
      this.apiService.getCustomers().subscribe((customers: Customer[]) => {
        this.customers = customers;
      });
      // this.apiService.getEvents().subscribe((events: Event[]) => {
      //   this.events = events;
      // });
    }

    purchaseTicket(): void {
      if (this.selectedCustomer && this.selectedEvent) {
        const ticket: Ticket = {
          id: 0,
          code: 'TICKET-' + Math.random().toString(36).substr(2, 9).toUpperCase(),
          createDate: new Date(),
          customerId: this.selectedCustomer.id,
          eventId: this.selectedEvent.type.trim.length // Verifique se selectedEvent tem um campo id
        };

        this.apiService.createTicket(ticket).subscribe();
      }
    }
  }
