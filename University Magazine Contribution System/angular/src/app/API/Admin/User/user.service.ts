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


    CreateUser(data: UserDto, facultyID: string): Observable<any> {
        const url = `${this.baseUrl}/CreateUser?facultyID=${facultyID}`;
        return this.http.post(url, data, { responseType: 'text' });
    }

    GetAllUser(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetUser`);
    }

    DeleteUser(id: number ) : Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }

    GetUserByLoginName(loginName: string): Observable<any> {
        const url = `${this.baseUrl}/GetUserByLoginName?_loginName=${loginName}`;
        return this.http.get(url);
      }

    UpdateUser(loginName: string, data: UserDto) : Observable<any> {
        return this.http.put(`${this.baseUrl}/UpdateUser/${loginName}`, data, { responseType: 'text' })
    }
    
    UserLogin(loginName: string, password: string): Observable<any> {
        // Construct the URL with query parameters
        const url = `${this.baseUrl}/Login?_loginName=${loginName}&_password=${password}`;
        // Send an empty object in the post request since data is passed in the URL
        return this.http.post(url, {});
      }

      GetUserRole(loginName: string): Observable<number | null> {
        return this.http.get<number | null>(`${this.baseUrl}/GetRole?_loginName=${loginName}`);
      }
      
      UpdateUserStatus(loginName: string, status: boolean): Observable<any> {
        const url = `${this.baseUrl}/Status/${loginName}?status=${status}`;
        return this.http.put(url, {});
      }

      ChangePassword(loginName: string, oldPassword: string, newPassword: string): Observable<any> {
        const url = `${this.baseUrl}/ChangePassword/${loginName}?_Oldpassword=${oldPassword}&_Newpassword=${newPassword}`;
        return this.http.put(url, {}, { responseType: 'text' }); // Specify responseType as 'text'
      }

      

      
    


}