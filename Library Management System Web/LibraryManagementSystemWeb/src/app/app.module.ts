import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthorListComponent } from './components/author-list/author-list.component';
import { AuthorCreateComponent } from './components/author-create/author-create.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookCreateComponent } from './components/book-create/book-create.component';
import { BookEditComponent } from './components/book-edit/book-edit.component';
import { AuthorEditComponent } from './components/author-edit/author-edit.component';
import { MemberListComponent } from './components/member-list/member-list.component';
import { MemberCreateComponent } from './components/member-create/member-create.component';
import { MemberEditComponent } from './components/member-edit/member-edit.component';
import { BorrowdbookCreateComponent } from './components/borrowdbook-create/borrowdbook-create.component';
import { BorrowdbookEditComponent } from './components/borrowdbook-edit/borrowdbook-edit.component';
import { BorrowdbookListComponent } from './components/borrowdbook-list/borrowdbook-list.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AuthorListComponent,
    AuthorCreateComponent,
    AuthorEditComponent,
    BookListComponent,
    BookCreateComponent,
    BookEditComponent,
    MemberListComponent,
    MemberCreateComponent,
    MemberEditComponent,
    BorrowdbookListComponent,
    BorrowdbookCreateComponent,
    BorrowdbookEditComponent
  ],

  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(), // ToastrModule added
    NgxSpinnerModule   
  ],

  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})

export class AppModule { }