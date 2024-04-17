import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentDTO } from './model';

@Injectable({
    providedIn: 'root',
})
export class StudentService {
    constructor( private http: HttpClient){}
    private baseUrl = 'https://localhost:7101/api/Student';

    GetStudent(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetStudent`);
    }
    
    CreateStudent(data: StudentDTO): Observable<any> {
        const url = `${this.baseUrl}/CreateStudent`;
        return this.http.post(url, data, { responseType: 'text' });
    }
    
}