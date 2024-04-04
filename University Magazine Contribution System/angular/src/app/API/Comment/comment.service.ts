import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommentDto } from './model';

@Injectable({
    providedIn: 'root',
})

export class CommentService {
    private baseUrl = 'http://localhost:3000/comment';

    constructor( private http : HttpClient){}

    CreateComment(data: CommentDto): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }

    GetAllComment(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    DeleteComment(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetCommentId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateComment(id: number, data: CommentDto) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
}