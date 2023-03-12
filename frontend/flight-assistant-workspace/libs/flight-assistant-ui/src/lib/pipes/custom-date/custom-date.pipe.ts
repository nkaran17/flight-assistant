import { Pipe, PipeTransform, NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { CustomDateFormatEnum } from './custom-date-format.enum';
import { MissingTextPipe } from '../missing-text';

@Pipe({
  name: 'customDate',
})
export class CustomDatePipe implements PipeTransform {
  constructor(private missingTextPipe: MissingTextPipe) {}

  transform(value: Date | string, ...args: unknown[]): string | null {
    if (value !== undefined && value !== null && value !== '') {
      if (args && args[0]) {
        switch (args[0]) {
          case CustomDateFormatEnum.CustomDateFormat: {
            return new DatePipe('en-US').transform(value, CustomDateFormatEnum.CustomDateFormat);
          }
          case CustomDateFormatEnum.CustomTimeFormat: {
            return new DatePipe('en-US').transform(value, CustomDateFormatEnum.CustomTimeFormat);
          }
          case CustomDateFormatEnum.CustomDateTimeFormat: {
            return new DatePipe('en-US').transform(value, CustomDateFormatEnum.CustomDateTimeFormat);
          }
          default: {
            return new DatePipe('en-US').transform(value, CustomDateFormatEnum.CustomDateTimeFormat);
          }
        }
      } else {
        return new DatePipe('en-US').transform(value, CustomDateFormatEnum.CustomDateTimeFormat);
      }
    } else {
      return this.missingTextPipe.transform(null);
    }
  }
}

@NgModule({
  imports: [CommonModule],
  declarations: [CustomDatePipe],
  exports: [CustomDatePipe],
  providers: [MissingTextPipe],
})
export class CustomDatePipeModule {}
