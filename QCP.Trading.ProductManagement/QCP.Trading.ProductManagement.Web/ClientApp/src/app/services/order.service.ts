import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { BASE_API_URL } from '../app.constants';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = BASE_API_URL + "Order/";
  }

  getSales(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + "GetSalesByMonth")
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
