import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEventType } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { PersonRecord } from '../Models/PersonRecord';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  personRestService: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    console.log(baseUrl);
    this.personRestService = `${baseUrl}api/personrecord`;
    console.log(this.personRestService);
  }

  getPeople(): Observable<PersonRecord[]> {
    return this.http.get<PersonRecord[]>(this.personRestService )
      .pipe(
        tap(data => console.log(JSON.stringify(data)))
      )
  }

  getPerson(id: number): Observable<PersonRecord> {
    if (id === 0) {
      return of(this.initializePerson());
    }

    return this.http.get<PersonRecord>(`${this.personRestService}/${id}`)
      .pipe(
        tap(data => console.log('getPerson' + JSON.stringify(data)))
      );
  }

  createPerson(person: PersonRecord): Observable<PersonRecord> {
    const headers = new HttpHeaders({ 'Contact-Type' : 'application/json' });
    person.id = 0;
    return this.http.post<PersonRecord>(this.personRestService, person, { headers: headers })
      .pipe(
        tap(data => console.log("Done!"))
      );
  }

  private initializePerson(): PersonRecord {
    return {
      id: 0,
      firstName: null,
      lastName: null,
      email: null,
      phone: null,
      dateOfBirth: null,
      interests: null,
      street: null,
      city: null,
      state: null,
      postalCode: null,
      pictureName: null,
      fileAsBase64: null
    }
  }
}
