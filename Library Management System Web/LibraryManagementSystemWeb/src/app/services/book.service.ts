import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookViewModel } from '../models/book/book-view-model';
import { MemberViewModel } from '../models/member/member-view-model';
import { BookCreateModel } from '../models/book/book-create-model';
import { BookEditModel } from '../models/book/book-edit-model';

@Injectable({
  providedIn: 'root'
})

export class BookService {

  private appBaseUrl: string = "https://localhost:7090/";
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<BookViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getAllBookUrl: string = `${this.appBaseUrl}book/getAll`;
    return this.httpClient.get<BookViewModel[]>(getAllBookUrl, { headers: asseccPermission });
  }

  getById(id: number): Observable<BookViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getByIdUrl: string = `${this.appBaseUrl}book/getById/${id}`;
    return this.httpClient.get<BookViewModel[]>(getByIdUrl, { headers: asseccPermission });
  }

  create(createModel: BookCreateModel): Observable<BookCreateModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);
    
    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });  

    const createBookUrl: string = `${this.appBaseUrl}book/create`;
    return this.httpClient.post<BookCreateModel>(createBookUrl, createModel, { headers: asseccPermission });
  }

  update(id: number, model: BookEditModel): Observable<BookEditModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });   

    const editBookUrl: string = `${this.appBaseUrl}book/update/${id}`;
    return this.httpClient.put<BookEditModel>(editBookUrl, model, { headers: asseccPermission });
  }  

  delete(id: number): Observable<boolean> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const deleteBookUrl: string = `${this.appBaseUrl}book/delete/${id}`;
    return this.httpClient.delete<boolean>(deleteBookUrl, { headers: asseccPermission });
  } 
}