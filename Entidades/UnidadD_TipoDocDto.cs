using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class UnidadD_TipoDocDto
    {
        public string IdUnidadDoc { get; set; }
        public string IdTipoDoc { get; set; }
        public string Codigo { get; set; }
        public string FechaDoc { get; set; }
        public string PagIni { get; set; }
        public string CantidadPag { get; set; }
        public string Descripcion { get; set; }

        //public virtual unidaddocumental unidaddocumental { get; set; }
        //public virtual tiposdocumentales tiposdocumentales { get; set; }
    }
}
