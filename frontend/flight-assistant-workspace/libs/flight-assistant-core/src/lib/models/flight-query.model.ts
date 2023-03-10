import { QueryRequest } from './query-request.model';

export interface FlightQuery extends QueryRequest {
  departureAirportId: number;
  arrivalAirportId: number;
  departureDate: Date;
  returnDate: Date;
  numberOfPassangers: number;
  currencyId: number;
}
