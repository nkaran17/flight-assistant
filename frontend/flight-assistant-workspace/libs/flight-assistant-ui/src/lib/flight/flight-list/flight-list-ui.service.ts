import { Injectable } from '@angular/core';
import { UiServiceBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { BehaviorSubject, lastValueFrom } from 'rxjs';
import { MessageService } from 'primeng/api';
import { Flight, FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { FlightService } from '@flight-assistant-workspace/flight-assistant-services/api-services';

@Injectable()
export class FlightListUiService extends UiServiceBase {
  private flightListSubject = new BehaviorSubject<Flight[]>([]);
  private flightListQuerySubject = new BehaviorSubject<FlightQuery>(null);

  public readonly flightList$ = this.flightListSubject.asObservable();
  public readonly flightListQuery$ = this.flightListQuerySubject.asObservable();

  constructor(private flightService: FlightService, private messageService: MessageService) {
    super(`FlightListUiService`);
  }

  public async getFlightsFromQuery(flightQuery: FlightQuery) {
    try {
      this.isLoadingSubject.next(true);

      const flightListResult = await lastValueFrom(this.flightService.getFlightsFromQuery(flightQuery));
      this.flightListQuerySubject.next(flightQuery);
      this.flightListSubject.next(flightListResult.items);
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
