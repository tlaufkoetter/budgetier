import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryReportDetailComponent } from './category-report-detail/category-report-detail.component';
import { CategoryReportsComponent } from './category-reports/category-reports.component';


const routes: Routes = [
  { path: '', component: CategoryReportsComponent },
  { path: 'categories/:id', component: CategoryReportDetailComponent },
  { path: 'categories', component: CategoryReportsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
