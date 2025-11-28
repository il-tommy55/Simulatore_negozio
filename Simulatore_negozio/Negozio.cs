using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Simulatore_negozio
{
    internal class Negozio
    {
        public String nomeNegozio;

        public Negozio(String nomeNegozio)
        {
            this.nomeNegozio = nomeNegozio;
        }
        
        public Cassa cassa = new Cassa(0);

        public List<Prodotto> ListaProdotti { get; set;  } = new List<Prodotto>();

        private Prodotto CercareProdotto()
        {
            String nomeDaCercare;
            Console.WriteLine("\nInserisci il nome del prodotto: ");
            nomeDaCercare = Console.ReadLine();

            Prodotto trovato = ListaProdotti.Find(p => p.nome == nomeDaCercare);

            return trovato;
        }

        public void AggiungereProdotti()
        {
            String nome;
            double prezzo;
            int quantita;
            String categoria;
            
            Console.WriteLine("\nAggiungi il nome del prodotto: ");
            nome = Console.ReadLine();

            Console.WriteLine("Aggiungi il prezzo: ");
            prezzo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Aggiungi la quantità: ");
            quantita = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aggiungi la categoria: ");
            categoria = Console.ReadLine();

            Prodotto nuovoProdotto = new Prodotto(nome, prezzo, quantita, categoria);

            ListaProdotti.Add(nuovoProdotto);
        }
    
        public void VisualizzareProdotti()
        {
            foreach(Prodotto prodotto in ListaProdotti)
            {
                Console.WriteLine($"\nNome: {prodotto.nome}\nPrezzo: {prodotto.prezzo}\nQuantità: {prodotto.quantita}\nCategoria: {prodotto.categoria}");
            }
        }
    
        public void VendereProdotto()
        {
            int quantitaDaVendere;

            Prodotto p = CercareProdotto();

            Console.WriteLine("\nInserisci la quantità: ");
            quantitaDaVendere = Convert.ToInt32(Console.ReadLine());

            if (quantitaDaVendere < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantitaDaVendere), "La quantità non può essere negativa.");
            }

            if (p != null)
            {
                if(p.quantita >= quantitaDaVendere)
                {
                    p.quantita -= quantitaDaVendere;
                    // quantitaDaVendere * trovato.prezzo
                    cassa.AggiungiEntrata(quantitaDaVendere * p.prezzo);
                }
                else
                {
                    Console.WriteLine("Quantità insufficiente.");
                }
            }
            else
            {
                Console.WriteLine("Prodotto non trovato.");
            }

        }
    
        public void RimuoviProdotto()
        {
            String nomeDaRimuovere;

            Console.WriteLine("\nInserire il nome del prodotto da rimuovere");
            nomeDaRimuovere = Console.ReadLine();

            Prodotto p = CercareProdotto();

            if(p != null)
            {
                ListaProdotti.Remove(p);
                Console.WriteLine("Prodotto rimosso con successo.");
            }
            else
            {
                Console.WriteLine("Prodotto non trovato.");
            }

        }

        public void AggiornareProdotto()
        {
            Prodotto p = CercareProdotto();

            if(p != null)
            {

                Console.WriteLine("\nNuovo prezzo: ");
                p.prezzo = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Nuova quantità: ");
                p.quantita = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nuova categoria: ");
                p.categoria = Console.ReadLine();

                Console.WriteLine("Prodotto aggiornato con successo!");


            }
            else
            {
                Console.WriteLine("Prodotto non trovato");
            }
        }

    }
}
