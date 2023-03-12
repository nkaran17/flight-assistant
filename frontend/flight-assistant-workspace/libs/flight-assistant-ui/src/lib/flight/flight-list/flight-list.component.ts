import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { FlightService } from '@flight-assistant-workspace/flight-assistant-services/api-services';

@Component({
  selector: 'flight-assistant-workspace-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss'],
})
export class FlightListComponent extends ComponentBase {
  constructor(router: Router, private flightService: FlightService) {
    super('FlightListComponent', router);
  }

  onQuerySubmit(flightQuery: FlightQuery) {
    this.flightService.getFlightsFromQuery(flightQuery).subscribe((x) => console.log(x));
  }
}
