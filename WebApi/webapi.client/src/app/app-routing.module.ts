import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './layout/home-page/home-page.component';
import { AboutUsPageComponent } from './layout/about-us-page/about-us-page.component';
import { GalleriaPageComponent } from './layout/galleria-page/galleria-page.component';
import { ContactPageComponent } from './layout/contact-page/contact-page.component';
import { ReservationPageComponent } from './layout/reservation-page/reservation-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'aboutUs', component: AboutUsPageComponent },
  { path: 'galleria', component: GalleriaPageComponent },
  { path: 'contact', component: ContactPageComponent },
  { path: 'reservation', component: ReservationPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
