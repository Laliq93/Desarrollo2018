import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-cliente-detalles',
  templateUrl: './cliente-detalles.component.html',
  styleUrls: ['./cliente-detalles.component.css']
})
export class ClienteDetallesComponent implements OnInit {

  public equipo1;
  public equipo2;

  public listaJugadores1 = [
    {
      nombre: 'NIGMATULLIN',
      posicion: 'portero',
      numero: '1',
      estado: 'titular'
    },
    {
      nombre: 'KOVTUN',
      posicion: 'defensa',
      numero: '2',
      estado: 'titular'
    },
    {
      nombre: 'NIKIFOROV',
      posicion: 'defensa',
      numero: '3',
      estado: 'titular'
    },
    {
      nombre: 'SOLOMATIN',
      posicion: 'defensa',
      numero: '5',
      estado: 'titular'
    },
    {
      nombre: 'SEMSHOV',
      posicion: 'defensa',
      numero: '6',
      estado: 'titular'
    },
    {
      nombre: 'ONOPKO',
      posicion: 'medio',
      numero: '7',
      estado: 'titular'
    },
    {
      nombre: 'KARPIN',
      posicion: 'medio',
      numero: '8',
      estado: 'titular'
    },
    {
      nombre: 'TITOV',
      posicion: 'medio',
      numero: '9',
      estado: 'titular'
    },
    {
      nombre: 'BESCHASTNYKH',
      posicion: 'delantero',
      numero: '11',
      estado: 'titular'
    },
    {
      nombre: 'PIMENOV',
      posicion: 'delantero',
      numero: '19',
      estado: 'titular'
    },
    {
      nombre: 'IZMAYLOV',
      posicion: 'delantero',
      numero: '20',
      estado: 'titular'
    },
    {
      nombre: 'SMERTIN',
      posicion: 'portero',
      numero: '19',
      estado: 'suplente'
    },
    {
      nombre: 'MOSTOVOY',
      posicion: 'defensor',
      numero: '10',
      estado: 'suplente'
    },
    {
      nombre: 'CHERCHESOV',
      posicion: 'defensor',
      numero: '12',
      estado: 'suplente'
    },
    {
      nombre: 'DAEV',
      posicion: 'delantero',
      numero: '13',
      estado: 'suplente'
    },
    {
      nombre: 'CHIGAYNOV',
      posicion: 'delantero',
      numero: '14',
      estado: 'suplente'
    },
    {
      nombre: 'ALENICHEV',
      posicion: 'delantero',
      numero: '15',
      estado: 'suplente'
    }
  ];
  public listaJugadores2 = [
    {
      nombre: 'NIGMATULLIN',
      posicion: 'portero',
      numero: '1',
      estado: 'titular'
    },
    {
      nombre: 'KOVTUN',
      posicion: 'defensa',
      numero: '2',
      estado: 'titular'
    },
    {
      nombre: 'NIKIFOROV',
      posicion: 'defensa',
      numero: '3',
      estado: 'titular'
    },
    {
      nombre: 'SOLOMATIN',
      posicion: 'defensa',
      numero: '5',
      estado: 'titular'
    },
    {
      nombre: 'SEMSHOV',
      posicion: 'defensa',
      numero: '6',
      estado: 'titular'
    },
    {
      nombre: 'ONOPKO',
      posicion: 'medio',
      numero: '7',
      estado: 'titular'
    },
    {
      nombre: 'KARPIN',
      posicion: 'medio',
      numero: '8',
      estado: 'titular'
    },
    {
      nombre: 'TITOV',
      posicion: 'medio',
      numero: '9',
      estado: 'titular'
    },
    {
      nombre: 'BESCHASTNYKH',
      posicion: 'delantero',
      numero: '11',
      estado: 'titular'
    },
    {
      nombre: 'PIMENOV',
      posicion: 'delantero',
      numero: '19',
      estado: 'titular'
    },
    {
      nombre: 'IZMAYLOV',
      posicion: 'delantero',
      numero: '20',
      estado: 'titular'
    },
    {
      nombre: 'SMERTIN',
      posicion: 'portero',
      numero: '19',
      estado: 'suplente'
    },
    {
      nombre: 'MOSTOVOY',
      posicion: 'defensor',
      numero: '10',
      estado: 'suplente'
    },
    {
      nombre: 'CHERCHESOV',
      posicion: 'defensor',
      numero: '12',
      estado: 'suplente'
    },
    {
      nombre: 'DAEV',
      posicion: 'delantero',
      numero: '13',
      estado: 'suplente'
    },
    {
      nombre: 'CHIGAYNOV',
      posicion: 'delantero',
      numero: '14',
      estado: 'suplente'
    },
    {
      nombre: 'ALENICHEV',
      posicion: 'delantero',
      numero: '15',
      estado: 'suplente'
    }
  ];


  constructor(private route: ActivatedRoute, private router: Router, private location: Location) {
    this.route.params.subscribe( params => this.equipo1 = params['equipo1'] );
    this.route.params.subscribe( params => this.equipo2 = params['equipo2'] );
  }


  ngOnInit() {
    console.log('los eqipos son ' + this.equipo1 + ' y ' + this.equipo2);
  }

  public goBack() {
    this.location.back();
  }

  faseGrupos(): void {
    this.router.navigate(['partidos']);
  }
}