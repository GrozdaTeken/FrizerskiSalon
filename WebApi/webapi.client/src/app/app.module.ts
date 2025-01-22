import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { NavbarBelowComponent } from './layout/navbar-below/navbar-below.component';
import { AboutusHomeComponent } from './layout/aboutus-home/aboutus-home.component';
import { PreviousWorkComponent } from './layout/previous-work/previous-work.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    NavbarBelowComponent,
    AboutusHomeComponent,
    PreviousWorkComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
