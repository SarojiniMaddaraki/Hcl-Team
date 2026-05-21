import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { PatientService } from '../../patient.service'; // Up 2 levels to parent patient folder
import { Patient } from '../../patient.models';   // Up 2 levels to parent patient folder

@Component({
  selector: 'app-patient-manage',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './patient-manage.html',
  styleUrls: ['./patient-manage.css']
})
export class PatientManageComponent implements OnInit {
  private fb = inject(FormBuilder);
  private patientService = inject(PatientService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  patientForm: FormGroup = this.fb.group({
    fullName: ['', [Validators.required]],
    dateOfBirth: ['', [Validators.required]],
    gender: ['Male', [Validators.required]],
    phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]], 
    address: ['', [Validators.required]]
  });

  isEditMode = signal<boolean>(false);
  targetId = signal<number | null>(null);
  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.isEditMode.set(true);
      this.targetId.set(+idParam);
      this.loadPatientDetails(+idParam);
    }
  }

  loadPatientDetails(id: number): void {
    this.isLoading.set(true);
    this.patientService.getPatientById(id).subscribe({
      next: (patient: Patient) => { // Explicit type signature
        const formattedDate = patient.dateOfBirth ? patient.dateOfBirth.split('T')[0] : '';
        this.patientForm.patchValue({
          ...patient,
          dateOfBirth: formattedDate
        });
      },
      error: (err: any) => this.errorMessage.set(err.error?.message || 'Error executing retrieval operation.'),
      complete: () => this.isLoading.set(false)
    });
  }

  onSubmit(): void {
    if (this.patientForm.invalid) {
      this.patientForm.markAllAsTouched();
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set(null);
    const formPayload = this.patientForm.value;

    if (this.isEditMode()) {
      const updatedPayload: Patient = { ...formPayload, patientId: this.targetId()! };
      this.patientService.updatePatient(this.targetId()!, updatedPayload).subscribe({
        next: () => this.router.navigate(['/patient']),
        error: (err: any) => { this.errorMessage.set(err.error?.message || 'Update failed.'); this.isLoading.set(false); },
        complete: () => this.isLoading.set(false)
      });
    } else {
      this.patientService.createPatient(formPayload).subscribe({
        next: () => this.router.navigate(['/patient']),
        error: (err: any) => { this.errorMessage.set(err.error?.message || 'Creation failed.'); this.isLoading.set(false); },
        complete: () => this.isLoading.set(false)
      });
    }
  }
}