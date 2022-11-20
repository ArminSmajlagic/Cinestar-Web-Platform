import { AfterViewInit, Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { BuyService } from '../Services/buy.service';

@Component({
  selector: 'app-buy-tickets',
  templateUrl: './buy-tickets.component.html',
  styleUrls: ['./buy-tickets.component.scss']
})
export class BuyTicketsComponent implements OnInit,AfterViewInit {

  @ViewChildren('seats')
  _seats:QueryList<ElementRef>;
  alphabet:string[] = [];

  karte:any[] = []
  snacks:any[] = []

  seats:any[]=[];
  rows:any[]=[];

  film:any={};

  racuni:any[]=[];


  constructor(private buyService:BuyService) {
    this.prepareFilm();
    this.pripremiSjedista();
  }

  ngAfterViewInit(): void {
  }

  ngOnInit(): void {
    // this.loadReceipt()
  }

  prepareFilm(){
    this.film.slikaUrl='https://m.media-amazon.com/images/M/MV5BZTJmYTJmYTktMzU1Yy00ZTZlLTgzNjItYmY4ZDFjZGFjYjZhXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_Ratio0.7273_AL_.jpg'
    this.film.cijena = 5;
    this.film.naziv = 'top movie';
  }

  pripremiSjedista(){
    for(let i=0; i < 45;i++){
      this.seats.push(i)
    }

    this.alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

    let alfaLength = this.alphabet.length;

    for (let i = this.alphabet.length; i < this.seats.length; i++) {
      let point = i%this.alphabet.length;
      let point2 = this.alphabet.length-alfaLength;
      this.alphabet.push(this.alphabet[point2]+this.alphabet[point]);
    }

    let size = Math.ceil(this.seats.length/4);

    let row = [];
    for(let i=0;i<this.seats.length;i++){
      row.push(this.seats[i]);
      if(row.length==8){
        this.rows.push(row);
        row=[];
      }
    }
  }


  get GetSnacks(){
    return this.snacks;
  }
  //Upravljanje racunima za snacks

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

  //Upravljanje racunima za karte

  get getKarte(){

    let index=0;
    let sviRacuni:any[]=[];

    for (let i = 0; i < this.karte.length; i++) {
      sviRacuni[index++] = this.karte[i];
    }

    for (let i = 0; i < this.snacks.length; i++) {
      sviRacuni[index++] = this.snacks[i];
    }

    return sviRacuni;
  }


  dodajKarta(racun:any){
    this.karte.push(racun);
  }


  ukloniKarta(racun:any){
    let tempKarte : any[] = [];
    for (let i = 0; i < this.karte.length; i++) {
      if(this.karte[i].id!=racun.id){
        tempKarte.push(this.karte[i]);
      }
    }
    this.karte = []
    this.karte = tempKarte;
  }

  //selekcija i deselkcija sjedišta

  deselectSeat(index:number){
    let seat = document.getElementById(this.alphabet[index]);
    if(seat){
      seat.classList.add('bg-dark');
      seat.classList.remove('bg-secondary');
      return;
    }
  }

  selectSeat(index:number,row:number){

    let seat = document.getElementById(this.alphabet[index]);

    let receat = {id:index, cijena:this.film.cijena, naziv:'obicna karta',red:row+1,kolona:index+1}

     if(seat){
      if(seat.classList.contains('bg-dark')){
        seat.classList.remove('bg-dark');
        this.dodajKarta(receat);
      }
       else{
         seat.classList.add('bg-dark');
         this.ukloniKarta(receat)
       }
    }
  }

  //prikaz modala

  showModal(){
    var modal = document.getElementById("myModal");
    (modal as HTMLElement).style.display = "block";
  }

  //upravljanje svim racunima

  ukloniRacun(racun:any){
    if(racun.stavkaPonudeId)
      this.ukloniSnack(racun) //suvišna logika
    else{
      this.ukloniKarta(racun)
      this.deselectSeat(racun.id)
    }
  }



  //-----
  // loadReceipt(){
  //   this.buyService.getSnacks().forEach(elem=>{
  //     if(!this.racuni.includes(elem))
  //       this.racuni.push(elem);
  //     if(!this.racuni.includes(elem))
  //       this.racuni.push(elem);
  //   })
  // }

}
