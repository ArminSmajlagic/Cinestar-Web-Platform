import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import {HttpClient} from "@angular/common/http";
import{aplication_settings} from "../aplication_settings";
import {Pokusaj} from "../Modeli/Pokusaj";

@Component({
  selector: 'app-stavke',
  templateUrl: './stavke.component.html',
  styleUrls: ['./stavke.component.scss']
})
export class StavkeComponent implements OnInit {
  stavkePodaci:any;
  id: number;
  private sub: any;
  name:string;
  hilfe:Pokusaj={name:' '};

  constructor(private route:ActivatedRoute,private httpKlijent: HttpClient) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      // In a real app: dispatch action to load the details here.
    });
    this.UcitajStavke();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  UcitajStavke() {




    this.httpKlijent.get(aplication_settings.damir_local+"VrstaProjekcije/GetStavke?_id="+this.id)
      .subscribe((pov:any)=>{
      this.stavkePodaci=pov;
    });
  }

  getStavkePodaci() {
    if (this.stavkePodaci == null)
      return [];
    return this.stavkePodaci;
  }

  obrisiStavku(s:any) {
    this.httpKlijent.delete(aplication_settings.arminURL+"StavkaPonude/"+s.id).subscribe((pov:any)=>{
      const index = this.stavkePodaci.indexOf(s);
      if (index > -1) {
        this.stavkePodaci.splice(index, 1);
      }
      alert("Izbrisana stavka ponuda ID:"+pov.id);
    });
  }
}
