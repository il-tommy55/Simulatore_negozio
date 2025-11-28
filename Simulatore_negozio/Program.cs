//Inizializzazione programma


using Simulatore_negozio;

Console.WriteLine("Benvenuto nel gestore negozio.");
Console.WriteLine("Inserire nome negozio: ");
Negozio negozio = new Negozio(Console.ReadLine());

bool loop = true;

while (loop)
{

    Console.WriteLine("\n\tMENU" +
                      "\n1. Aggiungi prodotto;" +
                      "\n2. Visualizzare prodotto;" +
                      "\n3. Vendere prodotto;" +
                      "\n4. Rimuovere prodotto;" +
                      "\n5. Aggiornare prodotto;" +
                      "\n6. Impostazioni;" +
                      "\n7. Uscire.");
    Console.WriteLine("Scegliere una delle opzioni: ");
    String scelta = Console.ReadLine();

    switch(scelta) 
    {
        case "1":
            negozio.AggiungereProdotti();
            break;

        case "2":
            negozio.VisualizzareProdotti();
            break;

        case "3":
            negozio.VendereProdotto();
            break;

        case "4":
            negozio.RimuoviProdotto();
            break;

        case "5":
            negozio.AggiornareProdotto();
            break;

        case "6":
            Console.WriteLine("\n\tImpostazioni" +
                              "\n1. Salvataggio." +
                              "\n2. Caricamento.");
            Console.WriteLine("Scegliere una delle opzioni: ");
            int sceltaImpostazioni = Convert.ToInt32(Console.ReadLine());

            switch(sceltaImpostazioni)
            {
                case 1:
                    Dati.Salvataggio(negozio.ListaProdotti, negozio.cassa);
                    break;

                case 2:
                    List<Prodotto> listaCaricata;
                    Cassa cassaCaricata;

                    Dati.Caricamento(out listaCaricata, out cassaCaricata);

                    negozio.ListaProdotti.Clear();
                    negozio.ListaProdotti.AddRange(listaCaricata);
                    negozio.cassa = cassaCaricata;

                    Console.WriteLine("Dati caricati con successo!");
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
            break;

        case "7":
            loop = false;
            break;

        default:
            Console.WriteLine("Scelta non valida.");
            break;

    }

}

