using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M2inteligenciaArtificial
{
    public partial class Form1 : Form
    {
        CSV_reader cSV_Reader = new CSV_reader();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // carrega os dados
            List<Carro> carros = cSV_Reader.read("..\\..\\casos_carros.csv");
                      
            // bind
            var bindingList = new BindingList<Carro>(carros);
            var source = new BindingSource(bindingList, null);

            // source da grid
            dataGridView1.DataSource = source;

            // resize coluna
            dataGridView1.AutoResizeColumns();

            // form maximizado
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
