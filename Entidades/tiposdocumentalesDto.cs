using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class tiposdocumentalesDto
    {
        public string idTipDocumentales { get; set; }
        public string Nombe { get; set; }
        public string TD_Original { get; set; }
        public string TD_Copia { get; set; }
        public string Nombre_Sub { get; set; }
        public string SubSerieId { get; set; }

        //public virtual subseries subseries { get; set; }
    }
}
