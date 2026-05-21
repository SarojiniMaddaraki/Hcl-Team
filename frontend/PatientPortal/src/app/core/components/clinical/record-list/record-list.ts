import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ClinicalService } from '../clinical.service';
import { MedicalRecord, Prescription } from '../clinical.models';

@Component({
  selector: 'app-record-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './record-list.html',
  styleUrls: ['./record-list.css']
})
export class RecordListComponent implements OnInit {
  private clinicalService = inject(ClinicalService);
  private route = inject(ActivatedRoute);

  patientId = signal<number | null>(null);
  records = signal<MedicalRecord[]>([]);
  selectedPrescriptions = signal<Prescription[]>([]);
  activeRecordId = signal<number | null>(null);

  isLoading = signal<boolean>(false);
  isLoadingPrescriptions = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('patientId');
    if (idParam) {
      this.patientId.set(+idParam);
      this.loadMedicalRecords(+idParam);
    } else {
      this.errorMessage.set('No Patient Context provided in URL parameters.');
    }
  }

  loadMedicalRecords(patientId: number): void {
    this.isLoading.set(true);
    this.clinicalService.getMedicalRecordsByPatient(patientId).subscribe({
      next: (data: MedicalRecord[]) => this.records.set(data),
      error: (err: any) => this.errorMessage.set(err.error?.message || 'Failed to sync clinical records.'),
      complete: () => this.isLoading.set(false)
    });
  }

  viewPrescriptions(recordId: number): void {
    this.activeRecordId.set(recordId);
    this.isLoadingPrescriptions.set(true);
    this.selectedPrescriptions.set([]);

    this.clinicalService.getPrescriptionsByRecord(recordId).subscribe({
      next: (data: Prescription[]) => this.selectedPrescriptions.set(data),
      error: (err: any) => this.errorMessage.set(err.error?.message || 'Failed to sync medical scripts.'),
      complete: () => this.isLoadingPrescriptions.set(false)
    });
  }
}