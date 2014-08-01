using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByA;
using Entidades;

namespace BLL
{
    public class EntidadBLL
    {
        public Entities ctx { get; set; }
        public ByARpt byaRpt { get; set; }

        public byte[] GetLogo()
        {
            using (ctx = new Entities())
            {
                byte[] logo = ctx.CTRL_ENTIDAD.Select(t => t.LOGO_RPT).Single();
                return logo;
            }
        }

    }
}
