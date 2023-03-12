import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { config } from '@flight-assistant-workspace/flight-assistant-core/config';
import { Currency } from '@flight-assistant-workspace/flight-assistant-core/models';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  private readonly baseUrl: string = `${config.API_URL}/Currencies`;

  constructor(private _http: HttpClient) {}

  public getCurrencies(): Observable<Currency[]> {
    return this._http.get<Currency[]>(`${this.baseUrl}`);
  }
}
