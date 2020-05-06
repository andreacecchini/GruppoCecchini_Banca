using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class Movimento
    {
        protected DateTime dataMovimento; // Data in cui viene registrato il movimneto
        protected double importo; // Importo usato nel movimento
        protected string id; // Identificativo dle movimento
        /// <summary>
        /// Property riguardante l'attributo dataMovimento;
        /// </summary>
        public DateTime DataMovimento
        {
            get => dataMovimento;
        }
        /// <summary>
        ///  Property riguardante l'attributo Importo;
        /// </summary>
        public double Importo
        {
            get => importo;
        }
        /// <summary>
        ///  Property riguardante l'attributo Id;
        /// </summary>
        public string Id
        {
            get => id;
        }
        
        /// <summary>
        /// Costruttore di movimento
        /// </summary>
        /// <param name="Importo">Importo</param>
        /// <param name="Id">id del movimento</param>
        /// <param name="DataMovimento">Data del movimento</param>
        public Movimento(double importo,string id, DateTime dataMovimento)
        {
            this.dataMovimento = dataMovimento;
            this.importo = importo;
            this.id = id;
        }
    }
}