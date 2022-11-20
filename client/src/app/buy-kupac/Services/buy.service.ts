import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { aplication_settings } from 'src/app/aplication_settings';
import { SnacksVM } from 'src/app/Modeli/SnacksVM';

@Injectable({
  providedIn: 'root'
})
export class BuyService {

  // racuniGeneral:any[]=[];

  // racuniSnacks:any[]=[];
  // racuniMovie:any[]=[];
  // recenetRacuniMovie:any[]=[];

  stavke:any[]=[];
  // film:any;
  // sjedista:any[]=[];

  snacks:any[]=[];
  karte:any[]=[];


  constructor(private httpClient:HttpClient) { }

  //Funkcije za hranu i pice

  public getSnacks(){
    return this.snacks;
  }

  dodajSnack(racun:any){
    this.snacks.push(racun);
  }

  ukloniSnack(racun:any){
    let tempSnacks : any[] = [];
    for (let i = 0; i < this.snacks.length; i++) {
      if(this.snacks[i].id!=racun.id){
        tempSnacks.push(this.snacks[i])
      }
    }
    this.snacks = []
    this.snacks = tempSnacks;
  }



  //Get all racuni

  // public get getAllRacuni(){
  //   return this.racuni;
  // }

  getMovieRacun(index:number=0,racun:any=null){
    if(racun){
      let i = this.karte.indexOf(racun);
      return this.karte[i];
    }else{
      this.karte.forEach(element => {
        if(element.id==index)
          return element;
      });
    }
    return null;
  }


  getStavke(){
    return this.httpClient.get<SnacksVM>(aplication_settings.damir_local+'SnacksVM');
  }

  getSjedista(){

  }

  ukloniRecentRacun(){

  }



}
