import { Injectable } from '@angular/core';
import { MemberViewModel } from '../models/member/member-view-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthorViewModel } from '../models/author/author-view-model';
import { AuthorCreateModel } from '../models/author/author-create-model';
import { AuthorEditModel } from '../models/author/author-edit-model';

@Injectable({
  providedIn: 'root'
})

export class AuthorService {
  private appBaseUrl: string = "https://localhost:7090/api/";
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<AuthorViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getAllAuthorUrl: string = `${this.appBaseUrl}author/getAll`;
    return this.httpClient.get<AuthorViewModel[]>(getAllAuthorUrl, { headers: asseccPermission });
  }

  getById(id: number): Observable<AuthorViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getByIdUrl: string = `${this.appBaseUrl}author/getById/${id}`;
    return this.httpClient.get<AuthorViewModel[]>(getByIdUrl, { headers: asseccPermission });
  }

  create(createModel: AuthorCreateModel): Observable<AuthorCreateModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);
    
    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });  

    const createAuthorUrl: string = `${this.appBaseUrl}author/create`;
    return this.httpClient.post<AuthorCreateModel>(createAuthorUrl, createModel, { headers: asseccPermission });
  }

  update(id: number, model: AuthorEditModel): Observable<AuthorEditModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });   

    const editAuthorUrl: string = `${this.appBaseUrl}author/update/${id}`;
    return this.httpClient.put<AuthorEditModel>(editAuthorUrl, model, { headers: asseccPermission });
  }  

  delete(id: number): Observable<boolean> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const deleteAuthorUrl: string = `${this.appBaseUrl}author/delete/${id}`;
    return this.httpClient.delete<boolean>(deleteAuthorUrl, { headers: asseccPermission });
  }  
}