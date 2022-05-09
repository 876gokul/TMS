import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) { }
  baseurl = 'http://localhost:5148/';
  getUsersByRoleId(id: number) {
    return this.http.get(this.baseurl + `user/Role/${id}`);
  }
  getUsersById(id: number) {
    return this.http.get(this.baseurl + `${id}`);
  }
   postUser(data:any): Observable<any> {
    const headers = new Headers();
    headers.append('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<any>(this.baseurl + 'User', data)
  }
}
