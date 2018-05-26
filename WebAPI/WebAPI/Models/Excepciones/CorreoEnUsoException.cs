﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class CorreoEnUsoException : Exception
    {
        private readonly string _mensaje = "El correo ingresado ya existe.";
        private readonly int _codigoError = 10001;
        private int _usuarioId;
        private string _correoUsuario;
        private DateTime _fechaError;


        public CorreoEnUsoException(int usuarioId, string correoUsuario)
        {
            _usuarioId = usuarioId;
            _correoUsuario = correoUsuario;
            _fechaError = DateTime.Now;
        }

        public int usuarioId
        {
            get { return _usuarioId; }
        }

        public string correoUsuario
        {
            get { return _correoUsuario; }
        }

        public DateTime fechaError
        {
            get { return _fechaError; }
        }

        public new string Message
        {
            get { return _mensaje; }
        }
        
        public int codigoError
        {
            get { return _codigoError; }
        }

    }
}