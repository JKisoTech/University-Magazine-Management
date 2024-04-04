import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContributionDto } from './model';

@Injectable({
    providedIn: 'root',
})
export class ContributionService {
    private baseUrl = 'http://localhost:3000/contribution';

    constructor(private http: HttpClient){}

    CreateContribution(data: ContributionDto): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }

    GetAllContribution(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    DeleteContribution(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetContributionId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateContribution(id: number, data: ContributionDto) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
}