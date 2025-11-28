using System;
using System.Collections.Generic;


namespace Simulatore_negozio
{
    internal class Cassa
    {
        double saldo;

        public Cassa() { }

        public Cassa(double saldoIniziale)
        {
            this.saldo = saldoIniziale;
        }
        public void AggiungiEntrata(double importo)
        {
            this.saldo += importo;
        }

        public void Preleva(double importo)
        {
            this.saldo -= importo;
        }
    }
}
