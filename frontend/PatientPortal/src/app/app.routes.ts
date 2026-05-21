import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';

export const routes: Routes = [
  // Authentication Routes
  // Authentication Routes
  {
    path: 'login',
    loadComponent: () => 
      import('./core/components/auth/login/login').then(m => m.LoginComponent) // Adjusted name to match file schema
  },

  // Core Application Layout Container Shell Wrap
  {
    path: '',
    canActivate: [authGuard],
    children: [
      // Fallback redirection entry path hook
      { path: '', redirectTo: 'patient', pathMatch: 'full' },

      // Step 2: Core Patient Registration & Identity Profile Management Subtree
      {
        path: 'patient',
        loadComponent: () => 
          import('./core/components/patient/list/patient-list/patient-list').then(m => m.PatientListComponent)
      },
      {
        path: 'patient/new',
        loadComponent: () => 
          import('./core/components/patient/manage/patient-manage/patient-manage').then(m => m.PatientManageComponent)
      },
      {
        path: 'patient/edit/:id',
        loadComponent: () => 
          import('./core/components/patient/manage/patient-manage/patient-manage').then(m => m.PatientManageComponent)
      },

      // Step 3: Clinical Charts, Medical Records & Prescription Management Subtree
      {
        path: 'clinical/records/:patientId',
        loadComponent: () => 
          import('./core/components/clinical/record-list/record-list').then(m => m.RecordListComponent)
      },
      {
        path: 'prescription/new/:recordId',
        loadComponent: () => 
          import('./core/components/clinical/prescription-add/prescription-add').then(m => m.PrescriptionAddComponent)
      },

      // Step 4: Physiological Vitals & Laboratory Pathology Tracker Subtree
      {
        path: 'diagnostics/vitals/:patientId',
        loadComponent: () => 
          import('./core/components/diagnostics/vitals-chart/vitals-chart').then(m => m.VitalsChartComponent)
      },
      {
        path: 'diagnostics/labs/:patientId',
        loadComponent: () => 
          import('./core/components/diagnostics/labs-report/labs-report').then(m => m.LabsReportComponent)
      }
    ]
  },

  // Catch-All Wildcard Fallback Router Boundary
  { path: '**', redirectTo: 'patient' }
];