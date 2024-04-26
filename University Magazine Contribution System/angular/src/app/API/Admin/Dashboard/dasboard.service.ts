import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DashboardDTO } from './model';


@Injectable({
    providedIn: 'root'
  })
  export class DashboardService {
    private apiUrl = 'https://localhost:7101/api/SystemP';
  
    constructor(private http: HttpClient) {}
  
    getDashboardData(): Observable<DashboardDTO> {
      return this.http.get<DashboardDTO>(`${this.apiUrl}/Dashboard`);
    }

    getDashboardReport(): Observable<DashboardDTO[]> {
        return this.http.get<DashboardDTO[]>(`${this.apiUrl}/Report`);
    }
  }
