import { Component, OnInit, Input } from '@angular/core';
import { Booking } from '../booking';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  @Input() bookings: Booking[]
  constructor() { }

  ngOnInit() {
  }

}
