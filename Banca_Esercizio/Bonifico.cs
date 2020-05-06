using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class Bonifico : Movimento
    {
        public string Destinatario { get; set;}
        /// <summary>
        /// Costruttore della classe bonifico
        /// </summary>
        /// <param name="Destinatario">Destinatario del bonifico</param>
        /// <param name="importo">Importo del bonifico</param>
        /// <param name="id">Id univoco del bonifico</param>
        /// <param name="DataMovimento">Data del bonifico</param>
        public Bonifico(string Destinatario, double importo, string id, DateTime DataMovimento): base (importo,id,DataMovimento) 
        {
            this.Destinatario = Destinatario;     
        }
    }
}