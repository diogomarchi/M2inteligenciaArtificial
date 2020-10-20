using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2inteligenciaArtificial
{
    class CarroComSimilaridade : Carro
    {
        float similaridade = 0F;        

        public CarroComSimilaridade(Carro carro, float sim)
        {
            this.Caso = carro.Caso;
            this.Nome_carro = carro.Nome_carro;
            this.Descricao = carro.Descricao;
            this.Cambio = carro.Cambio;
            this.Cor = carro.Cor;
            this.Km = carro.Km;
            this.Anomod = carro.Anomod;
            this.Preco = carro.Preco;

            this.similaridade = sim;

        }
    }
}
