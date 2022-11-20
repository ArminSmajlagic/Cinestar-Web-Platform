import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import {HttpClient} from "@angular/common/http";
import{aplication_settings} from "../aplication_settings";
import {proizvodPAddVm} from "../Modeli/ProizvodPAddVm";
import {Router} from "@angular/router";

@Component({
  selector: 'app-proizvod',
  templateUrl: './proizvod.component.html',
  styleUrls: ['./proizvod.component.scss']
})
export class ProizvodComponent implements OnInit {
  proizvodPodaci:any;
  id: number;
  private sub: any;
  sviProizvodi:boolean=false;
  prikaziDodavanje: boolean=false;
  add:proizvodPAddVm={id:0,porcija:'',naziv:'',cijena:0,ponudaId:0,slikaUrl:''};
   prikaziUredjivanje: boolean=false;
   odabraniProizvod: any;
  constructor(private route:ActivatedRoute,private httpKlijent: HttpClient,private router:Router) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      // In a real app: dispatch action to load the details here.
    });
    this.UcitajProizvode();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  private UcitajProizvode() {
    if(isNaN(this.id))
    {
      this.sviProizvodi=true;
      this.httpKlijent.get(aplication_settings.arminURL+"Proizvod")
        .subscribe((pov:any)=>{
          this.proizvodPodaci=pov;
        });
    }
    else{
      this.httpKlijent.get(aplication_settings.damir_local+"VrstaProjekcije/GetProizvodi?_id="+this.id)
        .subscribe((pov:any)=>{
          this.proizvodPodaci=pov;
        });
    }




  }

  getProizvodPodaci() {
    if (this.proizvodPodaci == null)
      return [];
    return this.proizvodPodaci;
  }

  DodajProizvod() {
    this.add.ponudaId=this.id;

    this.httpKlijent.post(aplication_settings.arminURL+"Proizvod",this.add).subscribe((pov:any)=>
    {
      alert("Uspjesno dodan proizvod");
    });

    setTimeout(()=>{this.UcitajProizvode()},1000) ;
  }

  obrisiProizvod(s:any) {
    this.httpKlijent.delete(aplication_settings.arminURL+"Proizvod/"+s.id).subscribe((pov:any)=>{
      const index = this.proizvodPodaci.indexOf(s);
      if (index > -1) {
        this.proizvodPodaci.splice(index, 1);
      }
      alert("Izbrisan proizvod ID:"+pov.id);
    });
  }

  naPonude() {
    this.router.navigate(['Ponude']);
  }

  urediProizvod(s:any) {
    this.prikaziUredjivanje=true;
    this.odabraniProizvod = s;
  }

  snimi() {
    this.httpKlijent.put(aplication_settings.arminURL + "Proizvod/" + this.odabraniProizvod.id, this.odabraniProizvod)
      .subscribe((povratnaVrijednost: any) => {
          alert("uredu..." + povratnaVrijednost.id);
        },error =>{ alert( error.error);}
      );

    setTimeout(()=>{ if(isNaN(this.id))
    {
      this.sviProizvodi=true;
      this.httpKlijent.get(aplication_settings.arminURL+"Proizvod")
        .subscribe((pov:any)=>{
          this.proizvodPodaci=pov;
        });
    }
    else{
      this.httpKlijent.get(aplication_settings.damir_local+"VrstaProjekcije/GetProizvodi?_id="+this.id)
        .subscribe((pov:any)=>{
          this.proizvodPodaci=pov;
        });
    }
    },1000) ;

    this.prikaziUredjivanje=false;
  }
}
