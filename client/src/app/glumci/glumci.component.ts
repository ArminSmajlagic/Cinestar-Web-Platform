import { Component, OnInit } from '@angular/core';
import {aplication_settings} from "../aplication_settings";
import {HttpClient} from "@angular/common/http";
import {glumacAddVm} from "../Modeli/GlumacAddVm";


@Component({
  selector: 'app-glumci',
  templateUrl: './glumci.component.html',
  styleUrls: ['./glumci.component.scss']
})
export class GlumciComponent implements OnInit {
  private glumacPodaci: any;
   prikaziDodavanje: boolean=false;
  add:glumacAddVm={_ime:'',_prezime:'',_datumRodj:''};
   odabraniGlumac: any= null;
   prikaziUredjivanje:boolean=true;
   ime: string='';

  constructor(private httpKlijent: HttpClient) {

  }
  prikaziGlumce(): void {
    this.httpKlijent.get(aplication_settings.damir_local + "Glumac/GetAll").subscribe(x => {
      this.glumacPodaci = x;
    });
  }

  ngOnInit(): void {
    this.prikaziGlumce();
  }

  getGlumacPodaci() {
    if (this.glumacPodaci == null)
      return [];
    return this.glumacPodaci.filter((x:any)=>x.ime.length==0 || (x.ime + " " +x.prezime).toLowerCase().startsWith(
     this.ime.toLowerCase())
     || (x.prezime + " " +x.ime).toLowerCase().startsWith(this.ime.toLowerCase())
    );


  }

  dodavanje() {
    this.prikaziDodavanje=true;
  }

  DodajGlumca() {
    this.httpKlijent.post(aplication_settings.damir_local + "Glumac/Add", this.add).subscribe((povratnaVrijednost: any) => {
      alert("uredu..." + povratnaVrijednost.id);
    },error =>{ alert( error.error);});

    this.prikaziDodavanje=false;

    setTimeout(()=>this.prikaziGlumce(),1000) ;
  }

  obrisiGlumca(s:any) {

    this.httpKlijent.post(aplication_settings.damir_local+"Glumac/Delete?id="+s.id,null).subscribe((pov:any)=>{
      const index = this.glumacPodaci.indexOf(s);
      if (index > -1) {
        this.glumacPodaci.splice(index, 1);
      }
      alert("Izbrisan glumac ID:"+pov.id);
    });
  }

  urediGlumca(s:any) {
    this.prikaziUredjivanje=true;
    this.odabraniGlumac = s;
    this.odabraniGlumac.datumRodjenja=this.odabraniGlumac.datumRodjenja.substr(0,10);
  }

  snimi() {
    this.add._ime = this.odabraniGlumac.ime;
    this.add._prezime = this.odabraniGlumac.prezime;
    this.add._datumRodj=this.odabraniGlumac.datumRodjenja;

    this.httpKlijent.post(aplication_settings.damir_local + "Glumac/Update/?id=" + this.odabraniGlumac.id, this.add)
      .subscribe((povratnaVrijednost: any) => {
          alert("uredu..." + povratnaVrijednost.id);
        },error =>{ alert( error.error);}
      );

    setTimeout(()=>this.prikaziGlumce(),1000);

    this.prikaziUredjivanje=false;
  }

  onSubmit() {

  }

  checkEmpty() {
   // var btn= document.querySelector('#clsButton') as HTMLButtonElement;

   //setTimeout(()=>!(this.odabraniGlumac.ime.isEmpty() || this.odabraniGlumac.prezime.isEmpty()),1000);
  }
}
