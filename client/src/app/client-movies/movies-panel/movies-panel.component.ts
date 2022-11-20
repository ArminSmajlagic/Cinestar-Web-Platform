import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {aplication_settings} from "../../aplication_settings";

@Component({
  selector: 'app-movies-panel',
  templateUrl: './movies-panel.component.html',
  styleUrls: ['./movies-panel.component.scss']
})
export class MoviesPanelComponent implements OnInit {

  filmPodaci: any;

  constructor(private httpKlijent: HttpClient,private router: Router) { }


  ngOnInit(): void {
    this.ucitajFilmove();
  }

  ucitajFilmove(): void {
    this.httpKlijent.get(aplication_settings.damir_local + "Film/GetAllFull").subscribe(x => {
      this.filmPodaci = x;
    });
  }

  openDetails(s:any) {
    this.router.navigate(['/movie',s.film.id]);
  }
}
