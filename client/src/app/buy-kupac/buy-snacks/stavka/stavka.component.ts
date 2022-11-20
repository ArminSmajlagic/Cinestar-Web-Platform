import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import * as _ from 'lodash';
import { BuyService } from '../../Services/buy.service';

@Component({
  selector: 'app-stavka',
  templateUrl: './stavka.component.html',
  styleUrls: ['./stavka.component.scss']
})
export class StavkaComponent implements OnInit {
  @Input()
  snacks:any[]=[];

  @Input()
  stavka:any;

  stavkaForma:FormGroup;

  porcije=[{name:'S',value:3},{name:'M',value:4},{name:'L',value:5},{name:'XL',value:6}]

  constructor(private fb:FormBuilder,private buyService:BuyService) { }


  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.stavkaForma=this.fb.group({
      kolicina:new FormControl(1),
      porcija:new FormControl(this.porcije),
      cijena:new FormControl(this.stavka.cijena.toString()+' KM')
    });
    this.stavkaForma.controls['cijena'].disable();
    this.stavkaForma.controls['porcija'].setValue(3)
  }

  dodajStavkuNaRacun(){
    let cijena = _.replace(this.stavkaForma.controls['cijena'].value,' KM','')
    let porcija='';
    this.porcije.forEach(element => {
      if(element.value==this.stavkaForma.controls.porcija.value)
      porcija=element.name
    });
    let racun = {id: this.snacks.length+1,ponudaId:this.stavka.ponudaId,cijena:Number(cijena),porcija: porcija, kolicina: this.stavkaForma.controls.kolicina.value, naziv: this.stavka.naziv };
    console.log(racun)
    this.dodajSnack(racun);
    this.createForm();
  }

  updateCijena(){
    let orginalnaCijena=this.stavkaForma.controls['porcija'].value;
    console.log(this.stavkaForma.controls['porcija'].value)
    let ukupnaCijena = (this.stavkaForma.controls['kolicina'].value  * orginalnaCijena).toString();
    this.stavkaForma.controls['cijena'].setValue('')
    this.stavkaForma.controls['cijena'].setValue(ukupnaCijena+' KM')
  }

  dodajSnack(racun:any){
    this.snacks.push(racun);
  }


}
