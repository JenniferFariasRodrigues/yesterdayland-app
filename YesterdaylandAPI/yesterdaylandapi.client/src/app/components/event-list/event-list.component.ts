  import { Component, OnInit } from '@angular/core';
  import { ApiService } from '../../services/api.service';
  import { Event } from '../../models/event.model';
  import { EventService } from '../../services/event.service';

  @Component({
    selector: 'app-event-list',
    templateUrl: './event-list.component.html',
    styleUrl: './event-list.component.css'
  })
  export class EventListComponent implements OnInit {
    events: Event[] = [];

    constructor(private eventService: EventService) { }

    ngOnInit(): void {
      this.eventService.getEvents().subscribe((data: Event[]) => {
        this.events = data;
      });
    }
  }
