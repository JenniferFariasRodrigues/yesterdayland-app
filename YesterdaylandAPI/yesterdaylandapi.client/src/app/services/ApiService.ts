import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

import { Customer, Event, Ticket } from '../models';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    apiUrl: any;

    constructor(private http: HttpClient) { }
    //observable to take data from event,customer e ticket as a real time
    getEvents(): Observable<Event[]> {
        return this.http.get<Event[]>(`${this.apiUrl}/events`);
    }

    getCustomers(): Observable<Customer[]> {
        return this.http.get<Customer[]>(`${this.apiUrl}/customers`);
    }

    getTickets(): Observable<Ticket[]> {
        return this.http.get<Ticket[]>(`${this.apiUrl}/tickets`);
    }

    createCustomer(customer: Customer): Observable<Customer> {
        return this.http.post<Customer>(`${this.apiUrl}/customers`, customer);
    }

    createEvent(event: Event): Observable<Event> {
        return this.http.post<Event>(`${this.apiUrl}/events`, event);
    }

    createTicket(ticket: Ticket): Observable<Ticket> {
        return this.http.post<Ticket>(`${this.apiUrl}/tickets`, ticket);
    }
}
