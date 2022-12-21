using System;
using System.IO;
using System.Linq;

class Primeira
{
    public static void Main()
    {
        string path_desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var distancias_cidades = File.ReadAllLines(path_desktop + Path.DirectorySeparatorChar + "matriz.txt")
            .Select(s => s.Split(',').Select(n => Int32.Parse(n)).ToArray())
            .ToArray();

        var caminho = File.ReadLines(path_desktop + Path.DirectorySeparatorChar + "caminho.txt").First()
            .Split(", ")
            .Select(n => Int32.Parse(n)).ToArray();

        int soma_distancia = 0;

        for (int i = 1; i < caminho.Length; i++)
            soma_distancia += distancias_cidades[caminho[i - 1] - 1][caminho[i] - 1];

        Console.WriteLine($"A distância total percorrida foi de {soma_distancia} km.");
    }
}