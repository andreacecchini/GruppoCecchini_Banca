using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class Persona
    {
        private string nome;
        private string cognome;
        public string LuogoNascita { get; set; }
        public DateTime DataNascita { get; set; }
        public string Cf { get; set; }
        /// <summary>
        /// Property riguardante il nome-cognom dell'oggetto corrente;
        /// </summary>
        public string Nome
        {
            get => nome + " " + cognome; //get di Nome
       
        }
        /// <summary>
        /// Metodo che permette di cambiare nome alla determinata persona in seguito ad un errore di digitazione;
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        public void CambiaNome(string nome,string cognome)
        { 
            this.nome = nome;          //set di nome e cognome
            this.cognome = cognome;
        }
        /// <summary>
        /// Costruttore della classe persona
        /// </summary>
        /// <param name="nome">Nome della persona</param>
        /// <param name="cognome">Cognome della persona</param>
        /// <param name="LuogoNascita">Luogo di nascita</param>
        /// <param name="DataNascita">Data di nascita</param>
        /// <param name="Cf">Codice fiscale</param>
        public Persona(string nome, string cognome, string LuogoNascita,DateTime DataNascita,string Cf)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.LuogoNascita = LuogoNascita;
            this.DataNascita = DataNascita;
            this.Cf = Cf;
        }
    }
}