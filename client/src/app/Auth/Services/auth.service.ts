import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
// import { OidcSecurityService } from 'angular-auth-oidc-client';
// import { User, UserManager, UserManagerSettings } from "oidc-client";

import { BehaviorSubject, map, Observable, of } from 'rxjs';
import { aplication_settings } from 'src/app/aplication_settings';
import { User } from 'src/app/Korisnici/worker-panel/worker/Model/User';
import { Register } from '../Models/Register';
import { Token } from '../Models/Token';

@Injectable({
  providedIn: 'root'
})
export class AuthService  {
  private token?:Token;
  private error?:string;
  private currentUserSubject: BehaviorSubject<Token | null>;
  public currentUser: Observable<Token|null>;
  private loggedIn = new BehaviorSubject<boolean>(false);
  constructor(private http:HttpClient,private router:Router) {
     this.currentUserSubject = new BehaviorSubject<Token| null>({token:localStorage.getItem('token') as string,expiresIn:5000,error:"x",issued:Date.now.toString(),id:localStorage.getItem("id") as unknown as number,scope:"cinestar.web_api"});
     this.currentUser = this.currentUserSubject.asObservable();
  }
  get getToken(){
    return !!this.token?.token;
  }

   get getError(){
    return this.error;
  }
  login(username:string,password:string){
    var authRoute = 'https://localhost:44383/auth/Auth/login';
    var navigateRoute = '/cinehome'
    if(window.location.href.includes("/Management/Login")){
      authRoute= 'https://localhost:44383/auth/Auth/login/management';
      navigateRoute = '/Management/home'
    }
     this.http.post<Token>(authRoute,{username,password})
     .pipe(map(token => {
      // store user details and jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('token', JSON.stringify(token));
      this.currentUserSubject.next(token);
      return token;
  }))
    .subscribe(res=>{
      this.token=res;
      if(this.token.error=='x'){
        localStorage.setItem('token',this.token.token);
        localStorage.setItem('id',this.token.id.toString());
        this.error='';
        this.router.navigate([navigateRoute])
        this.loggedIn.next(true);

      }else{
        this.error=this.token.error;
        console.log(this.error)
        this.loggedIn.next(false);

      }
    })
  }
  logout(){
    this.currentUserSubject.next(null);
    this.loggedIn.next(false);
    localStorage.removeItem('token');
    this.token= undefined;
  }
  register(registerRequest:Register){
    return this.http.post<Token>('https://localhost:44383/auth/Auth/registration',registerRequest)
  }

  confirmUser(userId:number,userCode:string){
    return this.http.post(aplication_settings.damir_local+'auth/Auth/confirmMail',{userId:userId,userCode:userCode})
  }

  public get currentUserValue(): Token | null{
    return this.currentUserSubject.value;
  }

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
}
