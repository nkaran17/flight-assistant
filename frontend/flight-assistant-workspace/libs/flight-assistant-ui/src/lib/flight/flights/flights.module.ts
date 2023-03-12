import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlightsComponent } from './flights.component';
import { CardModule } from 'primeng/card';

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
    CardModule,
  ],
})
export class FlightsModule {}
