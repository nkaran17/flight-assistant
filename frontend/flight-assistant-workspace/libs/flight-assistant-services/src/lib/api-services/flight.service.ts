import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '@flight-assistant-workspace/flight-assistant-core/config';
import { Flight, FlightQuery, QueryResultResponse } from '@flight-assistant-workspace/flight-assistant-core/models';
import { Observable } from 'rxjs';
import { HelperService } from '@flight-assistant-workspace/flight-assistant-core/helpers';

@Injectable({
  providedIn: 'root',
})
export class FlightService {
  private readonly baseUrl: string = `${config.API_URL}/Flights`;

  constructor(private _http: HttpClient, private helperService: HelperService) {}

  public getFlightsFromQuery(flightQuery: FlightQuery): Observable<QueryResultResponse<Flight>> {
    let params = new HttpParams();

    if (flightQuery.page && flightQuery.page > 0) {
      params = params.append('page', flightQuery.page.toString());
    }

    if (flightQuery.itemsPerPage && flightQuery.itemsPerPage > 0) {
      params = params.append('itemsPerPage', flightQuery.itemsPerPage.toString());
    }

    if (flightQuery.departureAirportId && flightQuery.departureAirportId > 0) {
      params = params.append('departureAirportId', flightQuery.departureAirportId.toString());
    }

    if (flightQuery.arrivalAirportId && flightQuery.arrivalAirportId > 0) {
      params = params.append('arrivalAirportId', flightQuery.arrivalAirportId.toString());
    }

    if (flightQuery.currencyId && flightQuery.currencyId > 0) {
      params = params.append('currencyId', flightQuery.currencyId.toString());
    }

    if (flightQuery.numberOfPassangers && flightQuery.numberOfPassangers > 0) {
      params = params.append('numberOfPassangers', flightQuery.numberOfPassangers.toString());
    }

    if (flightQuery.departureDate) {
      params = params.append('departureDate', this.helperService.formatDateTime(flightQuery.departureDate));
    }

    if (flightQuery.returnDate) {
      params = params.append('returnDate', this.helperService.formatDateTime(flightQuery.returnDate));
    }

    return this._http.get<QueryResultResponse<Flight>>(`${this.baseUrl}`, { params: params });
  }
}
