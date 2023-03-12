import { formatDate } from '@angular/common';
import { Inject, Injectable, LOCALE_ID } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class HelperService {
  constructor(@Inject(LOCALE_ID) private locale: string) {}

  public formatDateTime(date: Date): string {
    return formatDate(date, 'yyyy-MM-dd', this.locale);
  }
}
