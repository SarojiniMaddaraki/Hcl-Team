import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitalsChart } from './vitals-chart';

describe('VitalsChart', () => {
  let component: VitalsChart;
  let fixture: ComponentFixture<VitalsChart>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VitalsChart],
    }).compileComponents();

    fixture = TestBed.createComponent(VitalsChart);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
