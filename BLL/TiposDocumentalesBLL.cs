using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TiposDocumentalesBLL
    {
        mTiposDocumentales TipManager = new mTiposDocumentales();
        public ByARpt Insert(tiposdocumentalesDto Reg)
        {
            return TipManager.Insert(Reg);
        }
        public ByARpt Update(tiposdocumentalesDto Reg)
        {
            return TipManager.Update(Reg);
        }
        public ByARpt Anular(tiposdocumentalesDto Reg)
        {
            return TipManager.Anular(Reg);
        }
        public List<tiposdocumentalesDto> Gets()
        {
            return TipManager.Gets();
        }
        public tiposdocumentalesDto Get(string idTipDocumentales)
        {
            return TipManager.Get(idTipDocumentales);
        }
    }
}
