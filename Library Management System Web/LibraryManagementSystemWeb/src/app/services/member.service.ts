import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberViewModel } from '../models/member/member-view-model';
import { MemberCreateModel } from '../models/member/member-create-model';
import { MemberEditModel } from '../models/member/member-edit-model';

@Injectable({
  providedIn: 'root'
})

export class MemberService {

  private appBaseUrl: string = "https://localhost:7090/";
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<MemberViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getAllMemberUrl: string = `${this.appBaseUrl}member/getAll`;
    return this.httpClient.get<MemberViewModel[]>(getAllMemberUrl, { headers: asseccPermission });
  }

  getById(id: number): Observable<MemberViewModel[]> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const getByIdUrl: string = `${this.appBaseUrl}member/getById/${id}`;
    return this.httpClient.get<MemberViewModel[]>(getByIdUrl, { headers: asseccPermission });
  }

  create(createModel: MemberCreateModel): Observable<MemberCreateModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);
    
    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });  

    const createMemberUrl: string = `${this.appBaseUrl}member/create`;
    return this.httpClient.post<MemberCreateModel>(createMemberUrl, createModel, { headers: asseccPermission });
  }

  update(id: number, model: MemberEditModel): Observable<MemberEditModel> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });   

    const editMemberUrl: string = `${this.appBaseUrl}member/update/${id}`;
    return this.httpClient.put<MemberEditModel>(editMemberUrl, model, { headers: asseccPermission });
  }  

  delete(id: number): Observable<boolean> {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem("loginMemberInfo")!);

    const asseccPermission = new HttpHeaders ({
      'Content-Type': 'application/json',
      'Authorization' : `Bearer ${memberInfo.token}`
    });    

    const deleteMemberUrl: string = `${this.appBaseUrl}member/delete/${id}`;
    return this.httpClient.delete<boolean>(deleteMemberUrl, { headers: asseccPermission });
  } 
}