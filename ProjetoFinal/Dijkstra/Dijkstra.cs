using System;
using System.Collections.Generic;
using System.Linq;

namespace Grafos.Dijkstra
{
    public class DijkstraAlg
    {
        // Arestas contendo os valores das conexões entre os computadores
        private IList<CaminhoInfo> Caminhos { get; }

        // Resultado depois de percorrer todas os computadores 
        private IList<Caminho> Caminho { get; }

        // Para ter o controle dos computadores não visitados
        private IList<Computador> ComputadoresNaoVisitados { get; }
        public DijkstraAlg(List<CaminhoInfo> arestas, List<Computador> computadores, int computadorInicialId)
        {
            Caminhos = PreencherGrafoBiDirecional(arestas);
            ComputadoresNaoVisitados = computadores;
            Caminho = new List<Caminho>();
            Preencher(computadorInicialId);
        }

        public void Executar()
        {
            // Se não tive vertices não visitados, irá parar o algoritmo
            if (ComputadoresNaoVisitados.Count == 0)
                return;

            // Irá pegar o menor valor que esteja nos vertices não visitados
            var min = TakeMin();

            // Irá pegar todos os vértices adjacentes ao vertice escolhido acima
            var verticesAdj = VerticesAdjacentes(min.ComputadorId);

            foreach (var item in verticesAdj)
            {
                var soma = min.Tamanho + item.CustoOp;
                if (soma < PegarValorVertice(item.ComputadorDois))
                {
                    AtualizarValores(item.ComputadorDois, item.ComputadorUm, soma);
                }
            }

            Executar();
        }

        private Caminho TakeMin()
        {
            // Pega o primeiro valor menor que o simbolico e que esteja nos vertices não visitados
            var result = Caminho.FirstOrDefault(x => x.Tamanho < int.MaxValue && ComputadoresNaoVisitados.Any(v => v.Id == x.ComputadorId));
            var vertice = ComputadoresNaoVisitados.Where(x => x.Id == result.ComputadorId).FirstOrDefault();

            // remove do vertices não visitados
            ComputadoresNaoVisitados.Remove(vertice);

            return result;
        }

        private List<CaminhoInfo> VerticesAdjacentes(int computadorUm)
        {
            return Caminhos.Where(x => x.ComputadorUm == computadorUm).ToList();
        }

        // Retorna o valor atribuido ao vertice
        private int PegarValorVertice(int n)
        {
            var result = Caminho.FirstOrDefault(x => x.ComputadorId == n).Tamanho;
            return result;
        }

        private void AtualizarValores(int vertice, int prev, int valor)
        {
            var result = Caminho.FirstOrDefault(x => x.ComputadorId == vertice);

            result.Tamanho = valor;
            result.Prev = prev;
        }

        // Seta os valores após a instância da classe
        private void Preencher(int verticeInicial)
        {
            foreach (var item in ComputadoresNaoVisitados)
            {
                Caminho vertice = new Caminho
                {
                    ComputadorId = item.Id,
                    Tamanho = int.MaxValue,
                    Prev = null
                };

                if (item.Id == verticeInicial)
                {
                    vertice.Tamanho = 0;
                }

                Caminho.Add(vertice);
            }
        }

        // Irá pegar as arestas que foram passadas, criar uma nova com os vertices invertidos, para assim ter um grafo bidirecional
        private List<CaminhoInfo> PreencherGrafoBiDirecional(List<CaminhoInfo> arestas)
        {
            var listResult = new List<CaminhoInfo>();
            foreach (var item in arestas)
            {
                var novaAresta = new CaminhoInfo(item.ComputadorDois, item.ComputadorUm, item.CustoOp); // Inverte os vertices
                listResult.Add(novaAresta);
                listResult.Add(item);
            }

            return listResult;
        }

        public void PrintCaminho()
        {
            Console.WriteLine("Melhor caminho: ");
            foreach (var item in Caminho.ToList())
            {
                if(item.Prev == null)
                {
                    Console.WriteLine($"Começo ->  Computador {item.ComputadorId} ");
                    continue;
                }

                Console.WriteLine($"| Computador {item.Prev} ->  Computador {item.ComputadorId} |");
            }
        }
    }
}
