import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicalRecord, Prescription } from './clinical.models';

@Injectable({
  providedIn: 'root'
})
export class ClinicalService {
  private http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:5190/api';

  getMedicalRecordsByPatient(patientId: number): Observable<MedicalRecord[]> {
    return this.http.get<MedicalRecord[]>(`${this.baseUrl}/medicalrecord/patient/${patientId}`);
  }

  getPrescriptionsByRecord(recordId: number): Observable<Prescription[]> {
    return this.http.get<Prescription[]>(`${this.baseUrl}/prescription/record/${recordId}`);
  }

  createPrescription(prescription: Omit<Prescription, 'prescriptionId'>): Observable<Prescription> {
    return this.http.post<Prescription>(`${this.baseUrl}/prescription`, prescription);
  }
}