import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from './model';


@Injectable({
    providedIn: 'root',
})
export class UserService {
    private baseUrl = 'https://localhost:7101/User';


    constructor( private http: HttpClient){}


    CreateUser(data: UserDto): Observable<any> {
        return this.http.post(`${this.baseUrl}/CreateUser`, data);
    }

    GetAllUser(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetUser`);
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
    
    UserLogin(loginName: string, password: string): Observable<any> {
        const loginData = { loginName, password }; // Create an object with loginName and password
        return this.http.post(`${this.baseUrl}/Login`, loginData);
    }
    


}