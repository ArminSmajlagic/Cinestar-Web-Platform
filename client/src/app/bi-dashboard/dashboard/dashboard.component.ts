import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { aplication_settings } from 'src/app/aplication_settings';
import { SignalRService } from '../Services/signal-r.service';
import { Observable } from 'rxjs';
import { WorkerService } from 'src/app/Korisnici/worker-panel/worker/Service/worker.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit,OnDestroy {
  topUsers:number[]=[];
  topCinema:string[]=[];
  topMovies:number[]=[];

  chart1:any;
  chart2:any;
  chart3:any;

  data:any;
  constructor(
    private signalrService:SignalRService,
    private http:HttpClient,
    workerService:WorkerService) {
      this.http.get(aplication_settings.cinestar__plesk__server_standard_endpoints + "Film/GetAll").subscribe(x => {
        this.topMovies = (x as any);
      });
      workerService.getAll().subscribe(x=>{
        this.topUsers=(x as any);
      });
  }

  ngOnDestroy(): void {
    this.signalrService.connection.off('askServerResponse');
  }


  ngOnInit(): void {
    this.signalrService.startConnection();
    this.signalrService.addServerListener();
    this.startHttpRequest();
    this.dataUpdate();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:44383/api/Dashboard')
    .subscribe(res => {
    })
  }

  dataUpdate(){
    setInterval(()=>{
      //  this.signalrService.askServerListener();
      //  this.signalrService.askServer()
      const resp = this.signalrService.data;
      this.topUsers=resp.topUsers;
      this.topMovies=resp.topMovies;
      this.topCinema=resp.topTheaters;

      this.chart1=resp.chart1;
      this.chart2=resp.chart2;
      this.chart3=resp.chart3;

      this.data = {chart1:this.chart1,chart2:this.chart2,chart3:this.chart3};
      },2000)
  }


}
