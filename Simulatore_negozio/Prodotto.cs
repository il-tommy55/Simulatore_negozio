using System;

namespace Simulatore_negozio
{
    internal class Prodotto
    {
        public string nome { get; set; }
        public double prezzo { get; set; }
        public int quantita { get; set; }
        public string categoria { get; set; }

        public Prodotto() { }

        public Prodotto(string nome, double prezzo, int quantita, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Il nome non può essere vuoto.", nameof(nome));
            if (prezzo < 0)
                throw new ArgumentOutOfRangeException(nameof(prezzo), "Il prezzo non può essere negativo.");
            if (quantita < 0)
                throw new ArgumentOutOfRangeException(nameof(quantita), "La quantità non può essere negativa.");

            this.nome = nome;
            this.prezzo = prezzo;
            this.quantita = quantita;
            this.categoria = categoria;
        }

    }
}
