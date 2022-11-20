export class Register{
  username:string;
  password:string;
  ime_prezime:string;
  email:string;
  bdate:string;
  gender:number;
  broj_telefona:number;
  cityId:number;

  constructor(username:string,password:string,ime_prezime:string,email:string,bdate:string,gender:number,broj_telefona:number) {
    this.username=username;
    this.password=password;
    this.ime_prezime=ime_prezime;
    this.email=email;
    this.bdate=bdate;
    this.broj_telefona=broj_telefona;
    this.gender=gender;
  }
}
