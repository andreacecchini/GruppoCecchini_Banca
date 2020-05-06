 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca_Esercizio
{
    class Program
    {
        //Creazione classe Banca
        static Banca Banca = new Banca("Banca di stato Italiana", "Roma, via centrale 5");
        static void Main(string[] args)
        {

            ContoCorrente c;
            ContoCorrente d;
            //Creazione conto correnti
            
            Banca.aggiungiConto(new ContoCorrente(new Persona("Andrea", "Cecchini", "Rimini", new DateTime(2002, 05, 02), "CCCNDR05E02"), "AAACCCEEND"));
            Banca.aggiungiConto(new ContoCorrente(new Persona("Enrique", "Angelini", "Riccione", new DateTime(2000, 02, 10), "AAANRQ10E02"), "EEEAAANNRIQ"));
            Banca.aggiungiConto(new ContoOnline(new Persona("Matteo", "Canghiari", "Riccione", new DateTime(2002, 05, 14), "CCCATT05314"), "MMMCCCTTEO"));

            // Creazione movimenti
            // Esempio Versamento
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Il cliente Andrea Cecchini vuole versare 100 euro.IBAN:AAACCCEEND");
            c = Banca.CercaConto("AAACCCEEND");
            c.Versa(100);


            //Esempio Prelievo
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Il cliente Andrea Cecchini vuole prelevare 50 euro.");
            c = Banca.CercaConto("AAACCCEEND");
            if (c.Preleva(50))  //nel caso in cui sia vero oltre che a ritornare il bool il metodo preleva
            {
                Console.WriteLine("Movimento accettato");
            }
            else
            {
               Console.WriteLine("Movimento fallito");

            }

            //Esempio Bonifico
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Il cliente Andrea Cecchini vuole effettuare un bonifico di 50 euro al seguente conto:EEEAAANNRIQ ");
            c = Banca.CercaConto("AAACCCEEND");
            string iban_destinatario= "EEEAAANNRIQ";
            if(c.Bonifico(iban_destinatario, 50)) //nel caso in cui sia vero oltre che a ritornare il bool il metodo effettua un bonifico
            {
                Console.WriteLine("Movimento accettato");
            }
            else
            {
                Console.WriteLine("Movimento rifiutato");
            }

            // Esempio Movimento di Conto Online
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Il cliente Matteo Canghiari vuole prelevare 100 dal suo conto online.");
            c = Banca.CercaConto("MMMCCCTTEO");
            if (((ContoOnline)c).Preleva(100))
            {
                Console.WriteLine("Movimento accettato");
            }
            else
            {
                Console.WriteLine("Movimento fallito");
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Stampa dei vari conti correnti e relativi movimenti");
            //Stampa Movimenti di tutti i conti;
            foreach (ContoCorrente k in Banca.ListaConti)
            {
                Console.WriteLine("\nIntestatario del conto corrente " + k.Intestatario.Nome);
                foreach (Movimento m in k.Movimenti)
                {

                    if (m == null)
                    {
                        Console.WriteLine("Nessun movimento");
                    }
                    else
                    {
                        if (m is Bonifico)
                        {
                            Console.WriteLine("Bonifico");
                            Console.WriteLine(("Iban destinatario: " + ((Bonifico)m).Destinatario));

                        }
                        else
                        {
                            if (m is Prelievo)

                                Console.WriteLine("Prelievo");
                            else
                                Console.WriteLine("Versamento");
                        }
                        Console.WriteLine("Data del movimento: " + m.DataMovimento.ToString());
                        Console.WriteLine("Importo del movimento : " + m.Importo + " euro");
                        Console.WriteLine("Identificativo del movimento: " + m.Id);
                        Console.WriteLine("\n");
                    }

                }

              
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Controllo Conto Online IBAN: MMMCCCTTEO");
            c = Banca.CercaConto("MMMCCCTTEO");
            Console.WriteLine(((ContoOnline)c).stampaSaldo());
            Console.ReadKey();
            
        }
    }
}
