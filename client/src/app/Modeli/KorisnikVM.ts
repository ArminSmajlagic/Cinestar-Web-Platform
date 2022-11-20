import { Grad  } from "../Korisnici/worker-panel/worker/Model/General";
import { Worker  } from "../Korisnici/worker-panel/worker/Model/Worker";

export interface RadnikVM{
  gradovi:Grad[];
  radnici:Worker[];
}
