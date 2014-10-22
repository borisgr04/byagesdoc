using BLL.Gestion;
using ByA;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DocumentosBLL
    {

        mDocumentos DocManager = new mDocumentos();
        //public ByARpt Insert( Reg)
        //{
        //    return SManager.Insert(Reg);
        //}
      
        public ByARpt Insert(unidaddocumentalDto Reg)
        {
            return DocManager.Insert(Reg);
        }
        public ByARpt Update(unidaddocumentalDto Reg)
        {
            return DocManager.Update(Reg);
        }
        public ByARpt Anular(unidaddocumentalDto Reg)
        {
            return DocManager.Anular(Reg);
        }
        public unidaddocumentalDto Get(string Codigo)
        {
            return DocManager.Get(Codigo);
        }
        public unidaddocumentalDto GetID(string id)
        {

            return DocManager.GetID(id);
        }
        public List<unidaddocumentalDto> Gets(unidaddocumentalDto Filtro)
        {
            return DocManager.Gets(Filtro);
         
        }
    }
}
