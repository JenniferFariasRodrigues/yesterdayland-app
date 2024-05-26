import { Ticket } from "./Ticket";

export interface Customer {
  id: number;
  name: string;
  email: string;
  birthDate: Date;
  tickets: Ticket[];
}
