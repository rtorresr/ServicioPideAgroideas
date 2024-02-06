using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {       
        public async Task Subir(IFormFile Archivo, string Ruta, string Nombre = null)
        {
            if (Archivo == null)
                throw new Exception("Falta el archivo");

            if (!Directory.Exists(Ruta))
                Directory.CreateDirectory(Ruta);

            string filePath = Path.Combine(Ruta, Nombre == null ? Archivo.FileName : Nombre);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await Archivo.CopyToAsync(fileStream);
            }

            await Task.CompletedTask;
        }

        public async Task<byte[]> ObtenerBinary(string Ruta)
        {
            if(string.IsNullOrEmpty(Ruta))
                throw new Exception("Ruta no especificada.");

            byte[] fileBytes = await File.ReadAllBytesAsync(Ruta);

            if (fileBytes.Length == 0)
                throw new Exception("No se ha podido recuperar el archivo.");

            return fileBytes;
        }

        public async Task GuardarBinary(byte[] Archivo, string Ruta, string Nombre)
        {
            if (Archivo == null)
                throw new Exception("Falta el archivo");

            if (!Directory.Exists(Ruta))
                Directory.CreateDirectory(Ruta);

            string filePath = Path.Combine(Ruta, Nombre);

            await File.WriteAllBytesAsync(filePath, Archivo);

            await Task.CompletedTask;
        }

        public async Task Mover(string Origen, string Destino)
        {
            File.Replace(Origen, Destino, null);

            await Task.CompletedTask;
        }
    }
}
