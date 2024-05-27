import { Ticket } from "./ticket.model";

export interface Customer {
  id: number;
  name: string;
  email: string;
  birthDate: Date;
  tickets: Ticket[];
}
