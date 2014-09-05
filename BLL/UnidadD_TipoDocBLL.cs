using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public  class UnidadD_TipoDocBLL
    {
       mUnidadD_TipoDoc UniManager = new mUnidadD_TipoDoc();
       public ByARpt Insert(UnidadD_TipoDocDto Reg)
        {
            return UniManager.Insert(Reg);
        }
        public ByARpt Update(UnidadD_TipoDocDto Reg)
        {
            return UniManager.Update(Reg);
        }
        public ByARpt Anular(UnidadD_TipoDocDto Reg)
        {
            return UniManager.Anular(Reg);
        }
        public List<UnidadD_TipoDocDto> Gets()
        {
            return UniManager.Gets();
        }
        public UnidadD_TipoDocDto Get(string idUnidad)
        {
            return UniManager.Get(idUnidad);
        }

    }
}
