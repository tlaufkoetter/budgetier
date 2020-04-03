import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BudgetierApiService } from '../budgetier-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {

  constructor(private router: Router, private budgetierApi: BudgetierApiService) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm)
  {
    this.budgetierApi.createCatgory(form.form.get("name").value, form.form.get("budget").value).subscribe(data => this.router.navigate(['/categories']))
  }

}
