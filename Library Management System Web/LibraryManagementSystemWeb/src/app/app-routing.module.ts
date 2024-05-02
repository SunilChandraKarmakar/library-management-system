import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorListComponent } from './components/author-list/author-list.component';

const routes: Routes = [
  { path: 'author-list', component: AuthorListComponent, pathMatch: "full" }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }