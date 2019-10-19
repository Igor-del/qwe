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
    public partial class Form4 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        
        public Form4()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            string connect = @"data source=OMEN-01\SQLEXPRESS;initial catalog=my;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string command = "select * from status_obsh;";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                adapter = new SqlDataAdapter(command, connection);

                ds = new DataSet();

                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;
            string connect = @"data source=OMEN-01\SQLEXPRESS;initial catalog=my;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string command = "select obsh.id,id_korpus,id_komnata,id_mesto,id_persona,status_sotrudnik from OBSH left join Status_obsh on obsh.id_persona=status_obsh.id where ID_KOMNATA=(select ID_KOMNATA from OBSH where ID_PERSONA='"+textBox1.Text+"');";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                adapter = new SqlDataAdapter(command, connection);

                ds = new DataSet();

                adapter.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }
        }
    }
}
