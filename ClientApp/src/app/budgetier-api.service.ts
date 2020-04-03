import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { CategoryReports } from './category-reports';
import { CategoryReport } from './category-report';
import { CategoryBooking } from './category-booking';

@Injectable({
  providedIn: 'root'
})
export class BudgetierApiService {

  private baseUrl: string = "/api"

  constructor(private http: HttpClient) { }

  getCategoryReports() : Observable<CategoryReports>
  {
    return this.http.get<CategoryReports>(this.baseUrl + '/categoryreports')
  }

  getCategoryReport(id: string) : Observable<CategoryReport>
  {
    return this.http.get<CategoryReport>(this.baseUrl + '/categoryreports/' + id)
  }

  getBooking(id: string) : Observable<CategoryBooking>
  {
    return this.http.get<CategoryBooking>(this.baseUrl + "/bookings/" + id)
  }

}
