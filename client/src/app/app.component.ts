import {Component, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { aplication_settings } from './aplication_settings';
import {NotificationMiddlewareService} from "./core/notification-middleware.service";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  //LINIJA ISPOD DAMIR ZA JS NOTIFIKACIJE
  title = 'app';
  management=false;
  client=false;
  auth=false;
  constructor(private router: Router,private notificationMiddleware: NotificationMiddlewareService) {
    router.events.subscribe((val) => {
        let routeHit = false;
        let route=val as NavigationEnd;
        let path = route?.url as string
        if(path){
          if(path=="/"+aplication_settings.routesAuth[0] || path=="/"+aplication_settings.routesAuth[1]|| path.includes("/"+aplication_settings.routesAuth[2]+"/")){
            this.auth=true;
            routeHit=true;
          }
          if(!routeHit)
          {
            this.auth=false;
          }
        }

      aplication_settings.routesKlijent.forEach(x=>{

        let route=val as NavigationEnd;
        let path = route.url as string
        if(path?.includes("/"+x)){
          this.client=true;
        }
      })
      if(this.client){
        this.management=false;
      }
      else{
        this.management=true;
      }
    });
  }

  //-------------------------------DAMIR ZA JS NOTIFIKACIJE START-------------------------------
  ngOnInit(){
    this.notificationMiddleware.init();
  }
//-------------------------------DAMIR ZA JS NOTIFIKACIJE END-------------------------------
}

