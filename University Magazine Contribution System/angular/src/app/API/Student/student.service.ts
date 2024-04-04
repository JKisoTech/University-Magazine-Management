import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { StudentDto } from './model';

@Injectable({
    providedIn: 'root',
})
export class StudentService {
    private baseUrl = 'http://localhost:3000/student';

    constructor( private http: HttpClient){}

    CreateStudent(data: StudentDto): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }

    GetAllStudent(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    DeleteStudent(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetStudentId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateUser(id: number, data: StudentDto) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
}