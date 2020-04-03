import { Component, OnInit, Input } from '@angular/core';
import { CategoryReport } from '../category-report';

@Component({
  selector: 'app-category-report-item',
  templateUrl: './category-report-item.component.html',
  styleUrls: ['./category-report-item.component.css']
})
export class CategoryReportItemComponent implements OnInit {
  @Input() report : CategoryReport;
  constructor() { }

  ngOnInit() {
  }

}
