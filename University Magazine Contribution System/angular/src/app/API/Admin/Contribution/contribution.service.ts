import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContributionDto } from './model';
import { CommentDTO } from './commentDTO';

@Injectable({
    providedIn: 'root',
})
export class ContributionService {
    constructor(private http: HttpClient) {}


    private baseUrl = 'https://localhost:7101/api/Contribution';

    GetContributor(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetContributor`);
    }
    GetComments(contributionID: string): Observable<any> {
        const url = `${this.baseUrl}/GetComment/${contributionID}`;
        return this.http.get(url);
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

      
    GetContent(contributionId: string): Observable<any> {
        const url = `https://localhost:7101/api/Contribution/GetContent?Id=${contributionId}`;
        return this.http.get(url, { responseType: 'text' });
    }

    GetContributionbyId(contributionId: string): Observable<any>{
        const url = `${this.baseUrl}/GetContribution/${contributionId}`;
        return this.http.get(url)
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
    UpdateContributorStatus(data: ContributionDto) : Observable<any>{ 
        const id = data.contributionID;
        const status = encodeURIComponent(data.status);
        const url = `${this.baseUrl}/UpdateContributorStatus?id=${id}&status=${status}`;

        return this.http.put(url, data);



    }
    
    UpdateComment(comment: CommentDTO): Observable<any> {
        const coordinatorId = encodeURIComponent(comment.coordinatorID);
        const contributionId = encodeURIComponent(comment.contributionID);
        const title = encodeURIComponent(comment.title);
        const comments = encodeURIComponent(comment.comments);
      
        const url = `${this.baseUrl}/UpdateContributorComment?_coordinatorId=${coordinatorId}&_contributionID=${contributionId}&title=${title}&comment=${comments}`;
      
        return this.http.put(url, null, { responseType: 'text' });
      }

      

    
      
}