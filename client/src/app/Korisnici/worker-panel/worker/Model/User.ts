export interface User{
  id?:                     number;
  ime_prezime?:            string;
  username?:               string;
  email?:                  string;
  b_date?:                 Date;
  password?:               string;
  broj_telefona?:          number;
  datum_kreiranja_racuna?: Date;
  confirmed?:              number;
  confMailXkorisniciId?:   number;
  confMailXkorisnici?:     ConfMailXkorisnici;
  spol:number;
  gradId:number;
}

export interface ConfMailXkorisnici {
  id:             number;
  issuedConfCode: string;
}
