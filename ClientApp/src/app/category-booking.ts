import { CategoryMin } from './category-min';

export interface CategoryBooking {
    id: string
    category: CategoryMin
    title:string
    timeStamp:Date
    amount:number
}
