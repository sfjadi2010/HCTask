import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

import { PersonRecord } from "../../Models/PersonRecord";
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {
  pageTitle = "Add Person";
  errorMessage: string;
  personForm: FormGroup;

  person: PersonRecord;
  
  constructor(private fb: FormBuilder, private peopleService: PeopleService) { }

  ngOnInit() {
    this.personForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required]
      
    });
  }

}
