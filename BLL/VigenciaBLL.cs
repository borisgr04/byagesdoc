using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VigenciaBLL
    {
        mVigencia VManager = new mVigencia();
        public ByARpt Insert(VigenciaDto Reg)
        {
            return VManager.Insert(Reg);
        }
        public ByARpt Update(VigenciaDto Reg)
        {
            return VManager.Update(Reg);
        }
        public ByARpt Anular(VigenciaDto Reg)
        {
            return VManager.Anular(Reg);
        }
        public List<VigenciaDto> Gets()
        {
            return VManager.Gets();
        }
        public VigenciaDto Gets(string IdVigencia)
        {
            return VManager.Gets(IdVigencia);
        }
    }
}
