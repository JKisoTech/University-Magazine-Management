import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from './model';


@Injectable({
    providedIn: 'root',
})
export class UserService {
    private baseUrl = 'http://localhost:3000/user';


    constructor( private http: HttpClient){}


    CreateUser(data: UserDto): Observable<any> {
        return this.http.post(this.baseUrl, data);
    }

    GetAllUser(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    DeleteUser(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetUserId(id: number) : Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    
    }

    UpdateUser(id: number, data: UserDto) : Observable<any> {
        return this.http.put(`${this.baseUrl}/${id}`, data)
    }
    
}