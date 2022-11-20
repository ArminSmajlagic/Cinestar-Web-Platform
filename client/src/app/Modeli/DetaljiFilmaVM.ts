import { Film } from "./ClientHomeVM";

export interface DeskripcijaFilmaVM{
  detalji:DetaljiFilma;
  film:Film;
}

export interface DetaljiFilma{
  id:          number;
  trajanje:    string;
  datumObjave: Date;
  trailer:     string;
  trailerID:   string;
}
