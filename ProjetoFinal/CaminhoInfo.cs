using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class CaminhoInfo
    {
        public int ComputadorUm { get; set; }
        public int ComputadorDois { get; set; }
        public int CustoOp { get; set; }

        public CaminhoInfo(int ruaUm, int ruaDois)
        {
            ComputadorUm = ruaUm;
            ComputadorDois = ruaDois;
        }

        public CaminhoInfo(int computadorUm, int computadorDois, int custoOp)
        {
            ComputadorUm = computadorUm;
            ComputadorDois = computadorDois;
            CustoOp = custoOp;
        }
    }
}
