using System;
using Solucao;

class Primeira
{
    public static void Main()
    {
        Console.Write("Informe a quantidade de cidades: ");
        int total_cidades = Utils.LerValorInteiro();
        int[,] distancias_cidades = new int[total_cidades, total_cidades];

        for(int i = 0; i < distancias_cidades.Length; i++)
        {
            for(int j = i+1; j <= distancias_cidades.GetUpperBound(1); j++)
            {
                Console.Write($"Informe a distância entre as cidades {i+1} e {j+1}: ");
                int distancia = Utils.LerValorInteiro();
                distancias_cidades[i, j] = distancias_cidades[j, i] = distancia;
            }
        }

        Console.Write("Informe o tamanho do percurso desejado: ");
        int cidades_percorridas = Utils.LerValorInteiro();
        int[] caminho = new int[cidades_percorridas];
        
        Console.WriteLine($"Informe, uma por linha, a(s) {cidades_percorridas} cidade(s) que fazem parte do percusso:");
        for(int i = 0; i < caminho.Length; i++)
            caminho[i] = Utils.LerValorInteiro();

        int soma_distancia = 0;

        for(int i = 1; i < caminho.Length; i++)
            soma_distancia += distancias_cidades[caminho[i-1]-1,caminho[i]-1];

        Console.WriteLine($"A distância total percorrida foi de {soma_distancia} km.");
    }
}