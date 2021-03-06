﻿using CopaMundialAPI.Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOAlineacion: IDAO
    {
        List<Entidad> ConsultarPorPartido(Entidad entidad);

        Entidad ConsultarCapitanPorPartidoYEquipo(Entidad entidad);

        List<Entidad> ConsultarTitularesPorPartidoYEquipo(Entidad entidad);
    }
}