import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list.component';
import { FlightQueryFormModule } from '../flight-query-form';

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
  ],
})
export class FlightListModule {}
