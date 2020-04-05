import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BudgetierApiService } from '../budgetier-api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.css']
})
export class CreateBookingComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private budgetierApi: BudgetierApiService) { }
  categoryId: string
  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
  }

  onSubmit(form : NgForm)
  {
    this.budgetierApi.createBooking(
      form.form.get("title").value,
      form.form.get("amount").value,
      form.form.get("timeStamp").value,
      this.categoryId,
      form.form.get("subCategoryName").value
    ).subscribe(data => this.router.navigate(['/categories/' + this.categoryId]))
  }

}
