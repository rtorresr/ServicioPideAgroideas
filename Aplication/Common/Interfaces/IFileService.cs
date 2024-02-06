using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        public Task Subir(IFormFile Archivo, string Ruta, string Nombre = null);
        public Task<byte[]> ObtenerBinary(string Ruta);
        public Task GuardarBinary(byte[] Archivo, string Ruta, string Nombre);
        public Task Mover(string Origen, string Destino);
    }
}
