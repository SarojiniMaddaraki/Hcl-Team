import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { LoginComponent } from './login'; // Fixed class import name
import { AuthService } from '../../../auth/auth';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  // Mock services to prevent runtime dependency injection errors
  const mockAuthService = {
    login: () => of({ token: 'mock-jwt' }),
    currentUser: () => ({ userId: 1, name: 'Dr. John Doe' })
  };

  const mockRouter = {
    navigate: jasmine.createSpy('navigate')
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginComponent, ReactiveFormsModule], // Load the real standalone component
      providers: [
        { provide: AuthService, useValue: mockAuthService },
        { provide: Router, useValue: mockRouter },
        { 
          provide: ActivatedRoute, 
          useValue: { snapshot: { paramMap: { get: () => '1' } } } 
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges(); // Triggers Angular change detection cycle
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});