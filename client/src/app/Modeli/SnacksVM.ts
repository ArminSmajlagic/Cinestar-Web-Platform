export interface SnacksVM{
  proizvodi:Proizvod[];
}

export interface Proizvod{
  id:       number;
  porcija:  string;
  naziv:    string;
  cijena:   number;
  slikaUrl: string;
  ponudaId: number;
  ponude:   null;
}


