using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class MarcasController : ApiController
    {
        // GET: api/Marcas
        public RespuestaAPI<Marca> Get()
        {
            RespuestaAPI<Marca> resultado = new RespuestaAPI<Marca>();
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaMarcas = Db.DameListaDeMarcas();
                    resultado.totalElementos = listaMarcas.Count; 
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se produjo un error";
            }
            resultado.data = listaMarcas; 
            return resultado;
        }

        // GET: api/Marcas/5
        public RespuestaAPI<Marca> Get(long id)
        {
            RespuestaAPI<Marca> resultado = new RespuestaAPI<Marca>();
            List<Marca> marcas = new List<Marca>();

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    marcas = Db.DameMarca(id);
                    resultado.totalElementos = marcas.Count(); 
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se produjo un error";
            }
            resultado.data = marcas;
            return resultado;
        }

        // POST: api/Marcas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Marcas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marcas/5
        public void Delete(int id)
        {
        }
    }
}
