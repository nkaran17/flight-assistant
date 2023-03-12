import { Pipe, PipeTransform, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomAirportFormatEnum } from './custom-airport-format.enum';
import { MissingTextPipe } from '../missing-text';
import { CoodebookService } from '@flight-assistant-workspace/flight-assistant-services/services';

@Pipe({
  name: 'customAirport',
})
export class CustomAirportPipe implements PipeTransform {
  constructor(private codebookService: CoodebookService, private missingTextPipe: MissingTextPipe) {}

  transform(value: number, ...args: unknown[]): string | null {
    if (value !== undefined && value !== null && value > 0) {
      if (args && args[0]) {
        switch (args[0]) {
          case CustomAirportFormatEnum.Iata: {
            return this.codebookService.getAirportById(value)?.iata;
          }
          case CustomAirportFormatEnum.Icao: {
            return this.codebookService.getAirportById(value)?.icao;
          }
          case CustomAirportFormatEnum.Name: {
            return this.codebookService.getAirportById(value)?.name;
          }
          case CustomAirportFormatEnum.Location: {
            return this.codebookService.getAirportById(value)?.location;
          }
          case CustomAirportFormatEnum.NameAndIata: {
            const airport = this.codebookService.getAirportById(value);
            if (airport) {
              return `${airport.name} (${airport.iata})`;
            } else {
              return this.missingTextPipe.transform(null);
            }
          }
          default: {
            return 'Invalid airport format';
          }
        }
      } else {
        return 'Missing airport format';
      }
    } else {
      return this.missingTextPipe.transform(null);
    }
  }
}

@NgModule({
  imports: [CommonModule],
  declarations: [CustomAirportPipe],
  exports: [CustomAirportPipe],
  providers: [MissingTextPipe],
})
export class CustomAirportPipeModule {}
