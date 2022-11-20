import { isNgTemplate } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { SignalRService } from '../Services/signal-r.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {

  @Input() data:any;
  @Input('dataName') name:any;
  topMovies:boolean=false;
  topTheaters:boolean=false;
  topUsers:boolean=false;
  constructor() {

  }

  ngOnInit(): void {
  }

}
