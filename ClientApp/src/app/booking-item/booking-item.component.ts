import { Component, OnInit, Input } from '@angular/core';
import { Booking } from '../booking';
import { CategoryBooking } from '../category-booking';

@Component({
  selector: 'app-booking-item',
  templateUrl: './booking-item.component.html',
  styleUrls: ['./booking-item.component.css']
})
export class BookingItemComponent implements OnInit {
  @Input() booking: CategoryBooking
  constructor() { }

  ngOnInit() {
  }

}
