export interface FlightQuery {
  departureAirportId: number;
  arrivalAirportId: number;
  departureDate: Date;
  returnDate: Date;
  numberOfPassangers: number;
  currencyId: number;
}
