import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightQueryFormComponent } from './flight-query-form.component';

describe('FlightQueryFormComponent', () => {
  let component: FlightQueryFormComponent;
  let fixture: ComponentFixture<FlightQueryFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightQueryFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FlightQueryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
