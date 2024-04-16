import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ContributionDto } from './model';

@Injectable({
    providedIn: 'root',
})

export class ContributionService {
    constructor( private http: HttpClient) {}

    private baseUrl = 'https://localhost:7101/api/Contribution';

    GetContributor(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetContributor`);
    }

    PostContribution(data: ContributionDto): Observable<any> {
        return this.http.post(`${this.baseUrl}/CreateContributor`, data);
    }

    uploadFile(formData: FormData): Observable<any> {
        return this.http.post(`${this.baseUrl}/upload`, formData);
    }

    

    
}