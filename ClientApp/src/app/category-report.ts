import { Category } from './category';
import { Booking } from './booking';

export interface CategoryReport {
    category: Category
    spent: number
    bookings: Booking[]
}
