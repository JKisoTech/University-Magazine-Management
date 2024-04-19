import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


import { ContributionDto } from './model';

@Injectable({
    providedIn: 'root',
})
export class ContributionService {
    constructor(private http: HttpClient) {}

    private baseUrl = 'https://localhost:7101/api/Contribution';

    GetContributor(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetContributor`);
    }

    PostContribution(data: ContributionDto, file: File): Observable<any> {
        const user_id = data.studentID;
        const content = encodeURIComponent(data.content);
        const title = encodeURIComponent(data.title);
        const description = encodeURIComponent(data.description);
      
        const url = `${this.baseUrl}/CreateContributor?user_id=${user_id}&content=${content}&title=${title}&description=${description}`;
      
        const formData = new FormData();
        formData.append('type', file);
      
        return this.http.post(url, formData, { responseType: 'text' });
    }

      
    GetContributorId(contributionId: string): Observable<any> {
        const url = `${this.baseUrl}/GetContent?Id=${contributionId}`;
        return this.http.get(url);
    }

    UpdateContributor(data: ContributionDto, file: File) : Observable<any>{
        const id = data.contributionID;
        const content = encodeURIComponent(data.content);
        const title = encodeURIComponent(data.title);
        const description = encodeURIComponent(data.description);

        const url = `${this.baseUrl}/UpdateContributor?id=${id}&content=${content}&title=${title}&description=${description}`;

        
        const formData = new FormData();
        formData.append('type', file);
        
        return this.http.put(url, formData , { responseType: 'text' });
    }
      
}