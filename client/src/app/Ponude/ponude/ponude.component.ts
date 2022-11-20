import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {aplication_settings} from "../../aplication_settings";
import{ponudaAddVm} from "../../Modeli/PonudaAddVm";
import { Router } from '@angular/router';

import{pipe} from "rxjs";



@Component({
  selector: 'app-ponude',
  templateUrl: './ponude.component.html',
  styleUrls: ['./ponude.component.scss']
})
export class PonudeComponent implements OnInit {
   ponudePodaci: any;
   prikaziDodavanje: boolean=false;
   add:ponudaAddVm={vrsta_ponude:'',pocetakPonude:'',trajanjePonude:0,radnikId:0};
   edit:ponudaAddVm={vrsta_ponude:'',pocetakPonude:'',trajanjePonude:0,radnikId:0};
  odabranaPonuda:any;
  stavkePodaci:any;
  prikaziUredjivanje: boolean=false;





  constructor(private httpKlijent: HttpClient,private router: Router) {

  }
  private prikaziPonude() {
    this.httpKlijent.get(aplication_settings.arminURL + "Ponuda").subscribe(x => {
      this.ponudePodaci = x;
    });
  }
  ngOnInit(): void {
    this.prikaziPonude();
  }


  getPonudePodaci() {
    if (this.ponudePodaci == null)
      return [];
    return this.ponudePodaci;
  }


  dodavanje() {
    this.prikaziDodavanje=true;
  }

  DodajPonudu() {

    this.httpKlijent.post(aplication_settings.arminURL + "Ponuda", this.add).subscribe((povratnaVrijednost: any) => {
      alert("uredu..." + povratnaVrijednost.id);
    },error =>{ alert( error.error.title);});

    this.prikaziDodavanje=false;

    setTimeout(()=>{this.prikaziPonude()},1000) ;
  }

  obrisiPonudu(s:any) {
    this.httpKlijent.delete(aplication_settings.arminURL+"Ponuda/"+s.id).subscribe((pov:any)=>{
      const index = this.ponudePodaci.indexOf(s);
      if (index > -1) {
        this.ponudePodaci.splice(index, 1);
      }
      alert("Izbrisana ponuda ID:"+pov.id);
    });
  }

  ucitajProizvode(s:any) {
    this.router.navigate(['/Proizvod',s.id]);
  }

  getStavkePodaci() {
    if (this.stavkePodaci == null)
      return [];
    return this.stavkePodaci;
  }

  uredi(s:any) {
    this.odabranaPonuda=s;
    this.prikaziUredjivanje=true;
  }

  snimi() {
      this.edit.vrsta_ponude=this.odabranaPonuda.vrsta_ponude;
    this.edit.pocetakPonude=this.odabranaPonuda.pocetakPonude;
    this.edit.trajanjePonude=this.odabranaPonuda.trajanjePonude;
    this.edit.radnikId=this.odabranaPonuda.radnikId;


    this.httpKlijent.put(aplication_settings.arminURL + "Ponuda/"+this.odabranaPonuda.id, this.edit)
      .subscribe((povratnaVrijednost: any) => {

        },error =>{ alert( error.error);}
      );

    setTimeout(()=>this.prikaziPonude(),1000);

    this.prikaziUredjivanje=false;

  }
}
