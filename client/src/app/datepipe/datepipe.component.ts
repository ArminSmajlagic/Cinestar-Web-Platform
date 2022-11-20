import { Component, OnInit } from '@angular/core';
import{DatePipe} from "@angular/common";


@Component({
  selector: 'app-datepipe',
  templateUrl: './datepipe.component.html',
  styleUrls: ['./datepipe.component.scss'],
  providers: [DatePipe]
})
export class DatepipeComponent implements OnInit {

  todayNumber: number = Date.now();
  todayDate : Date = new Date();
  todayString : string = new Date().toDateString();
  todayISOString : string = new Date().toISOString();

  constructor(public date: DatePipe) {

  }

  ngOnInit(): void {
  }

}
