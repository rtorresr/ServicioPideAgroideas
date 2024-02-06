using Application.Common.Models;
using Application.Common.Repositories.Seguridad;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Infrastructure.Repositories.Servicios
{
    public class SisgedRepository : ISisgedRepository
    {
        public Result GuardarArchivo(IFormFile archivo, string ruta)
        {
            if (archivo != null)
            {
                if (archivo.ContentType == "application/pdf")
                {
                    var filename = $"Adjunto-{DateTime.UtcNow.ToString("yyyyMMddHHssmm")}-{archivo.FileName}";

                    var path = "\\\\SISGED_IMAGENES\\SISGED_DocumentosDigitales\\Principal\\" + ruta;


                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var rutaReal = $"{path}\\{filename}";
                    using (Stream fileStream = new FileStream(rutaReal, FileMode.Create, FileAccess.Write))
                    {
                        archivo.CopyTo(fileStream);
                    }

                    if (!System.IO.File.Exists(rutaReal))
                    {
                        return new Result(false, "No se pudo guardar el archivo");
                    }

                    return new Result(true, filename);
                }

                return new Result(false, "Formato de Documento no es válido");
            }

            return new Result(false, "Archivo no adjuntado");
        }
    }
}
