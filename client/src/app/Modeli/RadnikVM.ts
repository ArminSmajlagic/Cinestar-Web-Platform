import { Grad  } from "../Korisnici/worker-panel/worker/Model/General";
import { User } from "../Korisnici/worker-panel/worker/Model/User";

export interface KorisnikVM{
  gradovi:Grad[];
  korisnici:User[];
}
