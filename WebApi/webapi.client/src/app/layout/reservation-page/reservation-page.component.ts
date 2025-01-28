import { Component, HostListener } from '@angular/core';

interface Column {
  field: string;
  header: string;
}

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

  reservations = [
    { time: "10.00h", status: "Zauzeto", action: "Otkazi" },
    { time: "10.15h", status: "Slobodno", action: "Zakazi" },
    { time: "10.30h", status: "Zauzeto", action: "Otkazi" },
    { time: "10.45h", status: "Zauzeto", action: "Otkazi" },
    { time: "11.00h", status: "Slobodno", action: "Zakazi" },
    { time: "11.15h", status: "Zauzeto", action: "Otkazi" },
    { time: "11.30h", status: "Zauzeto", action: "Otkazi" },
    { time: "11.45h", status: "Slobodno", action: "Zakazi" },
    { time: "12.00h", status: "Zauzeto", action: "Otkazi" },
    { time: "12.15h", status: "Zauzeto", action: "Otkazi" },
    { time: "12.30h", status: "Slobodno", action: "Zakazi" },
    { time: "12.45h", status: "Zauzeto", action: "Otkazi" },
    { time: "13.00h", status: "Zauzeto", action: "Otkazi" },
    { time: "13.15h", status: "Zauzeto", action: "Otkazi" },
    { time: "13.30h", status: "Slobodno", action: "Zakazi" },
    { time: "13.45h", status: "Zauzeto", action: "Otkazi" },
    { time: "14.00h", status: "Zauzeto", action: "Otkazi" },
    { time: "14.15h", status: "Zauzeto", action: "Otkazi" },
    { time: "14.30h", status: "Slobodno", action: "Zakazi" },
    { time: "14.45h", status: "Zauzeto", action: "Otkazi" },
    { time: "15.00h", status: "Zauzeto", action: "Otkazi" },
  ];

  cols!: Column[];

  isLargeScreen: boolean = true;

  constructor() { }

  ngOnInit() {
    this.updateActiveTab(0); // Initialize with the first tab
    // this.productService.getProductsMini().then((data) => {// OVO CE TREBATI KAD SE BUDE UBACIVALO IZ BAZE, ZA SAD SU SAMO DUMMY PRIMERI PRIKAZA
    //   this.products = data;
    // });

    // this.cols = [
    //   { field: 'code', header: 'Code' },
    //   { field: 'name', header: 'Name' },
    //   { field: 'category', header: 'Category' },
    //   { field: 'quantity', header: 'Quantity' },
    //   { field: 'inventoryStatus', header: 'Status' },
    //   { field: 'rating', header: 'Rating' }
    // ];
  }

  @HostListener('window:resize', ['$event'])
  updateScreenSize() {
    this.isLargeScreen = window.innerWidth >= 768; // Example: Large screens are 768px or more
  }

  getSeverity(status: string) {
    switch (status) {
      case 'Slobodno':
        return 'success';
      case 'Zauzeto':
        return 'contrast';
      default:
        return 'warning';
    }
  }

  getButtonSeverity(status: string) {
    switch (status) {
      case 'Slobodno':
        return 'success';
      case 'Zauzeto':
        return 'danger';
      default:
        return 'info';
    }
  }
  getIcon(status: string) {
    switch (status) {
      case 'Slobodno':
        return 'pi pi-check';
      case 'Zauzeto':
        return 'pi pi-times';
      default:
        return 'ERROR';
    }
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
