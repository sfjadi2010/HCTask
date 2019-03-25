import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEventType } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { PersonRecord } from '../models/PersonRecord';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  personRestService: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.personRestService = `${baseUrl}api/personrecord`;
  }

  getPeople(): Observable<PersonRecord[]> {
    return this.http.get<PersonRecord[]>(this.personRestService )
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      )
  }

  getPerson(id: number): Observable<PersonRecord> {
    if (id === 0) {
      return of(this.initializePerson());
    }

    return this.http.get<PersonRecord>(`${this.personRestService}/${id}`)
      .pipe(
        tap(data => console.log('getPerson' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  searchPeople(searchText: string): Observable<PersonRecord[]> {
    return this.http.get<PersonRecord[]>(`${this.personRestService}/search/${searchText}`)
      .pipe(
        tap(data => console.log('searchPeople' + JSON.stringify(data))),
        catchError(this.handleError)
      )
  }

  createPerson(person: PersonRecord): Observable<PersonRecord> {
    const headers = new HttpHeaders({ 'Contact-Type' : 'application/json' });
    person.id = 0;
    return this.http.post<PersonRecord>(this.personRestService, person, { headers: headers })
      .pipe(
        tap(data => console.log("Done!")),
        catchError(this.handleError)
      );
  }

  deletePerson(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete<PersonRecord>(`${this.personRestService}/${id}`, { headers: headers })
      .pipe(
        tap(data => console.log(`deletePerson ${id}`)),
        catchError(this.handleError)
      );
  }

  private handleError(err) {
    let errorMessage: string;

    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurrad: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
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
