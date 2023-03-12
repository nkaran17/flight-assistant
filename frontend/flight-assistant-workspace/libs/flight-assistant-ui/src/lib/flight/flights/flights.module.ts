import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightsComponent } from './flights.component';

@NgModule({
  declarations: [FlightsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: FlightsComponent,
        children: [
          {
            path: 'list',
            loadChildren: () => import('../flight-list/flight-list.module').then((m) => m.FlightListModule),
          },
          { path: '', redirectTo: 'list', pathMatch: 'full' },
        ],
      },
    ]),
  ],
})
export class FlightsModule {}
