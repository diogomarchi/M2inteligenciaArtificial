using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M2inteligenciaArtificial
{
    class CalcSimilaridade
    {
        static int CARRO_MAX = 27;
        static int KM_MAX = 251500;
        static int ANO_MAX = 2014;
        static int PRECO_MAX = 245000;

        public List<CarroComSimilaridade> carros_similaridade = new List<CarroComSimilaridade>();

        public List<float> pesos = new List<float> {0f,0f,0f,0f,0f,0f};

        Dictionary<String, float> carros_x_val = new Dictionary<String, float>{
            {"amarok", 1f },
            {"hilux", 2f },
            {"silverado", 3f },
            {"duster", 4f },
            {"ecosport", 5f },
            {"civic", 100f},
            {"cruze", 101f},
            {"focus", 102f},
            {"fusion", 103f},
            {"jetta", 104f},
            {"fluence", 200f},
            {"hb20", 201f},
            {"onix", 202f},
            {"sandero", 203f},
            {"gol", 215f},
            {"punto", 216f},
            {"uno", 217f}
        };
        

        public void CalculaSimilaridade(List<Carro> casos, Carro novo_caso)
        {
            float soma_pesos = pesos.Sum();

            foreach (Carro caso in casos)
            {
                CarroComSimilaridade carroComSimilaridade = new CarroComSimilaridade(caso);
                
                carroComSimilaridade.SimilaridadeCarro = pesos[0] * AtributoCarro(caso.Nome_carro, novo_caso.Nome_carro, CARRO_MAX);
                carroComSimilaridade.SimilaridadeCambio = pesos[1] * AtributoCambio(caso.Cambio, novo_caso.Cambio);
                carroComSimilaridade.SimilaridadeCor = pesos[2] * AtributoCor(caso.Cor, novo_caso.Cor);
                carroComSimilaridade.SimilaridadeKm = pesos[3] * AtributoKm(caso.Km, novo_caso.Km, KM_MAX);
                carroComSimilaridade.SimilaridadeAnoMod = pesos[4] * AtributoAnomod(caso.Anomod, novo_caso.Anomod, ANO_MAX);
                carroComSimilaridade.SimilaridadePreco = pesos[5] * AtributoPreco(caso.Preco, novo_caso.Preco, PRECO_MAX);

                carroComSimilaridade.SimilaridadeTotal(soma_pesos);

                carros_similaridade.Add(carroComSimilaridade);
            }
        }

        float AtributoCarro(String carro_1, String carro_2, int max_val)
        {
            float val_1 = carros_x_val[carro_1.ToLower()];
            float val_2 = carros_x_val[carro_2.ToLower()];

            return 1F - Math.Abs((val_1 - val_2) / (float)max_val);
        }

        float AtributoCambio(String cambio_1, String cambio_2)
        {
            if (cambio_1.Equals(cambio_2) || cambio_1.Equals("indiferente"))
                return 1F;
            else
                return 0F;

        }

        float AtributoCor(String cor_1, String cor_2)
        {
            if (cor_1.Equals(cor_2) || cor_1.Equals("indiferente"))
                return 1F;
            else
                return 0F;
        }

        float AtributoKm(int km_1, int km_2, int km_max)
        {
            return 1F - Math.Abs((km_1 - km_2) / (float) km_max); 
        }

        float AtributoAnomod(String ano_1, String ano_2, int max_ano)
        {
            int i_ano_1 = Convert.ToInt32(ano_1.Split('/')[0]); 
            int i_ano_2 = Convert.ToInt32(ano_2.Split('/')[0]);

            float sim_1 = 1F - Math.Abs((i_ano_1 - i_ano_2) / (float) max_ano);

            i_ano_1 = Convert.ToInt32(ano_1.Split('/')[1]); 
            i_ano_2 = Convert.ToInt32(ano_2.Split('/')[1]);

            float sim_2 = 1F - Math.Abs((i_ano_1 - i_ano_2) / (float) max_ano);

            return (sim_1 + sim_2) / 2F;
        }

        float AtributoPreco(int preco_1, int preco_2, int preco_max)
        {
            return 1F - Math.Abs((preco_1 - preco_2) / (float) preco_max);
        }

    }
}
