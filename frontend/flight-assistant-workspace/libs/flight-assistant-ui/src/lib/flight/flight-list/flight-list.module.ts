import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list.component';
import { FlightQueryFormModule } from '../flight-query-form';
import { FlightListUiService } from './flight-list-ui.service';
import { TableModule } from 'primeng/table';
import { CustomAirportPipeModule, CustomCurrencyPipeModule, CustomDatePipeModule } from '../../pipes';

@NgModule({
  declarations: [FlightListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: FlightListComponent,
      },
    ]),
    FlightQueryFormModule,
    TableModule,
    CustomCurrencyPipeModule,
    CustomAirportPipeModule,
    CustomDatePipeModule,
  ],
  providers: [FlightListUiService],
})
export class FlightListModule {}
