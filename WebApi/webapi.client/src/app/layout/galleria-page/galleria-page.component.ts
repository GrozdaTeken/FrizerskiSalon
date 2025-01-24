import { Component } from '@angular/core';

@Component({
  selector: 'app-galleria-page',
  templateUrl: './galleria-page.component.html',
  styleUrl: './galleria-page.component.css'
})
export class GalleriaPageComponent {
  images: Image[] = [
    {
      itemImageSrc: '/assets/pics/hairstyle1.png',
      thumbnailImageSrc: '/assets/pics/hairstyle1.png',
      title: 'Primer slike broj I',
      alt: 'Opis prve slike'
    },
    {
      itemImageSrc: '/assets/pics/hairstyle2.png',
      thumbnailImageSrc: '/assets/pics/hairstyle2.png',
      title: 'Primer  slike broj II',
      alt: 'Opis druge slike'
    },
    {
      itemImageSrc: '/assets/pics/hairstyle3.png',
      thumbnailImageSrc: '/assets/pics/hairstyle3.png',
      title: 'Primer slike broj III',
      alt: 'Opis treće slike'
    },
    // Add more images here
  ];
  activeIndex = 0;
  showThumbnails = true;
  fullscreen = false;

  ngOnInit() {
    // Optional: Start autoplay immediately
    // setTimeout(() => {
    //   this.showThumbnails = false;
    // }, 3000); // Hide thumbnails after 3 seconds
  }

  galleriaClass(): string {
    return this.fullscreen ? 'fullscreen-galleria' : '';
  }

  fullScreenIcon(): string {
    return this.fullscreen ? 'pi pi-compress' : 'pi pi-expand';
  }

  onThumbnailButtonClick() {
    this.showThumbnails = !this.showThumbnails;
  }

  toggleFullScreen() {
    this.fullscreen = !this.fullscreen;
  }

}
class Image {
  itemImageSrc: string;
  title: string;
  thumbnailImageSrc: string;
  alt:string;

  constructor(itemImageSrc: string, title: string,thumbnailImageSrc:string,alt:string) {
    this.itemImageSrc = itemImageSrc;
    this.title = title;
    this.thumbnailImageSrc = thumbnailImageSrc;
    this.alt = alt;
  }

}
