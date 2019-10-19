using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ses1
{
    public partial class Form3 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        public Form3()
        {
            InitializeComponent();
            string connect = @"data source=OMEN-01\SQLEXPRESS;initial catalog=my;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string command = "select id_korpus,id_komnata,id_mesto from OBSH where ID_PERSONA is null;";
            string command1 = "select ID_KORPUS,ID_KOMNATA from OBSH where ID_PERSONA is null group by ID_KORPUS,ID_KOMNATA  having  count(ID_KOMNATA)=4;";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                adapter = new SqlDataAdapter(command, connection);

                ds = new DataSet();

                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                adapter = new SqlDataAdapter(command1, connection);

                ds = new DataSet();

                adapter.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
