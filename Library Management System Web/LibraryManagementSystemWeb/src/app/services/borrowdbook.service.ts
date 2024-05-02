import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BorrowdBookViewModel } from '../models/borrowd-book/borrowdBook-view-model';
import { Observable } from 'rxjs';
import { MemberViewModel } from '../models/member/member-view-model';
import { BorrowdBookCreateModel } from '../models/borrowd-book/borrowdBook-create-model';
import { BorrowdBookEditModel } from '../models/borrowd-book/borrowdBook-edit-model';

@Injectable({
  providedIn: 'root'
})

export class BorrowdbookService {

  private appBaseUrl: string = "https://localhost:7090/";
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<BorrowdBookViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getAllBorrowdBookUrl: string = `${this.appBaseUrl}borrowdBook/getAll`;
    return this.httpClient.get<BorrowdBookViewModel[]>(getAllBorrowdBookUrl, { headers: asseccPermission });
  }

  getById(id: number): Observable<BorrowdBookViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getByIdUrl: string = `${this.appBaseUrl}borrowdBook/getById/${id}`;
    return this.httpClient.get<BorrowdBookViewModel[]>(getByIdUrl, { headers: asseccPermission });
  }

  create(createModel: BorrowdBookCreateModel): Observable<BorrowdBookCreateModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);
    
    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });  

    const createBorrowdBookUrl: string = `${this.appBaseUrl}borrowdBook/create`;
    return this.httpClient.post<BorrowdBookCreateModel>(createBorrowdBookUrl, createModel, { headers: asseccPermission });
  }

  update(id: number, model: BorrowdBookEditModel): Observable<BorrowdBookEditModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });   

    const editBorrowdBookUrl: string = `${this.appBaseUrl}borrowdBook/update/${id}`;
    return this.httpClient.put<BorrowdBookEditModel>(editBorrowdBookUrl, model, { headers: asseccPermission });
  }  

  delete(id: number): Observable<boolean> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const deleteBorrowdBookUrl: string = `${this.appBaseUrl}borrowdBook/delete/${id}`;
    return this.httpClient.delete<boolean>(deleteBorrowdBookUrl, { headers: asseccPermission });
  }
}