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
  apiBaseUrl = 'http://localhost:5295/api';
  
  events: string[] = ["Datum:", "Izabrani frizer:", "Termin:"];
  date2: Date | undefined;
  minDate: Date = new Date();
  maxDate: Date = new Date(new Date().setFullYear(new Date().getFullYear() + 1));
  
  frizers: Frizer[] = [];
  activeFrizerId: string | null = null;
  reservations: { time: string; status: string }[] = [];
  
  isLargeScreen: boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getFrizers();
    this.updateScreenSize();
  }

  getFrizers() {
    this.http.get<Frizer[]>(`${this.apiBaseUrl}/Frizer/AllFrizers`).subscribe((data) => {
      this.frizers = data;
      if (this.frizers.length > 0) {
        this.selectFrizer(this.frizers[0].id); // Select first frizer by default
      }
    });
  }

  selectFrizer(friId: string) {
    this.activeFrizerId = friId;
    const selectedFrizer = this.frizers.find(frizer => frizer.id === friId);
    this.events[1] = `Izabrani frizer: ${selectedFrizer?.ime} ${selectedFrizer?.prezime}`;
    this.events = [...this.events];

    this.getReservationsForFrizer(friId);
  }

  getReservationsForFrizer(friId: string) {
    this.http.get<Reservation[]>(`${this.apiBaseUrl}/Rezervacija/RezervacijeZaFrizera/${friId}`)
      .subscribe((data) => {
        this.reservations = data.map(res => ({
          time: new Date(res.termin).toLocaleTimeString('sr-RS', { hour: '2-digit', minute: '2-digit' }),
          status: res.mail || res.telefon ? "Zauzeto" : "Slobodno",
        }));
      });
  }

  @HostListener('window:resize', ['$event'])
  updateScreenSize() {
    this.isLargeScreen = window.innerWidth >= 768;
  }

  updateDate() {
    if (this.date2) {
      this.events[0] = `Datum: ${this.date2.toLocaleDateString('sr-RS')}`;
      this.events = [...this.events];
    }
  }

  getSeverity(status: string) {
    return status === "Slobodno" ? "success" : "contrast";
  }

  getButtonSeverity(status: string) {
    return status === "Slobodno" ? "success" : "danger";
  }

  getIcon(status: string) {
    return status === "Slobodno" ? "pi pi-check" : "pi pi-times";
  }
}
