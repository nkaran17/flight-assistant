import { Inject, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Inject({})
export class ServiceBase implements OnDestroy {
  private subscriptions: Subscription = new Subscription();

  constructor(public serviceName: string) {}

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  subscribe(subscription: Subscription) {
    this.subscriptions.add(subscription);
  }
}
