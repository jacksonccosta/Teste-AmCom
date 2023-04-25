using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
        private readonly int _numeroConta;
        private string _nomeTitular;
        private double _saldo;

        public ContaBancaria(int numeroConta, string nomeTitular, double saldoInicial = 0)
        {
            _numeroConta = numeroConta;
            _nomeTitular = nomeTitular;
            _saldo = saldoInicial;
        }

        public void Deposito(double valor)
        {
            _saldo += valor;
        }

        public bool Saque(double valor)
        {
            _saldo -= (valor + 3.50);
            return true;
        }

        public string ObterDadosDaConta()
        {
            return $"**********************************************************************\n" +
                    $" Conta {_numeroConta}, Titular: {_nomeTitular}, Saldo: $ {_saldo:F2} \n"+
                    $"**********************************************************************";
        }

        public void AlterarNomeTitular(string novoNome)
        {
            _nomeTitular = novoNome;
        }
    
    }
}
