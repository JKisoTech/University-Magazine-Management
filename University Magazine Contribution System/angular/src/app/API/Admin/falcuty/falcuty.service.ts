import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FalcutyDTO } from './model';


@Injectable({
    providedIn: 'root',
})

export class FalcutyService {
    constructor(private http: HttpClient){}

    private baseUrl = 'http://localhost:3000/falcuty';

    CreateFalcuty(data: FalcutyDTO): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }

    GetAllFalcuty(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    DeleteFalcuty(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetFalcutyId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateFalcuty(id: number, data: FalcutyDTO) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
}