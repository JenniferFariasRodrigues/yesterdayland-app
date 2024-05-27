
import { Ticket } from "./ticket.model";

export interface Event {
  id: number;
  name: string;
  date: Date;
  type: string;
  tickets: Ticket[];
}
