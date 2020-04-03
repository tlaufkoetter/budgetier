import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryReport } from '../category-report';
import { BudgetierApiService } from '../budgetier-api.service';

@Component({
  selector: 'app-category-report-detail',
  templateUrl: './category-report-detail.component.html',
  styleUrls: ['./category-report-detail.component.css']
})
export class CategoryReportDetailComponent implements OnInit {
  report: CategoryReport

  constructor(private route: ActivatedRoute, private budgetierApi: BudgetierApiService) {
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.budgetierApi.getCategoryReport(id).subscribe(data => this.report = data)
  }

}
