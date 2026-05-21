import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabsReport } from './labs-report';

describe('LabsReport', () => {
  let component: LabsReport;
  let fixture: ComponentFixture<LabsReport>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LabsReport],
    }).compileComponents();

    fixture = TestBed.createComponent(LabsReport);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
