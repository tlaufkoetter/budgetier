import { Component, OnInit } from '@angular/core';
import { CategoryReports } from '../category-reports';
import { BudgetierApiService } from '../budgetier-api.service';

@Component({
  selector: 'app-categories',
  templateUrl: './category-reports.component.html',
  styleUrls: ['./category-reports.component.css']
})
export class CategoryReportsComponent implements OnInit {
  report: CategoryReports;
  constructor(private budgetierApi: BudgetierApiService)
  {
  }

  ngOnInit() {
    this.budgetierApi.getCategoryReports().subscribe(data => this.report = data);
  }


}
