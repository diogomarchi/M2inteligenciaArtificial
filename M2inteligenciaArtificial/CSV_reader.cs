using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace M2inteligenciaArtificial
{
    class CSV_reader
    {
        List<Carro> carros = new List<Carro>();

        public List<Carro> read(String caminho)
        {
            using (StreamReader reader = new StreamReader(caminho))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    Carro carro = new Carro();

                    carro.Caso = Convert.ToInt32(values[0]);
                    carro.Nome_carro = values[1];
                    carro.Descricao = values[2];
                    carro.Cambio = values[3];
                    carro.Cor = values[4];
                    carro.Km = Convert.ToInt32(values[5]);
                    carro.Anomod = values[6];
                    carro.Preco = Convert.ToInt32(values[7]);

                    carros.Add(carro);
                }
            }

            return carros;
        }
    }
}
