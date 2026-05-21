import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DiagnosticsService } from '../diagnostics.service';
import { LabResult } from '../diagnostics.models';

@Component({
  selector: 'app-labs-report',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './labs-report.html',
  styleUrls: ['./labs-report.css']
})
export class LabsReportComponent implements OnInit {
  private diagnosticsService = inject(DiagnosticsService);
  private route = inject(ActivatedRoute);

  patientId = signal<number | null>(null);
  labs = signal<LabResult[]>([]);
  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('patientId');
    if (idParam) {
      this.patientId.set(+idParam);
      this.loadLabs(+idParam);
    } else {
      this.errorMessage.set('Target Patient ID routing context scope not declared.');
    }
  }

  loadLabs(patientId: number): void {
    this.isLoading.set(true);
    this.diagnosticsService.getLabResultsByPatient(patientId).subscribe({
      next: (data) => this.labs.set(data.sort((a,b) => new Date(b.testDate).getTime() - new Date(a.testDate).getTime())),
      error: (err) => this.errorMessage.set(err.error?.message || 'Failed to sync clinical workspace panel panels.'),
      complete: () => this.isLoading.set(false)
    });
  }
}