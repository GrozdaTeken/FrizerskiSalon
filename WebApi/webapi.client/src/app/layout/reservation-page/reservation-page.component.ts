import { Component, HostListener, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Frizer {
  id: string;
  ime: string;
  prezime: string;
}

interface Reservation {
  id: string;
  friId: string;
  termin: string;
  ime: string;
  mail: string;
  telefon: string;
}

@Component({
  selector: 'app-reservation-page',
  templateUrl: './reservation-page.component.html',
  styleUrls: ['./reservation-page.component.css'],
})
export class ReservationPageComponent implements OnInit {

  apiBaseUrl = 'https://localhost:5295/api';

  visible: boolean = false;
  
  events: string[] = ["Datum:", "Izabrani frizer:", "Termin:"];
  chosenDate: Date | undefined;
  minDate: Date = new Date();
  maxDate: Date = new Date(new Date().setFullYear(new Date().getFullYear() + 1));
  
  frizers: Frizer[] = [];
  chosenFrizer: Frizer | undefined;
  activeFrizerId: string | null = null;
  reservations: { time: string; status: string }[] = [];
  
  isLargeScreen: boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

  @HostListener('window:resize', ['$event'])
  updateScreenSize() {
    this.isLargeScreen = window.innerWidth >= 768;
  }

  updateDate() {
    if (this.chosenDate) {
      this.events[0] = `Datum: ${this.chosenDate.toLocaleDateString('sr-RS')}`;
      this.events = [...this.events];
    }
  }
}
