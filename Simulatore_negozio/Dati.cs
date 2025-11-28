using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Simulatore_negozio
{
    internal class Dati
    {
        public static void Salvataggio(List<Prodotto> listaProdotti, Cassa cassa)
        {
            String jsonProdotti = JsonSerializer.Serialize(listaProdotti);
            File.WriteAllText("..\\..\\..\\Salvataggi\\prodotti.json", jsonProdotti);

            String jsonCassa = JsonSerializer.Serialize(cassa);
            File.WriteAllText("..\\..\\..\\Salvataggi\\cassa.json", jsonCassa);

            Console.WriteLine("Salvataggio completato.");
        }

        public static void Caricamento(out List<Prodotto> listaProdotti, out Cassa cassa)
        {
            if (File.Exists("..\\..\\..\\Salvataggi\\prodotti.json"))
            {
                string jsonProdotti = File.ReadAllText("..\\..\\..\\Salvataggi\\prodotti.json");
                listaProdotti = JsonSerializer.Deserialize<List<Prodotto>>(jsonProdotti);
            }
            else
            {
                listaProdotti = new List<Prodotto>();
            }

            // Caricamento cassa
            if (File.Exists("..\\..\\..\\Salvataggi\\cassa.json"))
            {
                string jsonCassa = File.ReadAllText("..\\..\\..\\Salvataggi\\cassa.json");
                cassa = JsonSerializer.Deserialize<Cassa>(jsonCassa);
            }
            else
            {
                cassa = new Cassa(0);
            }
        }
    }
}
