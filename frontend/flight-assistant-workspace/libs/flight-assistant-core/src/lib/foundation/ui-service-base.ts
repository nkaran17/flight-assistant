import { Inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ServiceBase } from './service-base';

@Inject({})
export class UiServiceBase extends ServiceBase {
  protected isLoadingSubject = new BehaviorSubject<boolean>(false);
  protected isSavingSubject = new BehaviorSubject<boolean>(false);

  public readonly isLoading$ = this.isLoadingSubject.asObservable();
  public readonly isSaving$ = this.isSavingSubject.asObservable();

  constructor(public uiServiceName: string) {
    super(uiServiceName);
  }
}
