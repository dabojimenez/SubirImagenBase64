using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubirImagenBase64.Models;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace SubirImagenBase64.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        [HttpPost]
        public IActionResult SubirImagen(SubirImagen subirImagen)
        {
            string mensaje = string.Empty;
            try
            {
                string path = @"Subir/" + subirImagen.origen + "/" + subirImagen.nombrecarpeta + "/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                byte[] bytBase64 = Convert.FromBase64String(subirImagen.imagenbase);
                path = path + subirImagen.nombreimagen + ".png";

                StreamWriter SW = new StreamWriter(path);
                SW.BaseStream.Write(bytBase64, 0, bytBase64.Length - 1);
                SW.Close();
                mensaje = "Exito";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return Ok(mensaje);
        }

    }

}
