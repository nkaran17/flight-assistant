import { Inject, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Inject({})
export class ComponentBase implements OnDestroy {
  componentName: string;
  subscriptions: Subscription = new Subscription();

  constructor(componentName: string, public router: Router) {
    this.componentName = componentName;
  }

  subscribe(subscription: Subscription) {
    this.subscriptions.add(subscription);
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  public routeTo(routeName: string) {
    try {
      this.router.navigate([routeName]);
      // eslint-disable-next-line no-empty
    } catch (error) {}
  }
}
