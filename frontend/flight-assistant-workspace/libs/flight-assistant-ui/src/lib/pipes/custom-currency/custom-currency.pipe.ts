import { Pipe, PipeTransform, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomCurrencyFormatEnum } from './custom-currency-format.enum';
import { MissingTextPipe } from '../missing-text';
import { CoodebookService } from '@flight-assistant-workspace/flight-assistant-services/services';

@Pipe({
  name: 'customCurrency',
})
export class CustomCurrencyPipe implements PipeTransform {
  constructor(private codebookService: CoodebookService, private missingTextPipe: MissingTextPipe) {}

  transform(value: number, ...args: unknown[]): string | null {
    if (value !== undefined && value !== null && value > 0) {
      if (args && args[0]) {
        switch (args[0]) {
          case CustomCurrencyFormatEnum.Name: {
            return this.codebookService.getCurrencyById(value)?.name;
          }
          case CustomCurrencyFormatEnum.AlphabeticCode: {
            return this.codebookService.getCurrencyById(value)?.alphabeticCode;
          }
          default: {
            return 'Invalid currency format';
          }
        }
      } else {
        return 'Missing currency format';
      }
    } else {
      return this.missingTextPipe.transform(null);
    }
  }
}

@NgModule({
  imports: [CommonModule],
  declarations: [CustomCurrencyPipe],
  exports: [CustomCurrencyPipe],
  providers: [MissingTextPipe],
})
export class CustomCurrencyPipeModule {}
