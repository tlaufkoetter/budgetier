import { Component, OnInit, Input } from '@angular/core';
import { CategoryBooking } from '../category-booking';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  @Input() bookings: CategoryBooking[]
  constructor() { }

  ngOnInit() {
  }

}
