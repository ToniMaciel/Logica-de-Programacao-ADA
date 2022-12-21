using System;

namespace Solucao
{
    public static class Utils
    {
        public static int LerValorInteiro()
        {
            string? valorLido = Console.ReadLine();
            int valor;

            while (!int.TryParse(valorLido, out valor) || valor <= 0)
            {
                Console.Write($"O valor \"{valorLido}\" não é um número inteiro positivo. Por favor, infome o valor novamente: ");
                valorLido = Console.ReadLine();
            }

            return valor;
        }
    }
}
