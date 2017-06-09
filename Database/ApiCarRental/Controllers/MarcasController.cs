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
        [HttpPost]
        public IHttpActionResult Post([FromBody] Marca marca)
        {
            RespuestaAPI<Marca> respuesta = new RespuestaAPI<Marca>();
            respuesta.error = "";
            int filasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarMarca(marca);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al agregar la marca";
            }
            return Ok(respuesta);
        }

        // PUT: api/Marcas/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]Marca marca)
        {
            RespuestaAPI<Marca> respuesta = new RespuestaAPI<Marca>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.ActualizaMarca(id, marca);
                    
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error";
            }
            return Ok(respuesta);
        }

        // DELETE: api/Marcas/5
        [HttpDelete]
        public IHttpActionResult Del(long id)
        {
            RespuestaAPI<Marca> respuesta = new RespuestaAPI<Marca>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.BorrarMarca(id);
                    
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al eliminar la Marca";
            }
            return Ok(respuesta);
        }
    }
}
