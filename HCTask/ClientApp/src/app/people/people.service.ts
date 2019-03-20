import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
    this.personRestService = `${baseUrl}api/personRecord`;
    console.log(this.personRestService);
  }

  getPeople(): Observable<PersonRecord[]> {
    return this.http.get<PersonRecord[]>(this.personRestService )
      .pipe(
        tap(data => console.log(JSON.stringify(data)))
      )
  }

  createPerson(person: PersonRecord): Observable<PersonRecord> {
    const headers = new HttpHeaders({ 'Contact-Type' : 'application/json' });
    person.Id = null;
    return this.http.post<PersonRecord>(this.personRestService, person, {headers: headers })
      .pipe(
        tap(data => console.log(`createPerson ${JSON.stringify(data)}`))
      );
  }
}
