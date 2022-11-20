import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmMailComponent } from './Auth/Components/confirm-mail/confirm-mail.component';
import { LoginComponent } from './Auth/Components/Login/login/login.component';
import { RegisterComponent } from './Auth/Components/Register/register/register.component';
import { GuardService } from './Auth/Services/guard.service';
import { DashboardComponent } from './bi-dashboard/dashboard/dashboard.component';
import { BuyTicketsComponent } from './buy-kupac/buy-tickets/buy-tickets.component';
import { ClientMovieDetailsComponent } from './client-movie-details/client-movie-details.component';
import { MoviesPanelComponent } from './client-movies/movies-panel/movies-panel.component';
import { DatepipeComponent } from './datepipe/datepipe.component';
import { DetaljiFilmaComponent } from './detalji-filma/detalji-filma.component';
import { FilmoviComponent } from './filmovi/filmovi.component';
import { ClientHomeComponent } from './GeneralComponents/home/client/client-home/client-home.component';
import { HomeComponent } from './GeneralComponents/home/home.component';
import { GlumciComponent } from './glumci/glumci.component';
import { UsersPanelComponent } from './Korisnici/users-panel/users-panel.component';
import { WorkerComponent } from './Korisnici/worker-panel/worker/worker.component';
import { PonudeComponent } from './Ponude/ponude/ponude.component';
import { ProizvodComponent } from './proizvod/proizvod.component';
import { ProjekcijeComponent } from './projekcije/projekcije.component';
import { StavkeComponent } from './stavke/stavke.component';

const routes: Routes = [
  {path: 'Film', component: FilmoviComponent },
  {path: 'Projekcija', component: ProjekcijeComponent },
  { path:'Ponude',component:PonudeComponent },
  { path:'DetaljiFilma',component:DetaljiFilmaComponent },
  { path:'Glumci',component:GlumciComponent },
  { path:'Stavke/:id',component:StavkeComponent },
  { path:'Stavke',component:StavkeComponent },
  { path:'Proizvod/:id',component:ProizvodComponent },
  { path:'Proizvod',component:ProizvodComponent },
  { path:'Datepipe',component:DatepipeComponent },
  { path: 'movies', component: MoviesPanelComponent },
  { path: 'cinehome', component: ClientHomeComponent },
  { path: 'Management/home', component: HomeComponent },
  { path:'Management/Worker',component:WorkerComponent  },
  { path:'Management/Users',component:UsersPanelComponent  },
  { path: 'movie/:id', component: ClientMovieDetailsComponent },
  { path: 'buy-tickets', component: BuyTicketsComponent},
  { path:'Login',component:LoginComponent },
  { path:'Management/Login',component:LoginComponent },
  { path:'Register',component:RegisterComponent },
  { path:'Confirm/:id',component:ConfirmMailComponent },
  { path:'Management/Statistics',component:DashboardComponent , },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
