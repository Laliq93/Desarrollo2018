﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoFinalizarApuestasCantidad : Comando
    {

        DAOApuestaCantidad _dao;

        public ComandoFinalizarApuestasCantidad()
        {
            _dao = FabricaDAO.CrearDAOApuestaCantidad();
        }

        public override void Ejecutar()
        {
            _dao.FinalizarApuestas();
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