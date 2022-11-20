import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { aplication_settings } from 'src/app/aplication_settings';
import { AuthService } from 'src/app/Auth/Services/auth.service';
import { Grad } from 'src/app/Korisnici/worker-panel/worker/Model/General';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  passcode:string="password"
  registrationForm:any;
  user_id:any;
  spolovi:any=[{naziv:"M",value:0},{naziv:"Ž",value:1}]
  gradovi:any=[];
  constructor(private authService:AuthService,private router:Router,private fb:FormBuilder,private http:HttpClient) {

    this.getGradovi();
  }

  ngOnInit(): void {
    this.createForm();
  }

  register(form:FormGroup){
    this.authService.register({
        username:form.value.username,
        password:form.value.password,
        ime_prezime:form.value.ime_prezime,
        email:form.value.email,
        bdate:form.value.b_date,
        gender:form.value.spol,
        cityId:form.value.gradovi,
        broj_telefona:form.value.broj_telefona
      }).subscribe(res=>{
        this.user_id=res;
        this.router.navigate(['/Confirm/'+this.user_id])
        //this.authService.login(form.value.username,form.value.password)
    })
  }
  passwordToggle(){
    this.passcode=this.passcode=="password"?'text':'password';

  }


  createForm(){

    this.registrationForm = this.fb.group({
      username:[,Validators.required],
      password:[,Validators.required],
      email:[,Validators.required],
      ime_prezime:[,Validators.required],
      b_date:[,Validators.required],
      spol:[,Validators.required],
      gradovi:[,Validators.required],
      broj_telefona:[,Validators.required],
    })

  }
  log(stuf:any){
    console.log(stuf)
  }
  get regForma(){
    return this.registrationForm.controls;
  }

  getGradovi(){
    this.gradovi=[];

    this.http
    .get<Grad[]>(aplication_settings.cinestar__plesk__server+"Grad").subscribe(x=>{
      const somthing = x;
      for (let i = 0; i < (somthing as Grad[]).length; i++) {
        this.gradovi.push({
          naziv:(somthing as Grad[])[i].naziv,
          value:(somthing as Grad[])[i].id
        });
      }
    });
  }

}
