import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { LoginViewModel } from 'src/app/models/login/login-view-model';
import { MemberViewModel } from 'src/app/models/member/member-view-model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Member } from 'src/app/utility/member.enum';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})

export class LoginComponent implements OnInit {

  // Login model
  loginModel: LoginViewModel = new LoginViewModel();

  constructor(private authenticationService: AuthenticationService, private router: Router, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService, private cdref: ChangeDetectorRef) { }

  ngOnInit() {

  }

  onClickLogin(): void {
    let isFormValidationSuccess: boolean = this.checkFormValidation();

    if(isFormValidationSuccess) {
      this.spinnerService.show();
      this.authenticationService.login(this.loginModel).subscribe((result: MemberViewModel) => {
        localStorage.setItem("loginMemberInfo", JSON.stringify(result));
        this.spinnerService.hide();
        this.toastrService.success("Login Successfull", "Successfull");
        this.cdref.detectChanges();
        
        if(result.memberTypeId == Member.Admin) {
          return this.router.navigate(["/author-list"]);
        } else {
          return this.router.navigate(["/upcomming_patient_list"]);
        }
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Email or password cannot match! Try again.", "Error");
      })
    }
  }

  private checkFormValidation(): boolean {
    if(this.loginModel.email == undefined || this.loginModel.email == null || this.loginModel.email == "") {
      this.toastrService.warning("Please, provied valid email address.", "Warning");
      return false;
    }

    if(this.loginModel.password == undefined || this.loginModel.password == null || this.loginModel.password == "") {
      this.toastrService.warning("Please, provied password.", "Warning");
      return false;
    }

    return true;
  }
}