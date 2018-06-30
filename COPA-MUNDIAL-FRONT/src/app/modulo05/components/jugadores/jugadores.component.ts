import { Component, OnInit, NgZone, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Jugador } from '../../models/jugador';
import { Conexion } from '../../models/conexion';
import { JugadorService } from '../../services/jugador.service';
import {DTOMostrarJugador} from '../../models/dtomostrar-jugador';
import {DTOActivarJugador} from '../../models/dtoactivar-jugador';
import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Observable, Subject } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};


@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css']
})

@Injectable()
export class JugadoresComponent implements OnInit {
  title = 'Jugadores';
  conexion : Conexion;
  url : string;
  ListJugadores: DTOMostrarJugador[] = [];
  ListJugadoresActivos: DTOMostrarJugador[] = [];
  ListJugadoresInactivos: DTOMostrarJugador[] = [];
  jugador : Jugador;
  activar_jugador : DTOActivarJugador;
  desactivar_jugador : DTOActivarJugador;

  readonly rootUrl =  'http://localhost:51543/api';

  constructor(private router: Router,
    public http: HttpClient) 
    { 
      this.conexion = new Conexion();
      this.jugador = new Jugador();
    }

  ngOnInit() {

    this.obtenerJugadores();
    this.obtenerJugadoresActivos();
    this.obtenerJugadoresInactivos();

  }

  registrarJugador(playerRegistrationForm){
    this.conexion.controller = 'agregarJugador';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;

    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');


    const {Nombre, Apellido, FechaNacimiento, 
      LugarNacimiento, Peso, Altura, Posicion, 
      Numero, Equipo} = playerRegistrationForm.controls;
    

    console.log(playerRegistrationForm.controls, Nombre.value, Apellido.value);
    
    
    const player = {
      nombre          : Nombre.value,
      apellido        : Apellido.value,
      fechaNacimiento : FechaNacimiento.value,
      lugarNacimiento : LugarNacimiento.value,
      peso            : Peso.value,
      altura          : Altura.value,
      posicion        : Posicion.value,
      numero          : Numero.value,
      equipo          : Equipo.value  
    };

      this.http
      .post<Jugador>(this.url, player, httpOptions)
      .subscribe(
        success => {
          console.log(success)
        },
        error => alert("Error en el sistema")
      );
    
  }
  
  obtenerJugadores(){
    this.conexion.controller = 'obtenerJugadores';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadores[i] = data[i];
      }
    });
  }

  obtenerJugadoresActivos(){
    this.conexion.controller = 'obtenerJugadoresActivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresActivos[i] = data[i];
      }
    });

  }

  obtenerJugadoresInactivos(){
    this.conexion.controller = 'obtenerJugadoresInactivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresInactivos[i] = data[i];
      }
    });

  }

}