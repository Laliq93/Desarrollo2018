﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class AlineacionMasDeUnCapitanException : ExcepcionPersonalizada
    {
        public AlineacionMasDeUnCapitanException(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}