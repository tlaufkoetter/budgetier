import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BudgetierApiService } from '../budgetier-api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'; 
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.css']
})
export class CreateBookingComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private budgetierApi: BudgetierApiService) { }
  myControl = new FormControl()
  categoryId: string
  categories$: Observable<string[]>
  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');
    this.categories$ = this.budgetierApi.getCategories(this.categoryId).pipe( map(cats => cats.map(c => c.name)))
  }

  onSubmit(form : NgForm)
  {
    this.budgetierApi.createBooking(
      form.form.get("title").value,
      form.form.get("amount").value,
      form.form.get("timeStamp").value,
      this.categoryId,
      this.myControl.value
    ).subscribe(data => this.router.navigate(['/categories/' + this.categoryId]))
  }

}
