import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input'
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { CategoryReportsComponent } from './category-reports/category-reports.component';
import { CategoryReportDetailComponent } from './category-report-detail/category-report-detail.component';
import { CategoryReportItemComponent } from './category-report-item/category-report-item.component';
import { BookingsComponent } from './bookings/bookings.component';
import { BookingItemComponent } from './booking-item/booking-item.component';
import { registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { HttpClientModule } from '@angular/common/http';
import { CreateCategoryComponent } from './create-category/create-category.component';
import { CreateBookingComponent } from './create-booking/create-booking.component'
import { MatNativeDateModule } from '@angular/material/core';

registerLocaleData(localeDe, 'de-DE');

@NgModule({
  declarations: [
    AppComponent,
    CategoryReportsComponent,
    CategoryReportDetailComponent,
    CategoryReportItemComponent,
    BookingsComponent,
    BookingItemComponent,
    CreateCategoryComponent,
    CreateBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatToolbarModule,
    MatCardModule,
    MatProgressBarModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
  ],
  exports: [
  ],
  providers: [{provide: LOCALE_ID, useValue: 'de-DE'}, MatNativeDateModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
