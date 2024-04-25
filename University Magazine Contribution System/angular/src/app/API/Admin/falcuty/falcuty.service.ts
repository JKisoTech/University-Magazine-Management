import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FacultyDTO } from './model';


@Injectable({
    providedIn: 'root',
})

export class FalcutyService {
    constructor(private http: HttpClient){}

    private baseUrl = 'https://localhost:7101/api/Faculty';

    
    GetAllFalcuty(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetFaculty`);
    }

    DeleteFalcuty(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetFalcutyId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateFalcuty(id: number, data: FacultyDTO) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
    
    GetContributionbyFaculty(facultyID: string): Observable<any>{
        const url = `${this.baseUrl}/GetContribution?id=${facultyID}`;
        return this.http.get(url)

    }
}