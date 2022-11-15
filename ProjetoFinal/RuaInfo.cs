using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class RuaInfo
    {
        public int RuaUm { get; set; }
        public int RuaDois { get; set; }
        public int Tamanho { get; set; }

        public RuaInfo(int ruaUm, int ruaDois)
        {
            RuaUm = ruaUm;
            RuaDois = ruaDois;
        }

        public RuaInfo(int ruaUm, int ruaDois, int tamanho)
        {
            RuaUm = ruaUm;
            RuaDois = ruaDois;
            Tamanho = tamanho;
        }
    }
}
