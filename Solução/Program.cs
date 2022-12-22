using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Solucao;

class Primeira
{
    public static void Main(string[] args)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };

        string path_desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        using var reader = new StreamReader(path_desktop + Path.DirectorySeparatorChar + "matriz.txt");
        using var csv = new CsvParser(reader, config);

        if (!csv.Read())
            return;

        var numColunas = csv.Record.Length;
        var distancias_cidades = new int[numColunas, numColunas];

        for (int i = 0; i < numColunas; i++)
        {
            var linha = csv.Record;

            for (int j = 0; j < numColunas; j++)
                distancias_cidades[i, j] = int.Parse(linha[j]);

            csv.Read();
        }

        using var reader_caminho = new StreamReader(path_desktop + Path.DirectorySeparatorChar + "caminho.txt");
        using var csv_caminho = new CsvParser(reader_caminho, config);

        if (!csv_caminho.Read())
            return;

        int cidades_percorridas = csv_caminho.Record.Length;
        int[] caminho = new int[cidades_percorridas];

        for (int i = 0; i < cidades_percorridas; i++)
            caminho[i] = int.Parse(csv_caminho[i]);

        int soma_distancia = 0;
        for (int i = 1; i < caminho.Length; i++)
            soma_distancia += distancias_cidades[caminho[i - 1] - 1, caminho[i] - 1];

        Console.WriteLine($"A distância total percorrida foi de {soma_distancia} km.");
    }
}