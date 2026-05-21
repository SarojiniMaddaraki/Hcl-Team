export interface LoginRequestDto {
  email: string;
  passwordHash: string; // Exact match to .NET Entity configuration
}

export interface RegisterRequestDto {
  name: string;
  email: string;
  passwordHash: string;
  role: string;
}

export interface AuthResponseDto {
  token: string;
  user: {
    userId: number;
    name: string;
    email: string;
    role: string;
  };
}