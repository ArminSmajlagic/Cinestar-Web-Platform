import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  filterForm:FormGroup;

  constructor(private fb:FormBuilder,private router:Router,private activatedRoute:ActivatedRoute) {
    this.filterForm=fb.group({
      time:[],
      city: [],
    });

    this.filterForm.controls['time'].setValue('day', {onlySelf: true});
    this.filterForm.controls['city'].setValue('mostar', {onlySelf: true});

  }
  changeCity(){
    let route = this.filterForm.value.city;
    this.router.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: {
        city: route
      },
      queryParamsHandling: 'merge'
     });
  }
  changeTime(){
    let route = this.filterForm.value.time;
    this.router.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: {
        time: route
      },
      queryParamsHandling: 'merge'
     });  }
  ngOnInit(): void {
  }

}
