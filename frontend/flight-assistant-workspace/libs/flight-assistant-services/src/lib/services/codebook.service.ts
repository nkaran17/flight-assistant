import { Injectable } from '@angular/core';
import { ServiceBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { Currency } from '@flight-assistant-workspace/flight-assistant-core/models';
import { BehaviorSubject, combineLatest, lastValueFrom } from 'rxjs';
import { CurrencyService } from '../api-services/currency.service';

@Injectable({
  providedIn: 'root',
})
export class CoodebookService extends ServiceBase {
  private isCodebookLoadInProgressSubject = new BehaviorSubject<boolean>(false);
  private isCodebookLoadFinishedSuccessfullySubject = new BehaviorSubject<boolean>(null);
  private currenciesSubject = new BehaviorSubject<Currency[]>([]);

  public readonly isCodebookLoadInProgress$ = this.isCodebookLoadInProgressSubject.asObservable();
  public readonly isCodebookLoadFinishedSuccessfully$ = this.isCodebookLoadFinishedSuccessfullySubject.asObservable();
  public readonly currencies$ = this.currenciesSubject.asObservable();

  constructor(private readonly currencyService: CurrencyService) {
    super('CoodebookService');
  }

  public async loadCodebooks() {
    try {
      this.isCodebookLoadInProgressSubject.next(true);

      const [currencies] = await lastValueFrom(combineLatest([this.currencyService.getCurrencies()]));

      this.currenciesSubject.next(currencies);

      this.isCodebookLoadFinishedSuccessfullySubject.next(true);
    } catch (err) {
      this.isCodebookLoadFinishedSuccessfullySubject.next(false);
    } finally {
      this.isCodebookLoadInProgressSubject.next(false);
    }
  }
}
