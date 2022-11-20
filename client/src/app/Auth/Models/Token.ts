
export class Token{
  token:string;
  expiresIn:number;
  issued:string;
  scope:string;
  error:string;
  id:number;
  constructor(token:string,expiresIn:number,issued:string,scope:string,error:string,id:number) {
    this.token = token;
    this.expiresIn = expiresIn;
    this.issued = issued;
    this.scope = scope;
    this.error = error;
    this.id = id;
  }
}
