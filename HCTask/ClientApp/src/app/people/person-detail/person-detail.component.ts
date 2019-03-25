import { Component, OnInit, Input, Injectable, Inject } from '@angular/core';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  @Input() firstName;
  @Input() lastName;
  @Input() email;
  @Input() phone;
  @Input() dob;
  @Input() street;
  @Input() city;
  @Input() state;
  @Input() postalCode;
  @Input() interests;
  @Input() pictureName;
  imageUrl: string;
  imageWidth = 150;
  imageMargin = 5;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.imageUrl = `${baseUrl}/resources/images/`;
  }

  ngOnInit() {
  }

  getAge(dob): number {
    const age = (new Date()).getFullYear() - (new Date(dob)).getFullYear();
    return age - 1;  
  }

  getImageUrl(pictureName): string {
    return this.imageUrl + pictureName;
  }
}
