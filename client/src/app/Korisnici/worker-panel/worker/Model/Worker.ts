export interface Worker {
  jmbg:             string;
  datum_uposljenja: string;
  strucnaSprema:    string;
  vrstaRadnikaId:   number;
  vrstaRadnika:     VrstaRadnika;
  id:               number;
  ime_prezime:      string;
  username:         string;
  email:            string;
  b_date:           Date;
  password:         string;
  broj_telefona:    number;
  spol: string;
  gradId: number;
  grad: Grad;
  plata: number;
}

export class VrstaRadnika {
  id?:    number;
  naziv?: string;

  constructor(id:number,naziv:string) {
    this.id=id;
    this.naziv=naziv;
  }
}

export interface Grad {
  id:    number;
  naziv: string;
}
