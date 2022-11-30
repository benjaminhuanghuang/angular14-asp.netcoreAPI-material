import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';

import {Observable} from 'rxjs';
import { ResponseApi } from '../Interfaces/response-api';
import { Employee } from '../Interfaces/employee';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint: string = environment.endpoint;
  private apiUrl:string = this.endpoint + "api/employee";

  constructor(private http:HttpClient) { }

  getList():Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.apiUrl);
  }

  add(request:Employee):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(this.apiUrl, request);
  }

  update(request:Employee):Observable<ResponseApi>{
    return this.http.put<ResponseApi>(this.apiUrl, request);
  }

  delete(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.apiUrl}/${id}`);
  }
}
