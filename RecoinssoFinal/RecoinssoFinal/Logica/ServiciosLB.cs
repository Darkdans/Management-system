﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoinssoFinal.Logica
{
    internal class ServiciosLB
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string costo { get; set; }
        public string descripcion { get; set; }
        public DateTime tiempo { get; set; }
        public byte[] Foto { get; set; }
        public int dias { get; set; }
    }
}