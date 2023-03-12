import { Injectable } from '@angular/core';
import { UiServiceBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { BehaviorSubject, lastValueFrom } from 'rxjs';
import { MessageService } from 'primeng/api';
import { Flight, FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { FlightService } from '@flight-assistant-workspace/flight-assistant-services/api-services';

@Injectable()
export class FlightListUiService extends UiServiceBase {
  private flightListSubject = new BehaviorSubject<Flight[]>([]);
  private flightListTotalItemsSubject = new BehaviorSubject<number>(0);
  private flightQuerySubject = new BehaviorSubject<FlightQuery>({
    departureAirportId: null,
    arrivalAirportId: null,
    departureDate: null,
    returnDate: null,
    currencyId: null,
    numberOfPassangers: null,
    page: 1,
    itemsPerPage: 10,
  });

  public readonly flightList$ = this.flightListSubject.asObservable();
  public readonly flightListTotalItems$ = this.flightListTotalItemsSubject.asObservable();
  public readonly flightQuery$ = this.flightQuerySubject.asObservable();

  constructor(private flightService: FlightService, private messageService: MessageService) {
    super(`FlightListUiService`);
  }

  public async getFlightsFromQuery(flightQuery: FlightQuery) {
    this.flightQuerySubject.next(flightQuery);
    try {
      this.isLoadingSubject.next(true);

      const flightListResult = await lastValueFrom(this.flightService.getFlightsFromQuery(flightQuery));

      this.flightListSubject.next(flightListResult.items);
      this.flightListTotalItemsSubject.next(flightListResult.totalItems);
    } catch (error) {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Flight list is not retrieved. Please try again.',
      });
      throw error;
    } finally {
      this.isLoadingSubject.next(false);
    }
  }
}
