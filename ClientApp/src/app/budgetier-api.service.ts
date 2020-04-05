import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { CategoryReports } from './category-reports';
import { CategoryReport } from './category-report';
import { CategoryBooking } from './category-booking';
import { Category } from './category';

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

  createCatgory(name: string, budget: number) : Observable<Category>
  {
    var body = {name: name}
    if (budget > 0.01)
      body['budget'] = budget
    return this.http.post<Category>(this.baseUrl + '/categories', body)
  }

  createBooking(title: string, amount: number, timeStamp: Date, categoryId: string, subCategoryName: string) : Observable<CategoryBooking>
  {
    let body = {
      title: title,
      amount: amount,
      timeStamp: timeStamp,
      categoryId: categoryId,
      subCategoryName: subCategoryName
    }

    return this.http.post<CategoryBooking>(this.baseUrl + '/bookings', body)
  }

  getCategories(parentId: string = null)
  {
    var params = "";
    if (parentId)
      params = "?parentId=" + parentId

    return this.http.get<Category[]>(this.baseUrl + '/categories' + params)
  }

}
