using System.Collections.Generic;
using System.Linq;

namespace Grafos.Dijkstra
{
    public class DijkstraAlg
    {
        private IList<RuaInfo> Ruas { get; } // Ruas com tamanho
        private IList<Caminho> Caminho { get; } // Resultado depois de percorrer todas as ruas 
        private IList<Rua> RuasNaoVisitadas { get; } // Para ter o controle das ruas não visitados
        public DijkstraAlg(List<RuaInfo> arestas, List<Rua> ruas, int ruaInicial)
        {
            Ruas = arestas;
            RuasNaoVisitadas = ruas;
            Caminho = new List<Caminho>();
            Preencher(ruaInicial);
        }

        public void Executar()
        {
            // Se não tive vertices não visitados, irá parar o algoritmo
            if (RuasNaoVisitadas.Count == 0)
                return;

            var min = TakeMin(); // Irá pegar o menor valor que esteja nos vertices não visitados

            var verticesAdj = VerticesAdjacentes(min.Id); // Depois irá pegar todos os vértices adjacentes ao vertice escolhido

            foreach(var item in verticesAdj)
            {
                var soma = min.Tamanho + item.Tamanho;
                if(soma < PegarValorVertice(item.RuaDois)) 
                {
                   AtualizarValores(item.RuaDois, item.RuaUm, soma);   
                }
            }

            Executar();
        }

        public Caminho TakeMin()
        {
            var result = Caminho
            .FirstOrDefault(x => x.Tamanho < int.MaxValue &&
            RuasNaoVisitadas.Any(v => v.Id == x.Id)); // Pega o primeiro valor menor que o simbolico e que esteja nos vertices não visitados
            var vertice = RuasNaoVisitadas.Where(x => x.Id == result.Id).FirstOrDefault();

            // remove do vertices não visitados
            RuasNaoVisitadas.Remove(vertice);

            return result;
        }

        public List<Grafos.RuaInfo> VerticesAdjacentes(int ruaUm)
        {
            return Ruas.Where(x => x.RuaUm == ruaUm).ToList();
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
            foreach (var item in RuasNaoVisitadas)
            {
                Caminho vertice = new Caminho
                {
                    Id = item.Id,
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

        /* Irá fazer o print do caminho com os valores
        public void printPath()
        {
            foreach(var item in Result.OrderBy(x => x.Prev))
            {
                if (item.Prev == null)
                {
                    Console.WriteLine($"inicio => {item.Vertice}: {item.Valor}");
                    continue;
                }

                Console.WriteLine($"{item.Prev} => {item.Vertice}: {item.Valor}");
            }
        } */
    }
}
