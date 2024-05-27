import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Yesterdayland';
  customers: any;
  events: any;
  weather: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCustomers();
    this.getEvents();
  }

  getCustomers() {
    this.http.get('/api/customers')
      .pipe(
        catchError(this.handleError)
      )
      .subscribe(data => {
        this.customers = data;
      }, error => {
        console.error('There was an error!', error);
      });
  }

  getEvents() {
    this.http.get('/api/events')
      .pipe(
        catchError(this.handleError)
      )
      .subscribe(data => {
        this.events = data;
      }, error => {
        console.error('There was an error!', error);
      });
  }


  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return new Observable<never>();
  }
}

