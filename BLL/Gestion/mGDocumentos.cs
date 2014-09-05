using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AutoMapper;
using ByA;

namespace BLL.Gestion
{
    class mGDocumentos
    {
        public trdEntities ctx { get; set; }

        public mGDocumentos()
         {

             Mapper.CreateMap<gdocumentosDto, gdocumentos>();
             Mapper.CreateMap<gdocumentos, gdocumentosDto>();

         }

        public ByARpt Insert(gdocumentosDto Reg)
        {
            cmdInsert o = new cmdInsert();
            o.oDto = Reg;
            return o.Enviar();
        }

        //public ByARpt Update(fc_tercerosDto Reg)
        //  {
        //      cmdUpdate o = new cmdUpdate();
        //      o.oDto = Reg;
        //      return o.Enviar();
        //  }

        class cmdInsert : absTemplate
        {
            public gdocumentosDto oDto { get; set; }
            gdocumentos Dto { get; set; }
        
            #region ImplementaciónMetodosAbstractos
            protected internal override bool esValido()
            {
                return true;
            }
            protected internal override void Antes()
            {
                Dto = new gdocumentos();
                

                Mapper.Map(oDto, Dto);
                int id;
                try
                {
                    id = ctx.gdocumentos.Select(t => t.idGDocumentos).Max() + 1;
                }
                catch (Exception)
                {

                    id = 1;
                }

                Dto.idGDocumentos = id;
                
                gddocumentos docByte = new gddocumentos();
                docByte.documento=oDto.documento;
                Dto.gddocumentos = docByte;
                
                ctx.gdocumentos.Add(Dto);
                byaRpt.id = Dto.idGDocumentos.ToString();
            }
            #endregion
        }


        //class cmdUpdate: absTemplate
        //{
        //    public fc_tercerosDto oDto { get; set; }
        //    fc_terceros Dto { get; set; }

        //    #region ImplementaciónMetodosAbstractos
        //    protected internal override bool esValido()
        //    {
        //        Dto = ctx.fc_terceros.Find(oDto.terceroId);
        //        if (Dto != null) return true;
        //        else
        //        {
        //            byaRpt.Mensaje = "No se encuentra el tercero con ese número de identificación";
        //            byaRpt.Error = true;
        //            return false;
        //        }
        //    }

        //    protected internal override void Antes()
        //    {
        //        Dto.correo = oDto.correo;
        //        Dto.direccion = oDto.direccion;
        //        Dto.nombre = oDto.nombre;
        //        Dto.telefono = oDto.telefono;
        //        Dto.tipodoc = oDto.tipodoc;
        //        Dto.tipoper = oDto.tipoper;

        //        byaRpt.id = Dto.terceroId.ToString();
        //    }
        //    #endregion
        //}
    }
}
