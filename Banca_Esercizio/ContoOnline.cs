using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca_Esercizio
{
    public class ContoOnline :ContoCorrente
    {
        private double maxPrelievo; // Variabile che contiene il valore massimo del prelievo
        /// <summary>
        /// Costruttore di conto online
        /// </summary>
        /// <param name="intestatario">Intestatario del conto online</param>
        /// <param name="IBAN">Iban dell' intestatario</param>
        public ContoOnline(Persona intestatario, string IBAN): base(intestatario,IBAN)
        {
            maxPrelievo = 250;
        }
        /// <summary>
        /// Metodo che restituisce il saldo
        /// </summary>
        /// <returns>Saldo del conto</returns>
        public string stampaSaldo()
        {
            string res;
            res = "Intestatario:\n" + this.Intestatario.Nome + "\nCodice Fiscale: " + this.Intestatario.Cf + "\n Saldo conto: " + Saldo;
            return res;
        }
        /// <summary>
        /// Metodo che preleva in base al numero massimo di movimenti
        /// </summary>
        /// <param name="x">Importo da prelevare</param>
        /// <returns>True se il movimento ha avuto successo, false se è fallito.</returns>
        new public bool Preleva(double x)
        {
            if(MovimentoGratuito())
            {
                if (disponibilita_prelievo(x))
                {
                    if (saldo >= x)
                    {
                        saldo -= x;
                        movimenti.Add(new Prelievo(x, "ADSCXAZ", DateTime.Now));
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                if (disponibilita_prelievo(x+costoMovimento))
                {
                    if (saldo >= x+costoMovimento+costoBonifico)
                    {
                        saldo -= x - costoMovimento-costoBonifico;
                        movimenti.Add(new Prelievo(x, "ADSCXAZ", DateTime.Now));
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }

            }   
        }

        /// <summary>
        /// Permette di controlare che il parametro del prelievo non superi il valore massimo predisposto nel conto online.
        /// </summary>
        /// <param name="x">Paramentro del prelievo</param>
        /// <returns>True se è possibile effettuare il movimento con tale importo, False se risulta impossibile</returns>
        private bool disponibilita_prelievo(double x) 
        {
            if (x <= maxPrelievo) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}