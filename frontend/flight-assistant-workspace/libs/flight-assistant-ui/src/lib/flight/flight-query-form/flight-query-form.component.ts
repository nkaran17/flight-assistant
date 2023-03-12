import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComponentBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { FlightQuery } from '@flight-assistant-workspace/flight-assistant-core/models';
import { CoodebookService } from '@flight-assistant-workspace/flight-assistant-services/services';

@Component({
  selector: 'flight-assistant-workspace-flight-query-form',
  templateUrl: './flight-query-form.component.html',
  styleUrls: ['./flight-query-form.component.scss'],
})
export class FlightQueryFormComponent extends ComponentBase {
  @Output() querySubmit = new EventEmitter<FlightQuery>();

  flightQueryForm: FormGroup = this._fb.group({
    departureAirportId: [null, [Validators.required]],
    arrivalAirportId: [null, [Validators.required]],
    departureDate: [null, [Validators.required]],
    returnDate: [null],
    numberOfPassangers: [null, [Validators.required]],
    currencyId: [null],
  });

  airports$ = this.codebookService.airports$;
  currencies$ = this.codebookService.currencies$;

  constructor(router: Router, private _fb: FormBuilder, private codebookService: CoodebookService) {
    super('FlightQueryFormComponent', router);
  }

  onReset() {
    this.flightQueryForm.reset();
  }

  onSubmit() {
    if (!this.flightQueryForm || !this.flightQueryForm.value || this.flightQueryForm.invalid) {
      return;
    }
    this.querySubmit.emit({
      departureAirportId: this.flightQueryForm.value.departureAirportId,
      arrivalAirportId: this.flightQueryForm.value.arrivalAirportId,
      departureDate: this.flightQueryForm.value.departureDate,
      returnDate: this.flightQueryForm.value.returnDate,
      numberOfPassangers: this.flightQueryForm.value.numberOfPassangers,
      currencyId: this.flightQueryForm.value.currencyId,
    });
  }
}
