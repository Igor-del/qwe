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
    public partial class Form2 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        public Form2()
        {
            InitializeComponent();
            string connect = @"data source=OMEN-01\SQLEXPRESS;initial catalog=my;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string command = "select * from Korpus_obsh;";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                adapter = new SqlDataAdapter(command, connection);

                ds = new DataSet();

                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите id корпуса");
            }
            else
            {
                //string connect = @"data source=OMEN-01\SQLEXPRESS;initial catalog=my;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                string connect = Program.connect;
                string command = "update korpus_Obsh set adres='" + textBox2.Text + "';";
                SqlConnection con = new SqlConnection(connect);
                con.Open();
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                Form2 form = new Form2();
                form.Show();
                Hide();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
