import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Event } from '../../models/event';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.css'
})
export class EventListComponent implements OnInit {
  events: Event[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getEvents().subscribe(events => {
      this.events = events;
    });
  }
}
