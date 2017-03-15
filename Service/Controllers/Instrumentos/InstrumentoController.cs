using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Instrumentos;
using Common.Models.Instrumentos;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.IO;

namespace Service.Controllers.Instrumentos
{
    public class InstrumentoController : ApiController
    {
        public async Task<List<InstrumentoModel>> GetInstrumentos()
        {
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                return await business.GetInstrumentosAsync();
            }
        }

        [ResponseType(typeof(InstrumentoModel))]
        public async Task<IHttpActionResult> GetInstrumento(long id)
        {
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                InstrumentoModel instrumento = await business.GetInstrumentosAsync(id);

                if (instrumento==null)
                {
                    return NotFound();
                }
                return Ok(instrumento);
            }
        }

        [ResponseType(typeof(InstrumentoModel))]
        public async Task<IHttpActionResult> PutInstrumento(long id, InstrumentoModel instrumento)
        {
            if (!ModelState.IsValid)
            {
                var avisos = string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(avisos);
            }
            if (id != instrumento.Id)
            {
                return BadRequest();
            }
            if (!InstrumentoExists(id))
            {
                return NotFound();
            }
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                await business.PutInstrumentoAsync(instrumento);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
        }

        [ResponseType(typeof(InstrumentoModel))]
        public async Task<IHttpActionResult> PostInstrumento(InstrumentoModel instrumento)
        {
            if (!ModelState.IsValid)
            {
                var avisos = string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(avisos);
            }
            if (InstrumentoExists(instrumento.Id))
            {
                return Conflict();
            }
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                SaveFiles(instrumento);
                await business.PostInstrumentoAsync(instrumento);
                return CreatedAtRoute("DefaultApi", new { id=instrumento.Id }, instrumento);
            }
        }

        [ResponseType(typeof(InstrumentoModel))]
        public async Task<IHttpActionResult> DeleteInstrumento(long id)
        {   
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                InstrumentoModel instrumento = await business.GetInstrumentosAsync(id);
                if (instrumento==null)
                {
                    return NotFound();
                }
                await business.DeleteInstrumentoAsync(id);
                return Ok(instrumento);
            }
        }

        private static void SaveFiles(InstrumentoModel instrumento)
        {
            var pathService = HttpContext.Current.Request.MapPath("~");
            var imageFileName = instrumento.Imagem.Split('|')[0];
            var imageFileStringBase64 = instrumento.Imagem.Split(',')[1];
            var pathImageFile = pathService + "Imagens\\" + imageFileName;
            File.WriteAllBytes(pathImageFile, Convert.FromBase64String(imageFileStringBase64));
            instrumento.Imagem = imageFileName;
            
            var somFileName = instrumento.Som.Split('|')[0];
            var somFileStringBase64 = instrumento.Som.Split(',')[1];
            var pathSomFile = pathService + "Sons\\" + somFileName;
            File.WriteAllBytes(pathSomFile, Convert.FromBase64String(somFileStringBase64));
            instrumento.Som = somFileName;
        }

        private bool InstrumentoExists(long id)
        {
            using (var business = new InstrumentoBusiness(HttpContext.Current.Request.MapPath("~")))
            {
                return business.InstrumentoExists(id);
            }
        }
    }
}