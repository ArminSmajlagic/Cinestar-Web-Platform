import { Component, Input, OnInit } from '@angular/core';
import { Proizvod } from 'src/app/Modeli/SnacksVM';
import { BuyService } from '../Services/buy.service';

@Component({
  selector: 'app-buy-snacks-modal',
  templateUrl: './buy-snacks-modal.component.html',
  styleUrls: ['./buy-snacks-modal.component.scss']
})
export class BuySnacksModalComponent implements OnInit {
  @Input()
  snacks:any[]=[];

  stavke:Proizvod[]=[];

  receats:any=[]

  constructor(private buyService:BuyService) {

  }

  ngOnInit(): void {
    this.loadStavke();
    this.loadTickets();
  }

  hideModal(naredba:string=''){

    if(naredba=='ukloniRacune'){
      this.buyService.snacks=[];
      this.loadTickets();
      this.loadStavke();
    }

    var modal = document.getElementById("myModal");
    (modal as HTMLElement).style.display = "none";
  }

  loadStavke(){
    this.stavke=[];
    this.buyService.getStavke().subscribe(x=>{
      this.stavke=x.proizvodi;
    });
  }

  loadTickets(){
    this.snacks=[];
    this.snacks = this.getSnacks();
  }

  // loadReceipt(){
  //   this.snacks=[]
  //   this.snacks=this.getSnacks();
  // }


    //Upravljanje racunima za snacks

    public getSnacks(){
      return this.snacks;
    }

    dodajSnack(stavka:any){
      console.log(stavka)
      this.snacks.push(stavka);
    }

    ukloniSnack(stavka:any){
      let tempSnacks : any[] = [];
      for (let i = 0; i < this.snacks.length; i++) {
        if(this.snacks[i].id!=stavka.id){
          tempSnacks.push(this.snacks[i])
        }
      }
      this.snacks = []
      this.snacks = tempSnacks;
    }



}
