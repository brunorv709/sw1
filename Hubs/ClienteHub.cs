using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wSoftware1.Hubs
{
    public class ClienteHub : Hub
    {
        public void ObtenerJsonActual()
        {
            try
            {
                Business.Bitacora oBitacora = new Business.Bitacora();
                var eBitacora = oBitacora.GetLast();

                Clients.All.SendAsync("JsonActual", eBitacora.contenido, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void EnviarCambio(string pJson, string nombre_usuario)
        {
            try
            {
                Models.Bitacora eBitacora = new Models.Bitacora();
                eBitacora.fecha = DateTime.Now;
                eBitacora.contenido = pJson;
                eBitacora.usuario = nombre_usuario;

                new Business.Bitacora().Save(eBitacora);
                Clients.Others.SendAsync("JsonActual", pJson, nombre_usuario);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
