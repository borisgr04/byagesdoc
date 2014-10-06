using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DependenciasBLL
    {
        mDependencias DepManager = new mDependencias();
        public ByARpt Insert(dependenciasDto Reg)
        {
            return DepManager.Insert(Reg);
        }
        public ByARpt Update(dependenciasDto Reg)
        {
            return DepManager.Update(Reg);
        }
        public ByARpt Anular(dependenciasDto Reg)
        {
            return DepManager.Anular(Reg);
        }
        public List<dependenciasDto> Gets(string idTerceros)
        {
            return DepManager.Gets(idTerceros);
        }
        public dependenciasDto Get(string dependencias)
        {
            return DepManager.GetsT(dependencias);
        }
    }
}
