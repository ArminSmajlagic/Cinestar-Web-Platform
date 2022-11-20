import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { aplication_settings } from 'src/app/aplication_settings';
import { Grad } from '../../worker-panel/worker/Model/General';
import { User } from '../../worker-panel/worker/Model/User';
import { KorisnikVM } from 'src/app/Modeli/RadnikVM';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  type:string="Korisnik/";
  constructor(private http:HttpClient) { }

  getAll(){
    return this.http
    .get<KorisnikVM>(aplication_settings.damir_local+'KorisnikVM');

  }

  getById(id:number){
    return this.http.get(aplication_settings.cinestar__plesk__server+this.type+id)
  }

  insert(user:User){
    return this.http.post(aplication_settings.damir_local+'KorisnikVM/',{
      ime_prezime: user.ime_prezime,
      username: user.username,
      email:  user.email,
      b_date:  user.b_date,
      password:  user.password,
      broj_telefona:  user.broj_telefona,
      datum_kreiranja_racuna:  user.datum_kreiranja_racuna,
      confirmed:  user.confirmed,
      confMailXkorisniciId:  user.confMailXkorisniciId,
      confMailXkorisnici: {
        id:  user.id,
        issuedConfCode: user?.confMailXkorisnici?.issuedConfCode
      }
    })

  }
  update(id:number,user:User){

    return this.http.put(aplication_settings.damir_local+'KorisnikVM/'+id,{
      ime_prezime: user.ime_prezime,
      username: user.username,
      email:  user.email,
      b_date:  user.b_date,
      password:  user.password,
      broj_telefona:  user.broj_telefona,
      datum_kreiranja_racuna:  user.datum_kreiranja_racuna,
      confirmed:  user.confirmed,
      confMailXkorisniciId:  user.confMailXkorisniciId,
      confMailXkorisnici: {
        id:  user.id,
        issuedConfCode: user?.confMailXkorisnici?.issuedConfCode
      }
    })
  }

  delete(id:number){
    return this.http.delete(aplication_settings.cinestar__plesk__server+this.type+id)

  }

  getGradovi(){
    return this.http.get<Grad[]>(aplication_settings.cinestar__plesk__server+"Grad");
  }


}
