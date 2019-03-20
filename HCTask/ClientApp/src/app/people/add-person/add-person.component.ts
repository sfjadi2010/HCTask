import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

import { PersonRecord } from "../../Models/PersonRecord";
import { PeopleService } from '../people.service';
import { Router } from '@angular/router';

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
  
  constructor(private fb: FormBuilder, private peopleService: PeopleService, private router: Router) { }

  ngOnInit() {
    this.personForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      email: [''],
      phone: [''],
      interests: [''],
      street: ['', Validators.required],
      city: ['', Validators.required],
      postalCode: ['', Validators.required],
      state: [''],
      pictureName: ['']
    });
  }

  savePerson() : void {
    if (this.personForm.valid && this.personForm.dirty) {
      const p = { ...this.person, ...this.personForm.value };

      if (p.id === 0) {
        this.peopleService.createPerson(p)
          .subscribe(
            () => this.onSaveComplete(),
            (error: any) => this.errorMessage = <any>error
          );
      } else {

      }
    }
  }

  onSaveComplete(): void {
    this.personForm.reset();
    this.router.navigate(['/'])
  }

}
