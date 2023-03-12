import { Injectable } from '@angular/core';
import { ServiceBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { Airport, Currency } from '@flight-assistant-workspace/flight-assistant-core/models';
import { BehaviorSubject, combineLatest, lastValueFrom } from 'rxjs';
import { AirportService } from '../api-services/airport.service';
import { CurrencyService } from '../api-services/currency.service';

@Injectable({
  providedIn: 'root',
})
export class CoodebookService extends ServiceBase {
  private isCodebookLoadInProgressSubject = new BehaviorSubject<boolean>(false);
  private isCodebookLoadFinishedSuccessfullySubject = new BehaviorSubject<boolean>(null);
  private currenciesSubject = new BehaviorSubject<Currency[]>([]);
  private airportsSubject = new BehaviorSubject<Airport[]>([]);

  public readonly isCodebookLoadInProgress$ = this.isCodebookLoadInProgressSubject.asObservable();
  public readonly isCodebookLoadFinishedSuccessfully$ = this.isCodebookLoadFinishedSuccessfullySubject.asObservable();
  public readonly currencies$ = this.currenciesSubject.asObservable();
  public readonly airports$ = this.airportsSubject.asObservable();

  constructor(private readonly currencyService: CurrencyService, private readonly airportService: AirportService) {
    super('CoodebookService');
  }

  public async loadCodebooks() {
    try {
      this.isCodebookLoadInProgressSubject.next(true);

      const [currencies, airports] = await lastValueFrom(
        combineLatest([this.currencyService.getCurrencies(), this.airportService.getAirports()])
      );

      this.currenciesSubject.next(currencies);
      this.airportsSubject.next(airports);

      this.isCodebookLoadFinishedSuccessfullySubject.next(true);
    } catch (err) {
      this.isCodebookLoadFinishedSuccessfullySubject.next(false);
    } finally {
      this.isCodebookLoadInProgressSubject.next(false);
    }
  }

  public getCurrencyById(id: number): Currency {
    return this.currenciesSubject.value?.find((c) => c.id === id);
  }

  public getAirportById(id: number): Airport {
    return this.airportsSubject.value?.find((a) => a.id === id);
  }
}
