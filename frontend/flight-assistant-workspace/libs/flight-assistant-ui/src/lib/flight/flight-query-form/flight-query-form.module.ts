import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlightQueryFormComponent } from './flight-query-form.component';

@NgModule({
  declarations: [FlightQueryFormComponent],
  imports: [CommonModule],
  exports: [FlightQueryFormComponent],
})
export class FlightQueryFormModule {}
