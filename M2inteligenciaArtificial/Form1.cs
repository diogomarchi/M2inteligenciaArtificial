using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Threading;


namespace M2inteligenciaArtificial
{
    public partial class Form1 : Form
    {
        CSV_reader cSV_Reader = new CSV_reader();
        List<Carro> carros;
        List<CarroComSimilaridade> carros_similaridade = new List<CarroComSimilaridade>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {        
            // form maximizado
            this.WindowState = FormWindowState.Maximized;

            button2.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // indicador de carregando
            label9.Visible = true;
            this.Refresh();
                        

            // carrega os dados
            carros = cSV_Reader.read("..\\..\\casos_carros.csv");

            // bind
            var bindingList = new BindingList<Carro>(carros);
            var source = new BindingSource(bindingList, null);

            // source da grid
            dataGridView1.DataSource = source;

            // resize coluna
            dataGridView1.AutoResizeColumns();

            label9.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Carro novo_caso = new Carro();
            novo_caso.Nome_carro = comboBox9.Text;
            novo_caso.Cambio = comboBox1.Text;
            novo_caso.Cor = comboBox2.Text;
            novo_caso.Km = Convert.ToInt32(textBox4.Text.Trim(' '));
            novo_caso.Anomod = textBox5.Text;
            novo_caso.Preco = Convert.ToInt32(textBox6.Text);

            CalcSimilaridade calc = new CalcSimilaridade();

            calc.pesos[0] = (float) Convert.ToInt32(comboBox3.Text);
            calc.pesos[1] = (float) Convert.ToInt32(comboBox4.Text);
            calc.pesos[2] = (float) Convert.ToInt32(comboBox5.Text);
            calc.pesos[3] = (float) Convert.ToInt32(comboBox6.Text);
            calc.pesos[4] = (float) Convert.ToInt32(comboBox7.Text);
            calc.pesos[5] = (float) Convert.ToInt32(comboBox8.Text);

            calc.CalculaSimilaridade(carros, novo_caso);
            carros_similaridade = calc.carros_similaridade;

            // implementar a seleção dos mais semelhantes aqui 
            var item = carros_similaridade.OrderByDescending(x => x.Similaridade).Take(10).ToList();

            // bind
            var bindingList = new BindingList<CarroComSimilaridade>(item);
            var source = new BindingSource(bindingList, null);

            // source da grid
            dataGridView2.DataSource = source;            

            // resize coluna
            dataGridView2.AutoResizeColumns();

            /*            Console.WriteLine(item.Caso);
                        Console.WriteLine(item.similaridade);
                        Console.WriteLine(item.similaridadeCarro);
                        Console.WriteLine(item.similaridadeCambio);
                        Console.WriteLine(item.similaridadeCor);
                        Console.WriteLine(item.similaridadeKm);
                        Console.WriteLine(item.similaridadeAnoMod);
                        Console.WriteLine(item.similaridadePreco);*/

            this.Refresh();

        }
    }
}
