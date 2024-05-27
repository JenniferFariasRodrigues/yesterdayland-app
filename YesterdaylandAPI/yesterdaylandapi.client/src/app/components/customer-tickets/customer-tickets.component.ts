import { Component } from '@angular/core';
import { Customer } from '../../models/customer.model';
import { Ticket } from '../../models/ticket.model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-customer-tickets',
  templateUrl: './customer-tickets.component.html',
  styleUrl: './customer-tickets.component.css'
})

export class CustomerTicketsComponent implements OnInit {
  customers: Customer[] = [];
  selectedCustomer: Customer | undefined;
  tickets: Ticket[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getCustomers().subscribe((customers: Customer[]) => {
      this.customers = customers;
    });
  }

  loadTickets(): void {
    if (this.selectedCustomer) {
      this.tickets = this.selectedCustomer.tickets;
    }
  }
}
