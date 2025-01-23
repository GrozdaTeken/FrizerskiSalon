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
import { GalleriaModule } from 'primeng/galleria';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    NavbarBelowComponent,
    AboutusHomeComponent,
    PreviousWorkComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ButtonModule,
    BrowserAnimationsModule,
    GalleriaModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
