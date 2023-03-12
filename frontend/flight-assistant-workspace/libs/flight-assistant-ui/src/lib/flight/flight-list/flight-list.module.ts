import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list.component';

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
  ],
})
export class FlightListModule {}
