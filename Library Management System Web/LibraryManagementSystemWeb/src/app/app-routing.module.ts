import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorListComponent } from './components/author-list/author-list.component';
import { AuthorCreateComponent } from './components/author-create/author-create.component';
import { LoginComponent } from './components/login/login.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookCreateComponent } from './components/book-create/book-create.component';
import { BookEditComponent } from './components/book-edit/book-edit.component';
import { MemberListComponent } from './components/member-list/member-list.component';
import { MemberCreateComponent } from './components/member-create/member-create.component';
import { MemberEditComponent } from './components/member-edit/member-edit.component';
import { BorrowdbookListComponent } from './components/borrowdbook-list/borrowdbook-list.component';
import { BorrowdBookCreateModel } from './models/borrowd-book/borrowdBook-create-model';
import { BorrowdbookEditComponent } from './components/borrowdbook-edit/borrowdbook-edit.component';

const routes: Routes = [
  { path: "*", component: LoginComponent, pathMatch: "full" }, 
  { path: "", component: LoginComponent, pathMatch: "full" },
  { path: "login", component: LoginComponent, pathMatch: "full" },

  { path: "author-list", component: AuthorListComponent, pathMatch: "full" }, 
  { path: "author-create", component: AuthorCreateComponent, pathMatch: "full" },
  { path: "author-edit/:recordId", component: AuthorCreateComponent, pathMatch: "full" }, 

  { path: "book-list", component: BookListComponent, pathMatch: "full" }, 
  { path: "book-create", component: BookCreateComponent, pathMatch: "full" },
  { path: "book-edit/:recordId", component: BookEditComponent, pathMatch: "full" }, 

  { path: "member-list", component: MemberListComponent, pathMatch: "full" }, 
  { path: "member-create", component: MemberCreateComponent, pathMatch: "full" },
  { path: "member-edit/:recordId", component: MemberEditComponent, pathMatch: "full" }, 

  { path: "borroedbook-list", component: BorrowdbookListComponent, pathMatch: "full" }, 
  { path: "borroedbook-create", component: BorrowdBookCreateModel, pathMatch: "full" },
  { path: "borroedbook-edit/:recordId", component: BorrowdbookEditComponent, pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }