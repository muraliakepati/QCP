import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { BASE_API_URL } from '../app.constants';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  apiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      "Access-Control-Allow-Origin": "true",
      'Content-Type': 'application/json; charset=utf-8',
      "Access-Control-Allow-Methods": "*",
      "Access-Control-Allow-Headers": "Content-Type",
      "Accept": "application/json",
      'Cache-Control': 'no-cache',
      'Pragma': 'no-cache',
      'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT'
    })
  };

  constructor(private http: HttpClient) {
    this.apiUrl = BASE_API_URL + "Supplier/";
  }

  getSuppliers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + "GetAllSuppliers")
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
