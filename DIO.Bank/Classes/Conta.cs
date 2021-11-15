﻿
namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            else
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
                return true;
            }
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}