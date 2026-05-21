import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PatientService } from '../../patient.service'; // Up 2 levels to parent patient folder
import { Patient } from '../../patient.models';   // Up 2 levels to parent patient folder

@Component({
  selector: 'app-patient-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './patient-list.html',
  styleUrls: ['./patient-list.css']
})
export class PatientListComponent implements OnInit {
  private patientService = inject(PatientService);

  patients = signal<Patient[]>([]);
  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    this.loadPatients();
  }

  loadPatients(): void {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    // FIXED: Changed .getPatients() to .getAllPatients() to match your service file
    this.patientService.getAllPatients().subscribe({
      next: (response: any) => {
        // Safely unpack the envelope structure from your .NET API
        if (response && response.success && Array.isArray(response.data)) {
          this.patients.set(response.data);
        } else if (Array.isArray(response)) {
          this.patients.set(response);
        } else {
          this.patients.set([]);
        }
        this.isLoading.set(false);
      },
      error: (err: any) => {
        console.error('API Error details:', err);
        this.errorMessage.set('Failed to fetch clinical database entries.');
        this.isLoading.set(false);
      }
    });
  }
  onDelete(id: number): void {
    if (confirm('Are you absolutely certain you want to purge this patient record?')) {
      this.patientService.deletePatient(id).subscribe({
        next: () => {
          this.patients.update(current => current.filter(p => p.patientId !== id));
        },
        error: (err: any) => this.errorMessage.set(err.error?.message || 'Error occurred deleting patient record.')
      });
    }
  }
}