import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { AuthResponseDto, LoginRequestDto, RegisterRequestDto } from './auth.models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5190/api/auth'; // Match your ASP.NET Core port
  
  currentUser = signal<AuthResponseDto['user'] | null>(null);

  constructor() {
    this.loadTokenData();
  }

  login(credentials: LoginRequestDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => this.handleAuthSuccess(response))
    );
  }

  register(userData: RegisterRequestDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, userData);
  }

  logout(): void {
    localStorage.removeItem('jwt_token');
    localStorage.removeItem('user_session');
    this.currentUser.set(null);
  }

  getToken(): string | null {
    return localStorage.getItem('jwt_token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  hasRole(allowedRoles: string[]): boolean {
    const user = this.currentUser();
    return user ? allowedRoles.includes(user.role) : false;
  }

  private handleAuthSuccess(response: AuthResponseDto): void {
    localStorage.setItem('jwt_token', response.token);
    localStorage.setItem('user_session', JSON.stringify(response.user));
    this.currentUser.set(response.user);
  }

  private loadTokenData(): void {
    const savedUser = localStorage.getItem('user_session');
    if (savedUser) {
      this.currentUser.set(JSON.parse(savedUser));
    }
  }
}