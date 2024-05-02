import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MemberViewModel } from './models/member/member-view-model';
import { Member } from './utility/member.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})

export class AppComponent {

  // Login user type property
  isAdmin: boolean = false;
  isStudent: boolean = false;

  constructor(private tosterService: ToastrService, private router: Router) {
   
  }

  onClickLogout(): void {
    this.tosterService.success("Logout Successfull.", "Successfull.");
    localStorage.removeItem('loginMemberInfo');
    this.router.navigate(['/login']);
  }

  get isMemberLogin(): boolean {
    let memberInfo: MemberViewModel = JSON.parse(localStorage.getItem('loginMemberInfo')!);
    
    if(memberInfo != undefined && memberInfo.memberTypeId == Member.Admin) {
      this.isAdmin = true;
      return true;
    }
    else {
      this.isStudent = true;
      return false;
    }
  }  
}