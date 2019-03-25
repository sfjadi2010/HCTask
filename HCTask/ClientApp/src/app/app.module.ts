import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { PersonComponent } from './people/person/person.component';
import { AddPersonComponent } from './people/add-person/add-person.component';
import { PersonDetailComponent } from './people/person-detail/person-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PersonComponent,
    AddPersonComponent,
    PersonDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: PersonComponent, pathMatch: 'full' },
      { path: 'home', component: PersonComponent},
      { path: 'add-person', component: AddPersonComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
