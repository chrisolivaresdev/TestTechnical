import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse, AuthResponse, Login, Register, } from '../interface/interface';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

   baseUrl="http://localhost:5001/api"

  constructor(private http: HttpClient) { }

  login(form:Login): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.baseUrl}/Auth/login`, form).pipe(
      tap((response: AuthResponse) => {
        localStorage.setItem('token', response.token);
      })
    );;
  }

  register(form:Register): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}/Auth/register`, form);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
  }
}
