import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VitalSign, LabResult } from './diagnostics.models';

@Injectable({
  providedIn: 'root'
})
export class DiagnosticsService {
  private http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:5190/api'; // Matches your backend server configuration

  getVitalsByPatient(patientId: number): Observable<VitalSign[]> {
    return this.http.get<VitalSign[]>(`${this.baseUrl}/vitalsign/patient/${patientId}`);
  }

  addVitalSign(vitals: Omit<VitalSign, 'vitalsId'>): Observable<VitalSign> {
    return this.http.post<VitalSign>(`${this.baseUrl}/vitalsign`, vitals);
  }

  getLabResultsByPatient(patientId: number): Observable<LabResult[]> {
    return this.http.get<LabResult[]>(`${this.baseUrl}/labresult/patient/${patientId}`);
  }

  addLabResult(lab: Omit<LabResult, 'labId'>): Observable<LabResult> {
    return this.http.post<LabResult>(`${this.baseUrl}/labresult`, lab);
  }
}