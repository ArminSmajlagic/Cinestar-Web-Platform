import { Component, OnInit } from '@angular/core';
import {aplication_settings} from "../aplication_settings";
import {HttpClient} from "@angular/common/http";
import {ProjekcijaAddVm} from "../Modeli/ProjekcijaAddVm";

@Component({
  selector: 'app-projekcije',
  templateUrl: './projekcije.component.html',
  styleUrls: ['./projekcije.component.scss']
})
export class ProjekcijeComponent implements OnInit {
   projekcijePodaci: any;
   vrstaProjekcijeNaziv:any;
  prikaziDodavanje: boolean=false;
  add:ProjekcijaAddVm={dan:'',vrijemePrikazivanja:'',vrstaProjekcijeId:0,filmId:0};
   prikaziUredjivanje: boolean=false;
   odabranaProjekcija: any;
  constructor(private httpKlijent: HttpClient) {

  }

  prikaziProjekcije(): void {
    this.httpKlijent.get(aplication_settings.damir_local + "Projekcija/GetAll").subscribe(x => {
      this.projekcijePodaci = x;
    });
  }

  ngOnInit(): void {
    this.prikaziProjekcije();
    this.getVrstaProjekcije();
  }

  getProjekcijePodaci() {
    if (this.projekcijePodaci == null)
      return [];
    return this.projekcijePodaci;
  }

  getVrstaProjekcije() {


        this.httpKlijent.get(aplication_settings.damir_local+"VrstaProjekcije/GetAll").subscribe(pov=>{
          this.vrstaProjekcijeNaziv=pov;
        });
        return this.vrstaProjekcijeNaziv;
  }

  dodajProjekciju(){
        this.httpKlijent.post(aplication_settings.damir_local + "Projekcija/Add", this.add).subscribe((povratnaVrijednost: any) => {
      alert("uredu..." + povratnaVrijednost.id);
    },error =>{ alert( error.error);});

    this.prikaziDodavanje=false;

    setTimeout(()=>{this.prikaziProjekcije()},1000) ;
  }

  obrisiProjekciju(s:any) {
    this.httpKlijent.post(aplication_settings.damir_local+"Projekcija/Delete?id="+s.id,null).subscribe((pov:any)=>{
      const index = this.projekcijePodaci.indexOf(s);
      if (index > -1) {
        this.projekcijePodaci.splice(index, 1);
      }
      alert("Izbrisana projekcija ID:"+pov.id);
    });
  }

  urediProjekciju(s:any) {
    this.prikaziUredjivanje=true;
    this.odabranaProjekcija = s;
  }

  snimi() {
        this.httpKlijent.post(aplication_settings.damir_local + "Projekcija/Update/?id=" + this.odabranaProjekcija.id, this.odabranaProjekcija)
      .subscribe((povratnaVrijednost: any) => {
          alert("uredu..." + povratnaVrijednost.id);
        },error =>{
        if(error.error.title=="One or more validation errors occurred.")
          alert( error.error.title);
        else
          alert(error.error);

      }
      );

    setTimeout(()=>{this.projekcijePodaci()},1000) ;

    this.prikaziUredjivanje=false;
  }
}
