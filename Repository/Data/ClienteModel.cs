﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }

    }
}
