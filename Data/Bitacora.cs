using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wSoftware1.Data;

namespace wSoftware1.Business
{
    public class Bitacora : Base
    {
        public Models.Bitacora GetLast()
        {
            try
            {
                string sQuery = @"
                    SELECT *
                    FROM bitacora
                    ORDER BY 1 desc
                ";
                var eBitacora = this._DBcontext.Database.GetDbConnection().Query<Models.Bitacora>(sQuery).FirstOrDefault();
                if (eBitacora == null)
                    eBitacora = new Models.Bitacora();

                return eBitacora;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Save(Models.Bitacora eBitacora) 
        {
            try
            {
                this._DBcontext.Bitacora.Add(eBitacora);
                this._DBcontext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
