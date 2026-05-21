export interface MedicalRecord {
  recordId: number;
  patientId: number;
  diagnosis: string;
  treatment: string;
  visitDate: string;
}

export interface Prescription {
  prescriptionId: number;
  recordId: number;
  doctorId: number;
  medicineName: string;
  dosage: string;
  instructions: string;
}