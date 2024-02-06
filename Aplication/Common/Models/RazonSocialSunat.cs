using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Common.Models
{
    public class RazonSocialSunat
    {
        public bool esHabido { get; set; }
        public bool esActivo { get; set; }
        public int ddp_secuen { get; set; }
        public string ddp_nombre { get; set; }
        public string ddp_numruc { get; set; }
    }
}