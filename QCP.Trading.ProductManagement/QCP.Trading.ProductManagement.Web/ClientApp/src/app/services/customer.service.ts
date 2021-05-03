import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { BASE_API_URL } from '../app.constants';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = BASE_API_URL + "Customer/";
  }

  getCustomers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + "GetAllCustomers")
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveCustomer(customer: any) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post<any>(this.apiUrl + "SaveCustomer", JSON.stringify(customer), { headers: headers })
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
