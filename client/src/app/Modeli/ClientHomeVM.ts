export interface ClientHomeVM{
  filmovi:Film[];
}

export interface Film{
  id:number;
  naziv: string;
  zanr: string;
  slikaUrl: string;
  slikaByte: null;
  rating: number;
  detaljiFilmaID: number;
}
