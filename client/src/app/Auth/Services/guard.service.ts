import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService implements CanActivate {

  constructor(private auth:AuthService,private router:Router) { }
  canActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    var loginRoute =window.location.href.includes("Management") ? "/Management/Login" : "/Login";
    if (!this.auth.getToken) {
      this.router.navigateByUrl(loginRoute);
    }

    return this.auth.getToken;
  }
}
