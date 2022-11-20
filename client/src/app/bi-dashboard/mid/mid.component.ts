import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import { Chart, registerables } from 'chart.js';
import { UIChart } from 'primeng/chart/chart';
import { SignalRService } from '../Services/signal-r.service';
@Component({
  selector: 'app-mid',
  templateUrl: './mid.component.html',
  styleUrls: ['./mid.component.scss']
})
export class MidComponent implements OnInit {

  chart1: any;
  chart2: any;
  chart3: any;
  data:any;

  timeFilter:any;
  dayLabels:string[]=['MON','TUE','WED','THU','FRI','SAT','SUN'];
  weekLabels:string[]=['1. Week','2. Week','3. Week','4. Week'];
  monthLabels:string[]=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July'];
  yearLabels:string[]=[];
  activeLabels:string[]=[];

  constructor(private activatedRoute:ActivatedRoute,private rService:SignalRService){
    this.activatedRoute.queryParams.subscribe(params => {
      this.timeFilter = params['time'];
    });

    Chart.register(...registerables);
    Chart.defaults.color="white"
  }

	ngOnInit() {
    this.addServerListener()
  }


  addServerListener(){
    this.rService.connection.on("transferchartdata", (data) => {
      this.data=data;
      this.updateCharts();
    });
  }

  updateCharts(){
    if(this.data){
      this.reloadChart()
      this.createCharts()
    }
  }

  reloadChart(){
    if(this.chart1){
      document.getElementById("canvas1")?.remove();
      var canvas1=document.getElementById("chart1_parent")
      if(canvas1)
        canvas1.innerHTML='<canvas id="canvas1">{{chart1}}</canvas>';
    }
    if(this.chart2){
      document.getElementById("canvas2")?.remove();
      var canvas2=document.getElementById("chart2_parent")
      if(canvas2)
        canvas2.innerHTML='<canvas id="canvas2">{{chart2}}</canvas>';
    }
    if(this.chart3){
      document.getElementById("canvas3")?.remove();
      var canvas3=document.getElementById("chart3_parent")
      if(canvas3)
        canvas3.innerHTML='<canvas id="canvas3">{{chart3}}</canvas>';
    }
  }

  createCharts(){
    this.chart1 = new Chart('canvas1', {
      type: 'bar',
      data: {
        labels: this.monthLabels,
        datasets: [
          {
            data:this.data.chart1,
            borderColor: '#FFFFFF',
            label: 'Frekventnost novih korisnika',
            backgroundColor: '#FFC107',
            borderWidth: 3,
              },
            ],
          },
        }
    );

    this.chart2 = new Chart('canvas2', {
      type: 'line',
      data: {
        labels: this.monthLabels,
        datasets: [
          {
            data:this.data.chart2,
            borderColor: '#FFFFFF',
            fill: false,
            label: 'Zarada kina on site',
            backgroundColor: '#FFC107',
            borderWidth: 3,
          },
        ],
      },

    });

    this.chart3 = new Chart('canvas3', {
      type: 'line',
      data: {
        labels: this.monthLabels,
        datasets: [
          {
            data:this.data.chart3,
            borderColor: '#FFFFFF',
            fill: false,
            label: 'Zarada kina online',
            backgroundColor: '#FFC107',
            borderWidth: 3,
          },
        ],
      },
    });
  }
}
