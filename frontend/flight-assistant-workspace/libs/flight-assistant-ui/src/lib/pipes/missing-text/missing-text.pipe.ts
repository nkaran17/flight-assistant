import { Pipe, PipeTransform, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@Pipe({
  name: 'missingText',
})
export class MissingTextPipe implements PipeTransform {
  transform(value: string, ...args: string[]): string {
    if (value === undefined || value === null || value === '' || value.length < 1) {
      if (args && args[0]) {
        return args[0];
      } else {
        return '-';
      }
    }
    return value;
  }
}

@NgModule({
  imports: [CommonModule],
  declarations: [MissingTextPipe],
  exports: [MissingTextPipe],
})
export class MissingTextPipeModule {}
