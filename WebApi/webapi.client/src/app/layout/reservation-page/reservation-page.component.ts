import { Component } from '@angular/core';

@Component({
  selector: 'app-reservation-page',
  templateUrl: './reservation-page.component.html',
  styleUrls: ['./reservation-page.component.css'],
})
export class ReservationPageComponent {
  events: string[] = ["Datum:", "Izabrani frizer:", "Termin:"];
  date2: Date | undefined;
  minDate: Date = new Date(); // Example: Set today as the minimum date
  maxDate: Date = new Date(new Date().setFullYear(new Date().getFullYear() + 1)); // Max date one year from now
  tabs = [
    { title: 'Frizer 1', content: 'Tab 1 Content', value: '5' },
    { title: 'Frizer 2', content: 'Tab 2 Content', value: '0' },
    { title: 'Frizer 3', content: 'Tab 3 Content', value: '2' },
  ];
  activeTab: string = this.tabs[0].title;

  constructor() {}

  ngOnInit() {
    this.updateActiveTab(0); // Initialize with the first tab
  }

  updateActiveTab(index: number) {
    this.activeTab = this.tabs[index].title;
    this.events[1] = `Izabrani frizer: ${this.activeTab}`;
    this.events = [...this.events]; // Reassign to trigger change detection
  }

  updateDate() {
    if (this.date2) {
      this.events[0] = `Datum: ${this.date2.toLocaleDateString('sr-RS')}`;
      this.events = [...this.events]; // Reassign to trigger change detection
    }
  }
}
