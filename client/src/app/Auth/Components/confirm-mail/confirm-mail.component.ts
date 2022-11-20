import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/Korisnici/users-panel/Service/user.service';
import { User } from 'src/app/Korisnici/worker-panel/worker/Model/User';

import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-confirm-mail',
  templateUrl: './confirm-mail.component.html',
  styleUrls: ['./confirm-mail.component.scss']
})
export class ConfirmMailComponent implements OnInit {
  person_id:any;
  respons:any;
  email?:string;
  username?:string;
  constructor(private route: ActivatedRoute,private userService:UserService,private router:Router,private authService:AuthService) {
      this.person_id = this.route.snapshot.paramMap.get('id')

  }

  ngOnInit(): void {
    this.userService.getById(this.person_id).subscribe(x=>{
      this.email=(x as User).email;
      this.username=(x as User).username;
    })
  }

  confirm_mail(code:string){
    this.authService
    .confirmUser(this.person_id,code)
    .subscribe(
      res=>{
        this.respons=(res as any).message;
      if(this.respons=="You have confirmed user sucessfully")
        this.router.navigate(['/cinehome'])

      console.log(this.respons)
    },
    err=>{
      console.log(err)
    })


  }

}
