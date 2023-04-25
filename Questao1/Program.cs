using System;
using System.Drawing;
using System.Globalization;

namespace Questao1 {
    class Program {
        static void Main(string[] args) {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            ContaBancaria conta;
            int numero;
            string titular;
            char resp;
            double depositoInicial;
            double quantia;

            while (true)
            {
                Console.Write("Entre o número da conta: ");
                if (int.TryParse(Console.ReadLine(), out numero))
                    break;

                Console.WriteLine("Número de conta inválido. Tente novamente.");
            }

            Console.Write("Entre o titular da conta: ");
            titular = Console.ReadLine();

            while (true)
            {
                Console.Write("Haverá depósito inicial (s/n)? ");
                resp = char.Parse(Console.ReadLine());

                switch (char.ToUpper(resp))
                {
                    case 'S':
                        while (true)
                        {
                            Console.Write("Entre o valor de depósito inicial: ");
                            if (double.TryParse(Console.ReadLine(), out depositoInicial))
                                break;

                            Console.WriteLine("Valor inválido. Tente novamente.");
                        }
                        conta = new ContaBancaria(numero, titular, depositoInicial);
                        break;
                    case 'N':
                        conta = new ContaBancaria(numero, titular);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        continue;
                }
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta.ObterDadosDaConta());

            Console.WriteLine();
            while (true)
            {
                Console.Write("Entre um valor para depósito: ");
                if (double.TryParse(Console.ReadLine(), out quantia))
                {
                    conta.Deposito(quantia);
                    Console.WriteLine("Dados da conta atualizados:");
                    Console.WriteLine(conta.ObterDadosDaConta());
                    break;
                }
                Console.WriteLine("Valor inválido. Tente novamente.");
            }

            Console.WriteLine();
            while (true)
            {
                Console.Write("Entre um valor para saque: ");
                if (double.TryParse(Console.ReadLine(), out quantia))
                {
                    conta.Saque(quantia);
                    Console.WriteLine("Dados da conta atualizados:");
                    Console.WriteLine(conta.ObterDadosDaConta());
                    break;
                }
                Console.WriteLine("Valor inválido. Tente novamente.");
            }

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}
