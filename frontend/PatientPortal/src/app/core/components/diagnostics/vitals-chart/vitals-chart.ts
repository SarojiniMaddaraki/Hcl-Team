import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DiagnosticsService } from '../diagnostics.service';
import { VitalSign } from '../diagnostics.models';

@Component({
  selector: 'app-vitals-chart',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './vitals-chart.html',
  styleUrls: ['./vitals-chart.css']
})
export class VitalsChartComponent implements OnInit {
  private diagnosticsService = inject(DiagnosticsService);
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);

  patientId = signal<number | null>(null);
  vitalsList = signal<VitalSign[]>([]);
  
  vitalsForm!: FormGroup;
  isLoading = signal<boolean>(false);
  isSubmitting = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('patientId');
    if (idParam) {
      this.patientId.set(+idParam);
      this.loadVitals(+idParam);
      this.initForm(+idParam);
    } else {
      this.errorMessage.set('Context scope parameter missing: patientId context target required.');
    }
  }

  private initForm(patientId: number): void {
    this.vitalsForm = this.fb.group({
      patientId: [patientId, [Validators.required]],
      bloodPressure: ['', [Validators.required, Validators.pattern(/^\d{2,3}\/\d{2,3}$/)]], // Matches 120/80 layout
      heartRate: ['', [Validators.required, Validators.min(30), Validators.max(250)]],
      temperature: ['', [Validators.required, Validators.min(30), Validators.max(45)]],
      weight: ['', [Validators.required, Validators.min(1)]],
      recordedDate: [new Date().toISOString().split('T')[0], [Validators.required]]
    });
  }

  loadVitals(patientId: number): void {
    this.isLoading.set(true);
    this.diagnosticsService.getVitalsByPatient(patientId).subscribe({
      next: (data) => this.vitalsList.set(data.sort((a,b) => new Date(b.recordedDate).getTime() - new Date(a.recordedDate).getTime())),
      error: (err) => this.errorMessage.set(err.error?.message || 'Failed to sync vital history tracks.'),
      complete: () => this.isLoading.set(false)
    });
  }

  onSubmit(): void {
    if (this.vitalsForm.invalid) {
      this.vitalsForm.markAllAsTouched();
      return;
    }

    this.isSubmitting.set(true);
    this.diagnosticsService.addVitalSign(this.vitalsForm.value).subscribe({
      next: (newVital) => {
        this.vitalsList.update(current => [newVital, ...current]);
        this.vitalsForm.patchValue({
          bloodPressure: '',
          heartRate: '',
          temperature: '',
          weight: ''
        });
        this.vitalsForm.markAsPristine();
        this.vitalsForm.markAsUntouched();
      },
      error: (err) => this.errorMessage.set(err.error?.message || 'Failed to write validation sets upstream.'),
      complete: () => this.isSubmitting.set(false)
    });
  }
}