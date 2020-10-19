using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace sistemaRBC
{
    public sealed class DAO
    {
        private static DAO staticDao = null;

        private string strConnect = "Server=127.0.0.1;User Id=postgres; Password=diogo123; Database=cadastro2;";

        public NpgsqlConnection connection;

        public static DAO getInstance()
        {
            /*Exclusão Mutua*/
            lock (typeof(DAO))
            {
                if (staticDao == null)
                {
                    DAO.staticDao = new DAO();
                }
                return DAO.staticDao;
            }
        }


        public DAO()
        {
            try
            {
                connection = new NpgsqlConnection(strConnect);
                connection.Open();


            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        ~DAO()
        {
            connection.Close();
        }

    }
}




   