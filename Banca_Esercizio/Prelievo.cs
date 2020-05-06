using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{

    public class Prelievo : Movimento
    {
        /// <summary>
        /// Costruttore della classe prelievo
        /// </summary>
        /// <param name="importo">Importo dek prelievo</param>
        /// <param name="id">Id del prelievo</param>
        /// <param name="DataMovimento">Data del prelievo</param>
        public Prelievo( double importo, string id, DateTime DataMovimento) : base(importo, id, DataMovimento) 
        {
            //costruttore vuoto siccome tutti gli attributi derivati
        }
    }
}