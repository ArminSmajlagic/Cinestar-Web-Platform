import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/Auth/Services/auth.service';

@Component({
  selector: 'app-management-navigation',
  templateUrl: './management-navigation.component.html',
  styleUrls: ['./management-navigation.component.scss']
})
export class ManagementNavigationComponent implements OnInit {
  isLoggedIn$: Observable<boolean> | undefined;
  logedIn:boolean=false;
  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
    this.isLoggedIn$=this.authService.isLoggedIn;
    this.logedIn=this.authService.currentUserValue?.token?true:false;
  }
  logout(){
    this.authService.logout();
    this.router.navigate(['/Management/Login']);
  }

  goToClient(){
    this.logout();
    this.router.navigate(['/cinehome']);
  }
}
