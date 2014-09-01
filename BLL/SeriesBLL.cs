using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SeriesBLL
    {
        mSeries SManager = new mSeries();
        public ByARpt Insert(seriesDto Reg)
        {
            return SManager.Insert(Reg);
        }
        public ByARpt Update(seriesDto Reg)
        {
            return SManager.Update(Reg);
        }
        public ByARpt Anular(seriesDto Reg)
        {
            return SManager.Anular(Reg);
        }
        public List<seriesDto> Gets()
        {
            return SManager.Gets();
        }
        public seriesDto Gets(string IdSerie)
        {
            return SManager.Gets(IdSerie);
        }
    
    

    }
}
