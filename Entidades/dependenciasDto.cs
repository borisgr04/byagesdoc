﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class dependenciasDto
    {
        public string idDependencia { get; set; }
        public string Dependencia { get; set; }
        public string Padre { get; set; }
        public string Nombre_Padre { get; set; }
    }
}
