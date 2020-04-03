import { Component, OnInit, Input } from '@angular/core';
import { Booking } from '../booking';

@Component({
  selector: 'app-booking-item',
  templateUrl: './booking-item.component.html',
  styleUrls: ['./booking-item.component.css']
})
export class BookingItemComponent implements OnInit {
  @Input() booking: Booking
  constructor() { }

  ngOnInit() {
  }

}
