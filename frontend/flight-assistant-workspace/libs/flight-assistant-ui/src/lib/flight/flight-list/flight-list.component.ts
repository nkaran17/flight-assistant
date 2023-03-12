import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { FlightListUiService } from './flight-list-ui.service';

@Component({
  selector: 'flight-assistant-workspace-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss'],
})
export class FlightListComponent extends ComponentBase {
  public flightList$ = this.uiService.flightList$;
  public flightListQuery$ = this.uiService.flightListQuery$;
  public isLoading$ = this.uiService.isLoading$;

  constructor(router: Router, private uiService: FlightListUiService) {
    super('FlightListComponent', router);
  }

  onQuerySubmit(flightQuery: FlightQuery) {
    this.uiService.getFlightsFromQuery(flightQuery);
  }
}
