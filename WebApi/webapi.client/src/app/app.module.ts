import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { NavbarBelowComponent } from './layout/navbar-below/navbar-below.component';
import { AboutusHomeComponent } from './layout/aboutus-home/aboutus-home.component';
import { PreviousWorkComponent } from './layout/previous-work/previous-work.component';

import { ButtonModule } from 'primeng/button';
import { TimelineModule } from 'primeng/timeline';
import { CardModule } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { ListboxModule } from 'primeng/listbox';
import { GalleriaModule } from 'primeng/galleria';
import { TabViewModule } from 'primeng/tabview';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CommonModule } from '@angular/common';
import { BadgeModule } from 'primeng/badge';
import { AvatarModule } from 'primeng/avatar';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { PricelistComponent } from './layout/pricelist/pricelist.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomePageComponent } from './layout/home-page/home-page.component';
import { AboutUsPageComponent } from './layout/about-us-page/about-us-page.component';
import { GalleriaPageComponent } from './layout/galleria-page/galleria-page.component';
import { ContactPageComponent } from './layout/contact-page/contact-page.component';
import { ReservationPageComponent } from './layout/reservation-page/reservation-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    NavbarBelowComponent,
    AboutusHomeComponent,
    PreviousWorkComponent,
    PricelistComponent,
    FooterComponent,
    HomePageComponent,
    AboutUsPageComponent,
    GalleriaPageComponent,
    ContactPageComponent,
    ReservationPageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ButtonModule,
    BrowserAnimationsModule,
    GalleriaModule,
    TimelineModule,
    CardModule,
    DividerModule,
    ListboxModule,
    AvatarModule,
    BadgeModule,
    TabViewModule,
    CalendarModule,
    FormsModule,
    TableModule,
    TagModule,
    RatingModule,
    CommonModule,
    DialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
