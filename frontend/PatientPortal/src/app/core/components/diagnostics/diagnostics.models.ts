export interface VitalSign {
  vitalsId: number;
  patientId: number;
  recordedDate: string; // ISO Date String
  bloodPressure: string; // e.g., "120/80"
  heartRate: number;     // bpm
  temperature: number;   // Celsius or Fahrenheit
  weight: number;        // kg
}

export interface LabResult {
  labId: number;
  patientId: number;
  testName: string;      // e.g., "Lipid Panel", "CBC"
  testValue: string;     // e.g., "5.2" or "Normal"
  unit: string;          // e.g., "mmol/L", "g/dL"
  testDate: string;      // ISO Date String
  isNormal: boolean;
}