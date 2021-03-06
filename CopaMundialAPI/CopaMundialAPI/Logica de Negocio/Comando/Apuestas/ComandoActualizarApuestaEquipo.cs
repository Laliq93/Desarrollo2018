﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoActualizarApuestaEquipo: Comando
    {
        private Comando _comando;

        public ComandoActualizarApuestaEquipo(Entidad apuesta)
        {
            Entidad = apuesta;
        }

        public override void Ejecutar()
        {

            _comando = FabricaComando.CrearComandoVerificarApuestaEquipoValida(Entidad);

            _comando.Ejecutar();

            IDAOApuesta dao = FabricaDAO.CrearDAOApuestaEquipo();

            dao.Actualizar(Entidad);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}