import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl = environment.apiUrl ;

  constructor(private _Http : HttpClient) { }

  getSomeEmployees(pageNum : number = 1 , pageSize:number = 12):Observable<any>{
    return this._Http.get(`${this.baseUrl}/Employee/pagination/${pageNum}/${pageSize}`);
  }

  getAllEmployees():Observable<any>{
    return this._Http.get(`${this.baseUrl}/Employee`);
  }

  SearchForEmployee(searchTerm : string):Observable<any>{
    return this._Http.get(`${this.baseUrl}/Employee/search/${searchTerm}`);
  }

  DeleteEmployee(id:number):Observable<any>{
    return this._Http.delete(`${this.baseUrl}/Employee/${id}`);
  }


  AddEmployee(data:FormGroup):Observable<any>{
    return this._Http.post(`${this.baseUrl}/Employee` , data);
  }

  UpdateEmployee(id:number , data:any):Observable<any>{
    return this._Http.put(`${this.baseUrl}/Employee/${id}`,data);
  }

  getEmployeeById(id:number):Observable<any>{
    return this._Http.get(`${this.baseUrl}/Employee/${id}`);
  }




}
