using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class CochesController : ApiController
    {
        // GET: api/Coches
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //public IEnumerable<Coche> Get()
        public RespuestaAPI<Coche> Get()
        {
            RespuestaAPI<Coche> resultado = new RespuestaAPI<Coche>();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenado();
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }
            
            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;
        }

        // GET: api/Coches/5
        public RespuestaAPI<Coche> Get(long id)
        {
            RespuestaAPI<Coche> resultado = new RespuestaAPI<Coche>();
            List<Coche> data = new List<Coche>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenadoPorId(id);
                    resultado.error = "";
                }
            }
            catch (Exception)
            {
                resultado.error = "Error";
            }

            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;
        }

        // POST: api/Coches
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Coches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coches/5
        public void Delete(int id)
        {
        }
    }
}
