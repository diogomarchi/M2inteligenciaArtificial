using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2inteligenciaArtificial
{
    class CarroComSimilaridade : Carro
    {
        private float similaridade = 0F;
        private float similaridadeCarro = 0F;
        private float similaridadeCambio = 0F;
        private float similaridadeCor = 0F;
        private float similaridadeKm = 0F;
        private float similaridadeAnoMod = 0F;
        private float similaridadePreco = 0F;

        public float Similaridade { get => similaridade; set => similaridade = value; }
        public float SimilaridadeCarro { get => similaridadeCarro; set => similaridadeCarro = value; }
        public float SimilaridadeCambio { get => similaridadeCambio; set => similaridadeCambio = value; }
        public float SimilaridadeCor { get => similaridadeCor; set => similaridadeCor = value; }
        public float SimilaridadeKm { get => similaridadeKm; set => similaridadeKm = value; }
        public float SimilaridadeAnoMod { get => similaridadeAnoMod; set => similaridadeAnoMod = value; }
        public float SimilaridadePreco { get => similaridadePreco; set => similaridadePreco = value; }

        public CarroComSimilaridade(Carro carro)
        {
            this.Caso = carro.Caso;
            this.Nome_carro = carro.Nome_carro;
            this.Descricao = carro.Descricao;
            this.Cambio = carro.Cambio;
            this.Cor = carro.Cor;
            this.Km = carro.Km;
            this.Anomod = carro.Anomod;
            this.Preco = carro.Preco;

        }

        public void SimilaridadeTotal(float soma_pesos)
        {
            similaridade = SimilaridadeCarro + SimilaridadeCambio + SimilaridadeCor + SimilaridadeKm + SimilaridadeAnoMod + SimilaridadePreco;
            similaridade /= soma_pesos;
        }
    }
}
