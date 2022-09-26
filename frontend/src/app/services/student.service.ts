import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student';


const httpOptions = {
  headers:new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  url='https://localhost:7062/api/Pessoas';


  constructor(private http:HttpClient) { }

  PegarTodos(): Observable<Student[]>{
    return this.http.get<Student[]>(this.url);
  }

  PegarPeloId(id:number): Observable<Student>{
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Student>(apiUrl);
  }

  SalvarPessoa(pessoa:Student) : Observable<any>{
    return this.http.post<Student>(this.url, pessoa, httpOptions);
  }

  AutalizarPessoa(pessoa:Student) : Observable<any>{
    return this.http.put<Student>(this.url, pessoa, httpOptions);
  }

  ExcluirPessoa(id:number):Observable<any>{
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
