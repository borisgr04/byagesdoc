using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class subseriesDto
    {

        // public subseries()
        //{
        //    this.tiposdocumentales = new HashSet<tiposdocumentales>();
        //}
    
        public string idSubSeries { get; set; }
        public string SubSerie { get; set; }
        public Nullable<int> RetencionAG { get; set; }
        public Nullable<int> RetencionAC { get; set; }
        public Nullable<bool> DisposicionCT { get; set; }
        public Nullable<bool> DisposicionE { get; set; }
        public Nullable<bool> DisposicionMD { get; set; }
        public Nullable<bool> DisposicionS { get; set; }
        public string Series_idSerie { get; set; }
        public string Serie { get; set; }
    
        //public virtual series series { get; set; }
        //public virtual ICollection<tiposdocumentales> tiposdocumentales { get; set; }
    }
}
