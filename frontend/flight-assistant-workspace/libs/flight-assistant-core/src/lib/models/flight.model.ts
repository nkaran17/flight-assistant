export interface Flight {
  id: number;
  departureAirportId: number;
  arrivalAirportId: number;
  departureDate: Date;
  arrivalDate: Date;
  returnDate: Date;
  numberOfPassangers: number;
  numberOfLayovers: number;
  currencyId: number;
  grandTotalPrice: number;
}
