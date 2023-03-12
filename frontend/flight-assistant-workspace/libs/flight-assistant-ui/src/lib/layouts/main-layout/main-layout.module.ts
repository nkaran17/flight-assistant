import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

import { MainLayoutComponent } from './main-layout.component';

@NgModule({
  declarations: [MainLayoutComponent],
  imports: [
    CommonModule,
    ButtonModule,
    RouterModule.forChild([
      {
        path: '',
        component: MainLayoutComponent,
        children: [
          {
            path: 'flights',
            loadChildren: () => import('../../flight/flights').then((m) => m.FlightsModule),
          },
          { path: '', redirectTo: '/flights/list', pathMatch: 'full' },
        ],
      },
    ]),
    ProgressSpinnerModule,
  ],
})
export class MainLayoutModule {}
