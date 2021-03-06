﻿using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    /// <summary>
    /// Comando que se encarga de actualizar la contraseña de un usuario
    /// </summary>
    public class ComandoActualizarPassword : Comando
    {
        private Comando _comando;

        public ComandoActualizarPassword(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {
            _comando = FabricaComando.CrearComandoVerificarClaveUsuario(Entidad);
            _comando.Ejecutar();

            DAOUsuario dao = FabricaDAO.CrearDAOUsuario();
            dao.EditarPassword(Entidad);
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