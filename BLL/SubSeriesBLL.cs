using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SubSeriesBLL
    {
        mSubSeries SubManager = new mSubSeries();
        public ByARpt Insert(subseriesDto Reg)
        {
            return SubManager.Insert(Reg);
        }
        public ByARpt Update(subseriesDto Reg)
        {
            return SubManager.Update(Reg);
        }
        public ByARpt Anular(subseriesDto Reg)
        {
            return SubManager.Anular(Reg);
        }
        public List<subseriesDto> Gets()
        {
            return SubManager.Gets();
        }
        public subseriesDto Get(string subserieId)
        {
            return SubManager.Get(subserieId);
        }
    
    }
}
