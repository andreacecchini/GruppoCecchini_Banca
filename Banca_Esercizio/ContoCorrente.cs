using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class ContoCorrente
    {
        protected Persona intestatario;  // Intestatario del conto
        protected  int nMovimenti; // Numero di movimenti del conto corrente 
        protected int maxMovimenti; // Numero di movimenti massimi del conto corrente senza pagare una percentuale
        protected double saldo; // Saldo nei movimenti del conto corrente
        protected  string iban; // Iban del conto corrente
        protected List<Movimento> movimenti; // Lista che contine l'infomazioni di qualsiasi movimento del conto corrente
        protected double  costoMovimento;
        protected double costoBonifico;
        /// <summary>
        ///  Property riguardante l'attributo saldo;
        /// </summary>
        public double Saldo
        {
            get => saldo; // get di saldo
        }
        public Persona Intestatario
        {
            get => intestatario; // get di intestario
        }

        /// <summary>
        ///  Property riguardante l'attributo iban;
        /// </summary>
        public string Iban
        {
            get => iban; // get di iban
        }

        /// <summary>
        ///  Property riguardante la lista di movimenti;
        /// </summary>
        public List<Movimento> Movimenti
        {
            get => movimenti; // get di movimenti
        }

        /// <summary>
        ///  Property riguardante l'attributo costoMovimento;
        /// </summary>
        public double CostoMovimento
        {
            get => costoMovimento;
            set => costoMovimento = value;
        }

        /// <summary>
        /// Property riguardante l'attributo costoBonifico;
        /// </summary>
        public double CostoBonifico
        {
            get => costoBonifico;
            set => costoBonifico = value;
        }

        /// <summary>
        /// Costruttore di conto corrente
        /// </summary>
        /// <param name="intestatario">Instestatario del conto</param>
        /// <param name="IBAN">Iban dell' intestatario</param>
        public ContoCorrente(Persona intestatario, string IBAN)
        {
            this.intestatario = intestatario;
            this.iban = IBAN;
            saldo = 0;
            nMovimenti = 0;
            maxMovimenti = 50;
            movimenti = new List<Movimento>();
            CostoMovimento = 0.5;
            
        }
        /// <summary>
        /// Metodo che effettua un prelievo
        /// </summary>
        /// <param name="x">Valore del prelievo</param>
        /// <returns></returns>
        public bool Preleva(double x)
        {
            if (MovimentoGratuito())  //controlla la funzione MetodoGratuito che restistuisce un bool
            {
                if (saldo >= x)
                {
                    saldo -= x;
                    movimenti.Add(new Prelievo(x, "ASDASXZZ", DateTime.Now));
                    nMovimenti++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (saldo >= x + CostoMovimento)
                {
                    saldo -= x - CostoMovimento;
                    movimenti.Add(new Prelievo(x, "ASDASXZZ", DateTime.Now));
                    nMovimenti++; 
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Metodo che versa soldi all' interno del conto corrente
        /// </summary>
        /// <param name="x"></param>
        public void Versa(double x)
        {
            if (MovimentoGratuito())  //controlla il metodo MovimentoGratuito che restituisce un bool
            {
                saldo += x;
                movimenti.Add(new Versamento(x, "SCSCSASZX", DateTime.Now));
            }
            else
            {
                saldo = ((saldo - x) - CostoBonifico);
            }
            nMovimenti++;

        }
        
        /// <summary>
        /// Metodo che permette di effettuare un bonifico
        /// </summary>
        /// <param name="d">Conto corrente destinatario</param>
        /// <param name="x">Importo del  bonifico</param>
        /// <returns>True se il movimento ha avuto successo, false se non ha avuto successo</returns>
        public bool Bonifico(String d, double x)
        {
            CostoBonifico=x*0.1;
            if (MovimentoGratuito()) //controlla il metodo MovimentoGratuito che restituisce un bool
            {
                if (saldo >= x+CostoBonifico)
                {
                    saldo -= x-CostoBonifico;
                    movimenti.Add(new Bonifico(d, x, "LKASXASAS", DateTime.Now));
                    nMovimenti++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (saldo >= x + CostoBonifico+CostoMovimento)
                {
                    saldo = (((saldo- x) - CostoBonifico )- CostoMovimento);
                    movimenti.Add(new Bonifico(d, x, "LKASXASAS", DateTime.Now));
                    nMovimenti++;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Metodo che controlla la possibilità di effettuare un movimento in modalità gratuita oppure no.
        /// </summary>
        /// <returns>True se il movimento è gratuito- false il contrario<returns>
        protected bool MovimentoGratuito()
        {
            if (nMovimenti < maxMovimenti)
                return true;
            else
                return false;
        }
       
    }
}