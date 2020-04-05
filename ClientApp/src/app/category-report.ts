import { Category } from './category';
import { CategoryBooking } from './category-booking';

export interface CategoryReport {
    category: Category
    spent: number
    bookings: CategoryBooking[]
}
