import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { aplication_settings } from 'src/app/aplication_settings';
import { ClientHomeVM, Film } from 'src/app/Modeli/ClientHomeVM';

@Component({
  selector: 'app-client-home',
  templateUrl: './client-home.component.html',
  styleUrls: ['./client-home.component.scss']
})
export class ClientHomeComponent implements OnInit {
  filmovi:Film[];
  bannerText:any;
  baneri: string[]=[];
  banerTextovi: string[]=[];
  currentBanner:any;
  bannerIndex:number=0;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.http.get<ClientHomeVM>(aplication_settings.damir_local + "ClientHomeVM").subscribe(x => {
      this.filmovi = x.filmovi;
    });
    this.baneri.push(
      "https://image.tmdb.org/t/p/original/oSNqhngemquRBzxKSC3ysAmnC5e.jpg",
      "https://image.tmdb.org/t/p/original/hv7o3VgfsairBoQFAawgaQ4cR1m.jpg",
      "https://image.tmdb.org/t/p/original/ng6SSB3JhbcpKTwbPDsRwUYK8Cq.jpg"
    )
    this.banerTextovi.push("355","Matrix Rusurekcija","Spider Man: Put Bez Povratka");
    this.currentBanner=this.baneri[this.bannerIndex];
    this.bannerText=this.banerTextovi[this.bannerIndex];
    setInterval(()=>{
        this.currentBanner=this.baneri[(this.bannerIndex)%this.baneri.length]
        this.bannerText=this.banerTextovi[(this.bannerIndex++)%this.baneri.length]
    },4000)
  }

  Next(){
    this.bannerIndex=this.bannerIndex==this.baneri.length-1?0:this.bannerIndex+1;
    this.currentBanner=this.baneri[this.bannerIndex];
    this.bannerText=this.banerTextovi[this.bannerIndex]

  }
  previous(){
    this.bannerIndex=this.bannerIndex==0?this.baneri.length-1:this.bannerIndex-1;
    this.currentBanner=this.baneri[this.bannerIndex];
    this.bannerText=this.banerTextovi[this.bannerIndex]

  }

}
