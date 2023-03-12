import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from '@flight-assistant-workspace/flight-assistant-core/foundation';
import { CoodebookService } from '@flight-assistant-workspace/flight-assistant-services/services';

@Component({
  selector: 'flight-assistant-workspace-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss'],
})
export class MainLayoutComponent extends ComponentBase implements OnInit {
  constructor(router: Router, private readonly codebookService: CoodebookService) {
    super('MainLayoutComponent', router);
  }

  public isCodebookLoadInProgress$ = this.codebookService.isCodebookLoadInProgress$;
  public isCodebookLoadFinishedSuccessfully$ = this.codebookService.isCodebookLoadFinishedSuccessfully$;

  ngOnInit(): void {
    this.codebookService.loadCodebooks();
  }
}
