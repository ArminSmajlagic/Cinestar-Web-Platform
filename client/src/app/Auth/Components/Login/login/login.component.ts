import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { OidcSecurityService } from 'angular-auth-oidc-client';
import { AuthService } from 'src/app/Auth/Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  token:any;
  error?:string='';
  passcode:string="password"
  public userAuthenticated = false;

  constructor(public auth: AuthService) {}

  ngOnInit() {

  }

  login(form:NgForm){
    this.auth.login(form.value.username,form.value.password)
    this.error=this.auth.getError;
    if(this.auth.getError){
      form.reset()
    }
  }

  passwordToggle(){
    this.passcode=this.passcode=="password"?'text':'password';

  }

}
