using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class gdocumentosDto
    {
        public int idGDocumentos { get; set; }
        public string nombre { get; set; }
        public Nullable<int> longitud { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        
        public byte[] documento { get; set; }

        //public virtual gddocumentos gddocumentos { get; set; }
    }
}
