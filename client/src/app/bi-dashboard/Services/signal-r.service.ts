import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { aplication_settings } from 'src/app/aplication_settings';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public data:any;

  public connection:signalR.HubConnection;

  constructor(private http:HttpClient) {

  }

  public startConnection = () => {

    this.connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44383/dashboard',{skipNegotiation:true,transport:signalR.HttpTransportType.WebSockets})
    .build();

    this.connection
    .start()
    .then(() => console.log('SignalR Connected!'))
    .catch(err => console.error("error while starting conecction :",err.toString()) );

  }


  addServerListener(){
    this.connection.on("transferchartdata", (data) => {
      this.data=data;
    });
  }




}
