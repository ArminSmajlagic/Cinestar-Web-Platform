import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { filter, Observable, of,pipe } from 'rxjs';
import { Grad } from '../worker-panel/worker/Model/General';
import { User } from '../worker-panel/worker/Model/User';
import { UserService } from './Service/user.service';


@Component({
  selector: 'app-users-panel',
  templateUrl: './users-panel.component.html',
  styleUrls: ['./users-panel.component.scss']
})
export class UsersPanelComponent implements OnInit {
  usersFiltered:any=[];
  city:any;
  grad:any;
  spol:any;
  pretragaGrada:any;
  users$:any;
  uredi:boolean=false;
  default:boolean=false;
  none=true;
  user:any;
  count:number=0;
  contactForm:FormGroup;
  urediForma:any;
  options:any;
  Name:string=''
  passcode:string='password';
  spolovi:any=[{naziv:"M",value:0},{naziv:"Ž",value:1}]

  constructor(private userService:UserService,private fb:FormBuilder) {
    this.contactForm=fb.group({
      select:[null],
      searchText: new FormControl(''),
    });
   }


  SearchPoGradu(e:any){
    if(this.pretragaGrada=="NOT_CHANGED")
    {
      this.pretragaGrada = null;
      return;
    }
    else if(this.pretragaGrada!="NOT_CHANGED" ){
      this.pretragaGrada=this.options[e.target.value[0]];
      this.loadUsers(this.pretragaGrada);
      this.pretragaGrada = "NOT_CHANGED";
    }
  }

  ngOnInit(): void {
    this.createForm()
    this.loadUsers()
  }

  Search(form: FormGroup){
    this.city="";
       this.contactForm.value.searchText.setValue('');
       this.loadUsers()
    }

  loadUsers(pretragaGrada:any=null){
      this.users$=null;
      this.userService.getAll().subscribe(x=>{
      this.users$=x.korisnici;
      this.options=x.gradovi;
      this.count=this.users$.length;
      if(pretragaGrada!=null)
      {
        this.usersFiltered=[]
        this.users$.forEach((item:Worker) => {
            this.usersFiltered.push(item);
        });
        this.users$=[];
        this.users$=((this.usersFiltered as unknown) as Worker[]);
      }
    });
  }



  toggle(action:string){
    if(action=='back'){
      this.uredi=false;
      this.default=true;
    }

    if(action=='uredi'){
      this.uredi=true;
      this.default=false;
    }


    if(action=='none'){
      this.uredi=false;
      this.default=false;
      this.none=true;
    }
  }
  odaberi(id:number){
    this.userService.getById(id).subscribe(x=>{
      this.user=x;
      this.none=false;
      this.default=true;
      this.getUrediForm.username.setValue(this.user.username);
      this.getUrediForm.ime_prezime.setValue(this.user.ime_prezime);
      this.getUrediForm.password.setValue(this.user.password);
      this.getUrediForm.email.setValue(this.user.email);
      this.getUrediForm.broj_telefona.setValue(this.user.broj_telefona);
      this.getUrediForm.confirmed.setValue(this.user.confirmed);
      this.urediForma.controls.spol.setValue(this.user.spol);
    });
    this.toggle('back')
  }

  update(id:number,form:FormGroup){
    (this.user as User).username=form.value.username;
    (this.user as User).ime_prezime=form.value.ime_prezime;
    (this.user as User).email=form.value.email;
    (this.user as User).password=form.value.password;
    (this.user as User).broj_telefona=form.value.broj_telefona;
    (this.user as User).gradId=form.value.grad;
    (this.user as User).confirmed=form.value.confirmed?1:0;
     this.userService.update(id,this.user).subscribe();
    this.loadUsers()
  }
  clearFilters(){
    this.city="";
    this.Name="";
    this.loadUsers()
  }

  remove(id:number){
    this.userService.delete(id).subscribe();
    this.loadUsers()
  }

  passwordToggle(){
    this.passcode=this.passcode=="password"?'text':'password';
  }

  setGrad(e:any=null,city:Grad|null=null){
    if(e!=null){
      this.grad=this.options[e.target.value[0]];
      console.log(e.target);
    }else{
      this.grad=city;
    }
  }

  setSpol(e:any=null,gender:string|null=null){
    if(e!=null){
      this.spol=this.spolovi[e.target.value[0]];
      console.log(this.spol);
    }else{
      this.spol=gender;
    }
  }

  createForm(){
    this.urediForma=this.fb.group({
      username: [new FormControl(),Validators.required],
      broj_telefona: [new FormControl(''),Validators.required],
      email: [new FormControl(''),Validators.required],
      password: [new FormControl(''),Validators.required],
      ime_prezime: [new FormControl(''),Validators.required],
      grad:[''],//Validators.required],
      spol:[new FormControl(this.spolovi),Validators.required],
      //b_date:[new FormControl(),Validators.required],
      confirmed:[new FormControl(),Validators.required],
    })
  }


  get getUrediForm(){
    return this.urediForma.controls;
  }
}
