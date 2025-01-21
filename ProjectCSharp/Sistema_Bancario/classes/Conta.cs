using System;
using Sistema_Bancario.Enum;



namespace Sistema_Bancario.Classes
{
    public class Conta
    {
        private string Nome { get; set; }

        public double Credito { get; set; }

        public double Saldo { get; set; }

        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, string Nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Nome = Nome;
            this.Credito = saldo * 2;
        }

    }

}