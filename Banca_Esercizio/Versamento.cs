using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class Versamento : Movimento
    {
        public Versamento(double importo,string id,DateTime DataMovimento) : base(importo, id, DataMovimento)
        {
          
        }
            
    }
}