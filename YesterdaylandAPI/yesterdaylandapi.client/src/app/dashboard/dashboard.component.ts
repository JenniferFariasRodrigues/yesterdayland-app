
import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Ticket } from '@models/ticket.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  selectedCustomer: any;
  customers: any[] | undefined;
  selectedEvent: any;
  events: any[] = []; // Inicializando events como uma array vazia
  showCustomerList: boolean = false;
  showEventDetails: boolean = false;
  clickButton = false;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadCustomers();
    this.loadEvents();
  }

  loadCustomers(): void {
    this.apiService.getCustomers().subscribe((customers: any[]) => {
      this.customers = customers;
    });
  }

  loadEvents(): void {
    this.apiService.getEvents().subscribe((events: any[]) => {
      this.events = events;
    });
  }

  toggleCustomerList(): void {
    this.showCustomerList = !this.showCustomerList;
  }

  toggleEventDetails(): void {
    this.showEventDetails = !this.showEventDetails;
  }

  purchaseTicket(): void {
    if (this.selectedCustomer && this.selectedEvent) {
      this.clickButton= true;
      const ticket: Ticket = {
        id: 0,
        code: 'TICKET-' + Math.random().toString(36).substr(2, 9).toUpperCase(),
        createDate: new Date(),
        customerId: this.selectedCustomer.id,
        eventId: this.selectedEvent.id
      };
    }
  }
}
