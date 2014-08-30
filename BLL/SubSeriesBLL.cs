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
        //public ByARpt Insert( Reg)
        //{
        //    return SManager.Insert(Reg);
        //}
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
