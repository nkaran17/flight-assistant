import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlightQueryFormComponent } from './flight-query-form.component';
import { CalendarModule } from 'primeng/calendar';
import { ButtonModule } from 'primeng/button';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { CardModule } from 'primeng/card';
import { InputNumberModule } from 'primeng/inputnumber';

@NgModule({
  declarations: [FlightQueryFormComponent],
  imports: [
    CommonModule,
    CalendarModule,
    ButtonModule,
    DropdownModule,
    ReactiveFormsModule,
    CardModule,
    InputNumberModule,
  ],
  exports: [FlightQueryFormComponent],
})
export class FlightQueryFormModule {}
