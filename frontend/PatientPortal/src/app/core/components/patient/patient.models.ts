export interface Patient {
  patientId: number;
  fullName: string;
  dateOfBirth: string; // ISO String format handled across HTTP boundaries
  gender: string;
  phoneNumber: string;
  address: string;
}