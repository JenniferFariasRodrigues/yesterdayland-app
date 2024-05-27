import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:5001/api/customers';

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
      return this.http.get<Customer[]>(this.apiUrl);
  }

  addCustomer(customer: Customer): Observable<Customer> {
      return this.http.post<Customer>(this.apiUrl, customer);
  }
}
