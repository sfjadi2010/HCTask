import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
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
  pictureToUpload: File = null;

  person: PersonRecord;
  
  constructor(private fb: FormBuilder, private peopleService: PeopleService, private router: Router, private cd: ChangeDetectorRef) { }

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
      pictureName: [''],
      fileAsBase64: ['']
    });
  }

  onFileChagne(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.personForm.patchValue({
          fileAsBase64: reader.result
        });

        this.cd.markForCheck();
      }
    }
  }

  savePerson() : void {
    if (this.personForm.valid && this.personForm.dirty) {
      const pRecord = { ...this.person, ...this.personForm.value };

      if (pRecord) {
        this.peopleService.createPerson(pRecord)
          .subscribe(
            () => this.onSaveCompleteCancel(),
            (error: any) => this.errorMessage = <any>error
          );
      } else {

      }
    }
  }

  onSaveCompleteCancel(): void {
    this.personForm.reset();
    this.router.navigate(['/'])
  }

}
