import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientManage } from './patient-manage';

describe('PatientManage', () => {
  let component: PatientManage;
  let fixture: ComponentFixture<PatientManage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatientManage],
    }).compileComponents();

    fixture = TestBed.createComponent(PatientManage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
