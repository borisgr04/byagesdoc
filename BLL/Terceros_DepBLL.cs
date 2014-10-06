using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Terceros_DepBLL
    {
        mTerceros_Dep TManager = new mTerceros_Dep();
        public ByARpt Insert(List<terceros_depDto> Reg)
        {
            return TManager.Insert(Reg);
        }
        public ByARpt Update(List<terceros_depDto> Reg)
        {
            return TManager.Update(Reg);
        }
        public List<string> Gets(string IdTercero)
        {
            return TManager.Gets(IdTercero);
        }
    }
}
