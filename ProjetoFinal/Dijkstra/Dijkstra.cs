using System.Collections.Generic;
using System.Linq;

namespace Grafos.Dijkstra
{
    public class DijkstraAlg
    {
        private IList<CaminhoInfo> Caminhos { get; } // Arestas contendo os valores das conexões entre os computadores
        public IList<Caminho> Caminho { get; } // Resultado depois de percorrer todas os computadores 
        private IList<Computador> ComputadoresNaoVisitados { get; } // Para ter o controle dos computadores não visitados
        public DijkstraAlg(List<CaminhoInfo> arestas, List<Computador> computadores, int computadorInicialId)
        {
            Caminhos = arestas;
            ComputadoresNaoVisitados = computadores;
            Caminho = new List<Caminho>();
            Preencher(computadorInicialId);
        }

        public void Executar()
        {
            // Se não tive vertices não visitados, irá parar o algoritmo
            if (ComputadoresNaoVisitados.Count == 0)
                return;

            var min = TakeMin(); // Irá pegar o menor valor que esteja nos vertices não visitados

            var verticesAdj = VerticesAdjacentes(min.Id); // Depois irá pegar todos os vértices adjacentes ao vertice escolhido

            foreach(var item in verticesAdj)
            {
                var soma = min.Tamanho + item.CustoOp;
                if(soma < PegarValorVertice(item.ComputadorDois)) 
                {
                   AtualizarValores(item.ComputadorDois, item.ComputadorUm, soma);   
                }
            }

            Executar();
        }

        public Caminho TakeMin()
        {
            var result = Caminho
            .FirstOrDefault(x => x.Tamanho < int.MaxValue &&
            ComputadoresNaoVisitados.Any(v => v.Id == x.Id)); // Pega o primeiro valor menor que o simbolico e que esteja nos vertices não visitados
            var vertice = ComputadoresNaoVisitados.Where(x => x.Id == result.Id).FirstOrDefault();

            // remove do vertices não visitados
            ComputadoresNaoVisitados.Remove(vertice);

            return result;
        }

        public List<CaminhoInfo> VerticesAdjacentes(int computadorUm)
        {
            return Caminhos.Where(x => x.ComputadorUm == computadorUm).ToList();
        }

        // Retorna o valor atribuido ao vertice
        public int PegarValorVertice(int n)
        {
            var result = Caminho.FirstOrDefault(x => x.Id == n).Tamanho;
            return result;
        }

        public void AtualizarValores(int vertice, int prev, int valor)
        {
            var result = Caminho.FirstOrDefault(x => x.Id == vertice);

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
    }
}
