using Grafos;
using Grafos.Dijkstra;
using System;
using System.Collections.Generic;

namespace ProjetoFinal
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<CaminhoInfo> arestas = new List<CaminhoInfo>
            {
                new CaminhoInfo(1, 2, 3),
                new CaminhoInfo(1, 3, 10),
                new CaminhoInfo(3, 2, 6),
                new CaminhoInfo(3, 4, 9),
                new CaminhoInfo(2, 4, 4),
                new CaminhoInfo(2, 5, 6),
                new CaminhoInfo(5, 2, 6),
                new CaminhoInfo(3, 5, 5),
                new CaminhoInfo(4, 2, 4),
                new CaminhoInfo(4, 5, 3),
                new CaminhoInfo(4, 6, 9),
                new CaminhoInfo(4, 7, 9),
                new CaminhoInfo(5, 6, 4),
                new CaminhoInfo(5, 7, 5),
                new CaminhoInfo(7, 6, 5)
            };


            List<Computador> vertices = new List<Computador>
            {
                new Computador(1),
                new Computador(2),
                new Computador(3),
                new Computador(4),
                new Computador(5),
                new Computador(6),
                new Computador(7)
            };


            DijkstraAlg dijkstra = new DijkstraAlg(arestas, vertices, 1);
            dijkstra.Executar();
            dijkstra.PrintCaminho();
        }
    }
}
