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
            List<RuaInfo> arestas = new List<RuaInfo>
            {
                new RuaInfo(2, 4, 6),
                new RuaInfo(2, 5, 3),
                new RuaInfo(2, 6, 7),
                new RuaInfo(2, 1, 1),
                new RuaInfo(1, 3, 1),
                new RuaInfo(6, 3, 4),
                new RuaInfo(5, 3, 7),
                new RuaInfo(4, 3, 34)
            };


            List<Rua> vertices = new List<Rua>
            {
                new Rua(1),
                new Rua(2),
                new Rua(3),
                new Rua(4),
                new Rua(5),
                new Rua(6)
            };


            DijkstraAlg dik = new DijkstraAlg(arestas, vertices, 2);
            dik.Executar();
        }
    }
}
