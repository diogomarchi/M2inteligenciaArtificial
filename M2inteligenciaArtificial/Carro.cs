using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2inteligenciaArtificial
{
    class Carro
    {
        private int caso;
        private string nome_carro;
        private string descricao;
        private string cambio;
        private string cor;
        private int km;
        private string anomod;
        private int preco;

        public int Caso { get => caso; set => caso = value; }
        public string Nome_carro { get => nome_carro; set => nome_carro = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Cambio { get => cambio; set => cambio = value; }
        public string Cor { get => cor; set => cor = value; }
        public int Km { get => km; set => km = value; }
        public string Anomod { get => anomod; set => anomod = value; }
        public int Preco { get => preco; set => preco = value; }
    }
}
