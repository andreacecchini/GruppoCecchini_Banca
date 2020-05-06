using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class Banca
    {
        public string Nome { get; set; } 
        public string Indirizzo { get; set; }

        private List<ContoCorrente> listaConti; // Lista che contiene tutti i conti correnti
       
        public List<ContoCorrente> ListaConti
        {
            get => listaConti;
        }
        /// <summary>
        /// Costruttore di banca
        /// </summary>
        /// <param name="Nome">nome banca</param>
        /// <param name="Indirizzo">Indirizzo banca</param>
        public Banca(string Nome, string Indirizzo)
        {
            this.Nome = Nome;
            this.Indirizzo = Indirizzo;
            listaConti = new List<ContoCorrente>();
            
        }
        /// <summary>
        /// Metodo che aggiunge un conto alla lista di conti
        /// </summary>
        /// <param name="c">Conto corrente</param>
         public void aggiungiConto(ContoCorrente c)
         {
            listaConti.Add(c);
         }
         
        /// <summary>
        /// Metodo che permette la ricerca di un determinato conto corrente tramite il suo IBAN
        /// </summary>
        /// <param name="IBAN">Iban del conto corrente da cercare</param>
        /// <returns></returns>
         public ContoCorrente CercaConto(string IBAN)
         {
           foreach(ContoCorrente c in ListaConti)
           {
                if (c.Iban == IBAN)
                        return c;
           }
            return null;
         }

        
       
    }
}
