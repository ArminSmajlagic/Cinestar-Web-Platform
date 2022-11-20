import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
// import { OidcSecurityService } from 'angular-auth-oidc-client';
import { catchError, Observable, of } from 'rxjs';
// import { AuthService } from 'src/app/Auth/Services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  userData$?: Observable<any>;
  secretData$?: Observable<any>;
  isAuthenticated$?: Observable<boolean>;

  // constructor(private authService:AuthService,private http:HttpClient) {

  // }

  constructor() {

  }

  ngOnInit() {

  }


  // callApi() {

  //   this.http.get("http://localhost:5002/secret", {
  //     headers: new HttpHeaders({
  //       Authorization: 'Bearer ' + 'token goes here',
  //     }),
  //     responseType: 'text'
  //   })
  //     .subscribe((data: any) => {
  //       console.log("api result:", data);
  //     });
  // }
}
