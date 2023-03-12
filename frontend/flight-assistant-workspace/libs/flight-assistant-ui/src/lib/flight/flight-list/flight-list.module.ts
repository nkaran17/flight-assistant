import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list.component';
import { FlightQueryFormModule } from '../flight-query-form';
import { FlightListUiService } from './flight-list-ui.service';

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
  providers: [FlightListUiService],
})
export class FlightListModule {}
