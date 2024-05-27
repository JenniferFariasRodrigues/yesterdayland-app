import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { Event } from '../models/event.model';
import { Ticket } from '../models/ticket.model';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  //http calls to api
  private apiUrl = 'https://localhost:3000/api';
  // private apiUrl = 'https://localhost:7019/api';


  constructor(private http: HttpClient) { }

  //observable to take assynchronos operation
  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/events`);
  }
  //get the customer data
  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.apiUrl}/customers`);
  }
  //get the tickets data
  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(`${this.apiUrl}/tickets`);
  }
  //create a customer data
  createCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(`${this.apiUrl}/customers`, customer);
  }
  //create a event data
  createEvent(event: Event): Observable<Event> {
    return this.http.post<Event>(`${this.apiUrl}/events`, event);
  }
  //create a ticket data
  createTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.post<Ticket>(`${this.apiUrl}/tickets`, ticket);
  }
}
