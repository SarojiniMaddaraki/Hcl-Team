import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ClinicalService } from '../clinical.service';
import { AuthService } from '../../../auth/auth'; // Synchronized hop check

@Component({
  selector: 'app-prescription-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './prescription-add.html',
  styleUrls: ['./prescription-add.css']
})
export class PrescriptionAddComponent implements OnInit {
  private fb = inject(FormBuilder);
  private clinicalService = inject(ClinicalService);
  private authService = inject(AuthService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  prescriptionForm!: FormGroup;
  recordId = signal<number | null>(null);
  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const recordIdParam = this.route.snapshot.paramMap.get('recordId');
    if (!recordIdParam) {
      this.errorMessage.set('Fatal context scope missing: Chart Record ID binding required.');
      return;
    }
    
    this.recordId.set(+recordIdParam);
    const activeDoctorId = this.authService.currentUser()?.userId || 1;

    this.prescriptionForm = this.fb.group({
      recordId: [this.recordId(), [Validators.required]],
      doctorId: [activeDoctorId, [Validators.required]],
      medicineName: ['', [Validators.required]],
      dosage: ['', [Validators.required]],
      instructions: ['Take after meals as instructed.', [Validators.required]]
    });
  }

  onSubmit(): void {
    if (this.prescriptionForm.invalid) {
      this.prescriptionForm.markAllAsTouched();
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.clinicalService.createPrescription(this.prescriptionForm.value).subscribe({
      next: () => {
        this.router.navigate(['/clinical/records', this.recordId()]);
      },
      error: (err: any) => {
        this.errorMessage.set(err.error?.message || 'Error committing clinical prescription entry upstream.');
        this.isLoading.set(false);
      },
      complete: () => this.isLoading.set(false)
    });
  }
}