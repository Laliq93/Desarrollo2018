﻿using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Presentacion.Controllers;
using NUnit.Framework;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace PruebasCopaMundialAPI.Modulo_7
{
    [TestFixture]
    public class PruebasLogroEquipo
    {


        private DAO dao;
        private Comando comando;
        private Entidad respuesta;
        private List<Entidad> _respuestas;
        private LogrosController controller;

        [SetUp]
        public void SetUp()
        {
            dao = FabricaDAO.CrearDAOLogroEquipo();
            dao.Conectar();
            controller = new LogrosController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

        }


        /// <summary>
        /// Metodo que prueba el resultado de exito
        /// del dao de Agregar logroEquipo
        /// </summary>
        [Test]
        public void PruebaDaoLogroEquipoAgregar()
        {

            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar por 1
            logro.IdTipo = TipoLogro.equipo;
            logro.Logro = "Logro equipo Prueba Agregar";


            ((DAOLogroEquipo)dao).Agregar(logro);
            respuesta = FabricaEntidades.CrearLogroEquipo();

            respuesta = ((DAOLogroEquipo)dao).ObtenerLogroPorId(logro);

            Assert.IsNotNull(respuesta);
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando logroEquipoAgregar
        /// </summary>
        [Test]
        public void PruebaComandoLogroEquipoAgregar() 
        {
            
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            Partido partido = FabricaEntidades.CrearPartido();

            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar a 1
            logro.IdTipo = TipoLogro.equipo;
            logro.Logro = "Logro equipo Prueba Comando agregar";

            comando = FabricaComando.CrearComandoAgregarLogroEquipo(logro);
            comando.Ejecutar();
            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de una entidad 
        /// a un dtoLogroEquipo
        /// </summary>
        [Test]
        public void PruebaTraductorLogroEquipoDto()
        {
            TraductorLogroEquipo traductor = FabricaTraductor.CrearTraductorLogroEquipo();
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            DTOLogroEquipo dtoLogro = FabricaDTO.CrearDTOLogroEquipo();

            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 1;
            logro.IdTipo = TipoLogro.equipo;
            logro.Logro = "Logro equipo Prueba Traductor";

            dtoLogro = traductor.CrearDto(logro);

            Assert.AreEqual(1, dtoLogro.IdPartido);
            
        }

        /// <summary>
        /// Metodo que prueba la traduccion de un dtoLogroEquipo
        /// a una entidad logroEquipo
        /// </summary>
        [Test]
        public void PruebaTraductorLogroEquipoEntidad()
        {
           TraductorLogroEquipo traductor = FabricaTraductor.CrearTraductorLogroEquipo();
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            DTOLogroEquipo dtoLogro = FabricaDTO.CrearDTOLogroEquipo();

            dtoLogro.IdPartido = 1;
            dtoLogro.LogroEquipo = "Prueba de dto a entidad logro equipo";
            dtoLogro.TipoLogro = (int)TipoLogro.equipo;

            logro = (LogroEquipo)traductor.CrearEntidad(dtoLogro);

            Assert.AreEqual(1, logro.Partido.Id);

        }

        /// <summary>
        /// Metodo que prueba la respuesta exitosa de
        ///del metodo agregarLogroEquipo del 
        ///LogroCotroller
        /// </summary>
        [Test]
        public void PruebaControllerAgregarLogroEquipo()
        {
            DTOLogroEquipo dtoLogro = FabricaDTO.CrearDTOLogroEquipo();
            dtoLogro.IdPartido = 14; //cambiar a 1
            dtoLogro.LogroEquipo = "Prueba controller Agregar logro equipo";
            dtoLogro.TipoLogro = (int)TipoLogro.equipo;

            Assert.AreEqual(HttpStatusCode.OK, controller.AgregarLogroEquipo(dtoLogro).StatusCode);
            
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito 
        /// del dao ObtenerLogrosPendientes
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosEquipoPendientes()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 14; //cambiar por 1

            _respuestas = ((DAOLogroEquipo)dao).ObtenerLogrosPendientes(partido);
            Assert.IsNotNull(_respuestas);
        }


        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException
        /// en el Dao
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosEquipoPendientesException()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 18; //cambiar numero

            Assert.Throws<LogrosPendientesNoExisteException>(() => ((DAOLogroEquipo)dao).ObtenerLogrosPendientes(partido));
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando ObtenerLogrosEquipoPendientes
        /// </summary>
        [Test]
        public void PruebaComandoObtenerLogrosEquipoPendientes()
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.Id = 14; //cambiar a 1

            comando = FabricaComando.CrearComandoObtenerLogrosEquipoPendientes(partido);
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.AreNotEqual(0, _respuestas.Count);

        }

        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException en el
        /// comando
        /// </summary>
        [Test]
        public void PruebaCmdObtenerLogrosEquipoPendientesException()
        {
            
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 18; //cambiar numero

            comando = FabricaComando.CrearComandoObtenerLogrosEquipoPendientes(partido);
            Assert.Throws<LogrosPendientesNoExisteException>(() => comando.Ejecutar());
            
        }



        /// <summary>
        /// Metodo que prueba la respuesta exitosa del
        /// metodo ObtenerLogrosEquipoPendiente del 
        /// LogroController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosEquipoPendiente()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 14;//Cambiar

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerLogrosEquipoPendientes(dtoLogroPartidoId).StatusCode);

        }


        /// <summary>
        /// Metodo que prueba la excepcion Logros
        /// pendientes not found exception del metodo 
        /// ObtenerLogrosEquipoPendientes de
        /// LogrosController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosEquipoPendienteExc()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 18;//Cambiar
            Assert.AreEqual(HttpStatusCode.InternalServerError, controller.ObtenerLogrosEquipoPendientes(dtoLogroPartidoId).StatusCode);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito de
        // ObtenerLogroPorId de DaoLogroEquipo
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogroPorId()
        {
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            logro.Id = 9;//asegurar que este id sea de tipo equipo
            respuesta = ((DAOLogroEquipo)dao).ObtenerLogroPorId(logro);
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba el resultado exitoso 
        /// de AsignarResultadoLogro de DaoLogroEquipo
        /// </summary>
        [Test]
        public void PruebaDaoAsignarResultadoLogro()
        {

            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            logro.Id = 45;
            logro.Equipo.Id = 3;
            ((DAOLogroEquipo)dao).AsignarResultadoLogro(logro);

            respuesta = ((DAOLogroEquipo)dao).ObtenerLogroPorId(logro);

            Assert.AreEqual(3, ((LogroEquipo)respuesta).Equipo.Id);
        }


        /// <summary>
        /// Metodo que prueba el resultado de exito del comando
        /// AsignarResultadoLogroEquipo 
        /// </summary>
        [Test]
        public void PruebaCmdAsignarResultadoLogroEquipo()
        {

            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            logro.Id = 46;//cambiar
            logro.Equipo.Id = 8;

            comando = FabricaComando.CrearComandoAsignarResultadoLogroEquipo(logro);
            comando.Ejecutar();

            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del
        /// ObtenerLogrosEquipoResultados del dao
        /// DaoLogroEquipo
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosEquipoResultados()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 14; //cambiar por 1

            _respuestas = ((DAOLogroEquipo)dao).ObtenerLogrosResultados(partido);
            Assert.IsNotNull(_respuestas);
        }

        /// <summary>
        /// Metodo que prueba la excepcion LogroFinalizadosNoExisteException
        /// del metodo ObtenerLogrosEquipoResultados de DaoLogroEquipo
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosEquipoResultadosExc()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 11; //cambiar numero 
            Assert.Throws<LogrosFinalizadosNoExisteException>(() => ((DAOLogroEquipo)dao).ObtenerLogrosResultados(partido));
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando ObtenerLogrosEquipoResultado
        /// </summary>
        [Test]
        public void PruebaComandoObtenerLogrosEquipoResultado()
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.Id = 14; //cambiar a 1

            comando = FabricaComando.CrearComandoObtenerLogrosEquipoResultados(partido);
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.AreNotEqual(0, _respuestas.Count);

        }



        [Test]
        public void PruebaTraductorLogroEquipoResultadoDto()
        {
            TraductorLogroEquipoResultado traductor = FabricaTraductor.CrearTraductorLogroEquipoResultado();
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            DTOLogroEquipoResultado dtoLogro = FabricaDTO.CrearDTOLogroEquipoResultado();

            logro.Id = 1;
            logro.IdTipo = TipoLogro.cantidad;
            logro.Logro = "Logro Prueba Traductor";
            logro.Equipo.Id = 2;

            dtoLogro = traductor.CrearDto(logro);

            Assert.AreEqual(2, dtoLogro.Equipo);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de un dtoLogroEquipo
        /// a una entidad logroCantidad
        /// </summary>
        [Test]
        public void PruebaTraductorLogroEquipoResultadoEntidad()
        {
            TraductorLogroEquipoResultado traductor = FabricaTraductor.CrearTraductorLogroEquipoResultado();
            LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();
            DTOLogroEquipoResultado dtoLogro = FabricaDTO.CrearDTOLogroEquipoResultado();

            dtoLogro.IdLogroEquipo = 1;
            dtoLogro.LogroEquipo = "Prueba de dto a entidad";
            dtoLogro.TipoLogro = (int)TipoLogro.equipo;
            dtoLogro.Equipo = 6;

            logro = (LogroEquipo)traductor.CrearEntidad(dtoLogro);

            Assert.AreEqual(6, logro.Equipo.Id);

        }


        /// <summary>
        /// Metodo que prueba la respuesta exitosa del
        /// metodo ObtenerLogrosEquipoResultado del 
        /// LogroController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosEquipoResultado()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 14;//Cambiar

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerLogrosEquipoResultados(dtoLogroPartidoId).StatusCode);

        }


        /// <summary>
        /// Metodo que prueba la excepcion Logros
        /// pendientes not found exception del metodo 
        /// ObtenerLogrosEquipoResultados de
        /// LogrosController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosEquipoResultadosExc()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 18;//Cambiar
            Assert.AreEqual(HttpStatusCode.InternalServerError, controller.ObtenerLogrosEquipoResultados(dtoLogroPartidoId).StatusCode);

        }


        [TearDown]
        public void TearDown()
        {
            dao.Desconectar();
            dao = null;
            comando = null;
            respuesta = null;
            _respuestas = null;

        }
    }
}
