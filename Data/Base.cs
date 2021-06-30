using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wSoftware1.Data
{
    public class Base
    {
        protected Data.ApplicationDbContext _DBcontext;
        private IDbContextTransaction _Current_Transaction;

        /// <summary>
        /// Constructor Generico para todas las clases de Negocio
        /// Inicia el DBcontext para Trabajar con Base de datos
        /// </summary>
        protected Base()
        {
            _DBcontext = Data.Factory.GetDbContext;
        }

        /// <summary>
        /// Retorna la Transaccion Actual para Trabajar con BD
        /// trabaja con el Factory para Iniciar la Transaccion o devolver la Actual
        /// </summary>
        /// <returns> Retorna un iDbContextTransaction </returns>
        protected Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction _GetTransaction()
        {
            return (this._Current_Transaction != null) ?
                      _Current_Transaction : _DBcontext.Database.BeginTransaction();
        }

    }
}
