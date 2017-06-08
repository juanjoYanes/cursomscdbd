using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class TipoCombustiblesController : ApiController
    {
        // GET: api/TipoCombustibles
        public RespuestaAPI<TipoCombustible> Get()
        {
            RespuestaAPI<TipoCombustible> resultados = new RespuestaAPI<TipoCombustible>();
            List<TipoCombustible> tiposCombustible = new List<TipoCombustible>();

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    tiposCombustible = Db.DameTiposCombustible();
                    resultados.totalElementos = tiposCombustible.Count();
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultados.error = "Se ha producido un error";                
            }
            resultados.data = tiposCombustible;
            return resultados; 
        }

        // GET: api/TipoCombustibles/5
        public RespuestaAPI<TipoCombustible> Get(long id)
        {
            RespuestaAPI<TipoCombustible> resultados = new RespuestaAPI<TipoCombustible>();
            List<TipoCombustible> combustibles = new List<TipoCombustible>();

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    combustibles = Db.DameTipoCombustible(id);
                    resultados.totalElementos = combustibles.Count();
                }
            }
            catch (Exception)
            {
                resultados.error = "Se ha producido un error";
            }

            resultados.data = combustibles;
            return resultados;
        }

        // POST: api/TipoCombustibles
        [HttpPost]
        public IHttpActionResult Post([FromBody] TipoCombustible tipoCombustible)
        {
            RespuestaAPI<TipoCombustible> respuesta = new RespuestaAPI<TipoCombustible>();
            respuesta.error = "";
            int filasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoCombustible(tipoCombustible);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception e)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al agregar el tipo de combustible";
            }
            return Ok(respuesta);
        }

        // PUT: api/TipoCombustibles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoCombustibles/5
        public void Delete(int id)
        {
        }
    }
}
