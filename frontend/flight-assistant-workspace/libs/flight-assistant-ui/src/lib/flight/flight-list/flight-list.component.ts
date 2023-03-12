import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { CustomAirportFormatEnum, CustomCurrencyFormatEnum, CustomDateFormatEnum } from '../../pipes';
import { FlightListUiService } from './flight-list-ui.service';

@Component({
  selector: 'flight-assistant-workspace-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss'],
})
export class FlightListComponent extends ComponentBase implements OnInit {
  customCurrencyFormatEnum = CustomCurrencyFormatEnum;
  customAirportFormatEnum = CustomAirportFormatEnum;
  customDateFormatEnum = CustomDateFormatEnum;

  public flightList$ = this.uiService.flightList$;
  public flightListTotalItems$ = this.uiService.flightListTotalItems$;
  public isLoading$ = this.uiService.isLoading$;
  public flightQuery: FlightQuery;

  constructor(router: Router, private uiService: FlightListUiService) {
    super('FlightListComponent', router);
  }

  ngOnInit(): void {
    this.subscribe(
      this.uiService.flightQuery$.subscribe((q) => {
        this.flightQuery = q;
      })
    );
  }

  onQuerySubmit(flightQuery: FlightQuery) {
    this.uiService.getFlightsFromQuery(flightQuery);
  }

  paginatorChange(data: { first: number; rows: number }) {
    const newPage = (data.first + data.rows) / data.rows;
    this.uiService.getFlightsFromQuery({ ...this.flightQuery, page: newPage });
  }
}
