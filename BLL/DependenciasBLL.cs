using BLL.Gestion;
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
        //public ByARpt Insert( Reg)
        //{
        //    return SManager.Insert(Reg);
        //}
        public List<dependenciasDto> Gets()
        {
            return DepManager.Gets();
        }
        public dependenciasDto Get(string dependencias)
        {
            return DepManager.Gets(dependencias);
        }
    }
}
