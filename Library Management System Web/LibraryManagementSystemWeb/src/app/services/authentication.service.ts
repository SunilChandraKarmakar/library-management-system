import { Injectable } from '@angular/core';
import { LoginViewModel } from '../models/login/login-view-model';
import { MemberViewModel } from '../models/member/member-view-model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  private appBaseUrl: string = "https://localhost:7090/api/";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient: HttpClient) { }

  login(model: LoginViewModel): Observable<MemberViewModel> {
    const loginMemberUrl: string = `${this.appBaseUrl}authentication/login`;
    return this.httpClient.post<MemberViewModel>(loginMemberUrl, model, this.httpOptions);
  }
}