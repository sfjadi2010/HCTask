import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { PersonRecord } from "../../models/PersonRecord";

import { PeopleService } from '../people.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {


  filteredPeople: PersonRecord[] = [];
  people: PersonRecord[] = [];

  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;

    if (this.listFilter.length >= 3) {
      this.performFilter(this.listFilter);
    } else {
      this.getPeople();
    }
  }
  constructor(private peopleService: PeopleService) {
    
  }

  ngOnInit() {
    this.getPeople();
  }

  private getPeople() {
    this.peopleService.getPeople().subscribe(
      people => {
        this.people = people;
        this.filteredPeople = this.people;
      },
      error => console.log(<any>error)
    );
  }

  private performFilter(filterBy: string): void {
    this.peopleService.searchPeople(filterBy).subscribe(
      people => {
        this.people = people;
        this.filteredPeople = this.people;
      },
      error => console.log(<any>error)
    );
  }
}
