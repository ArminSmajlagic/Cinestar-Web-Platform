import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {ChartModule} from 'primeng/chart';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { FilmoviComponent } from './filmovi/filmovi.component';
import { ProjekcijeComponent } from './projekcije/projekcije.component';
import { CommonModule } from '@angular/common';
import { PonudeComponent } from './Ponude/ponude/ponude.component';
import { DetaljiFilmaComponent } from './detalji-filma/detalji-filma.component';
import { GlumciComponent } from './glumci/glumci.component';
import { StavkeComponent } from './stavke/stavke.component';
import { ProizvodComponent } from './proizvod/proizvod.component';
import { DatepipeComponent } from './datepipe/datepipe.component';
import {DatePipe} from "@angular/common";
import { MoviesPanelComponent } from './client-movies/movies-panel/movies-panel.component';
import { ManagementNavigationComponent } from './GeneralComponents/management-navigation/management-navigation.component';
import { ClientNavComponent } from './GeneralComponents/client-nav/client-nav.component';
import { ClientHomeComponent } from './GeneralComponents/home/client/client-home/client-home.component';
import { HomeComponent } from './GeneralComponents/home/home.component';
import { WorkerComponent } from './Korisnici/worker-panel/worker/worker.component';
import { FilterPipe } from './Korisnici/Pipes/filter-pipe.pipe';
import { UsersPanelComponent } from './Korisnici/users-panel/users-panel.component';
import { ClientMovieDetailsComponent } from './client-movie-details/client-movie-details.component';
import { BuyTicketsComponent } from './buy-kupac/buy-tickets/buy-tickets.component';
import { BuySnacksModalComponent } from './buy-kupac/buy-snacks/buy-snacks-modal.component';
import { StavkaComponent } from './buy-kupac/buy-snacks/stavka/stavka.component';
import { DashboardComponent } from './bi-dashboard/dashboard/dashboard.component';
import { MidComponent } from './bi-dashboard/mid/mid.component';
import { TableComponent } from './bi-dashboard/table/table.component';
import { NavComponent } from './bi-dashboard/nav/nav.component';
import { LoginComponent } from './Auth/Components/Login/login/login.component';
import { RegisterComponent } from './Auth/Components/Register/register/register.component';
import { ConfirmMailComponent } from './Auth/Components/confirm-mail/confirm-mail.component';
import{NotificationService, PushSubscription} from './core/generated';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{NgxPaginationModule} from "ngx-pagination";


@NgModule({
  declarations: [
    AppComponent,
    FilmoviComponent,
    ProjekcijeComponent,
    PonudeComponent,
    DetaljiFilmaComponent,
    GlumciComponent,
    StavkeComponent,
    ProizvodComponent,
    DatepipeComponent,
    MoviesPanelComponent,
    ManagementNavigationComponent,
    ClientNavComponent,
    ClientHomeComponent,
    HomeComponent,
    WorkerComponent,
    FilterPipe,
    UsersPanelComponent,
    ClientMovieDetailsComponent,
    BuyTicketsComponent,
    BuySnacksModalComponent,
    StavkaComponent,
    DashboardComponent,
    LoginComponent,
    RegisterComponent,
    ConfirmMailComponent,
    NavComponent,
    MidComponent,
    TableComponent
  ],
  imports: [
    BrowserModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    CommonModule,
    ChartModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxPaginationModule
  ],
  providers: [DatePipe,NotificationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
