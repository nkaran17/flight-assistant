import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { config } from '@flight-assistant-workspace/flight-assistant-core/config';
import { Airport } from '@flight-assistant-workspace/flight-assistant-core/models';

@Injectable({
  providedIn: 'root',
})
export class AirportService {
  private readonly baseUrl: string = `${config.API_URL}/Airports`;

  constructor(private _http: HttpClient) {}

  public getAirports(): Observable<Airport[]> {
    return this._http.get<Airport[]>(`${this.baseUrl}`);
  }
}
