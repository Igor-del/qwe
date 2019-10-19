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
    public partial class Form5 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string connect = Program.connect;
        int idp = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string command = "select id_korpus,id_komnata,id_mesto from OBSH where ID_PERSONA is null;";
            string command1 = "select * from Zayvki where sait ='true';";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="")|| (textBox2.Text == "") || (textBox3.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") ||)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else {
                string command = "insert into status_obsh(status_sotrudnik,F,I,O,dz,dv) values({0},'{1}','{2}','{3}','{4}','{5}')";



                SqlConnection connection = new SqlConnection(connect);

                connection.Open();


                string f = textBox1.Text;
                string i = textBox2.Text;
                string o = textBox3.Text;
                int status;
                if (checkBox1.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                string dz = dateTimePicker1.Text;
                string dv = dateTimePicker2.Text;
                string str = String.Format(command, status, f, i, o, dz, dv);
                SqlCommand com = new SqlCommand(str, connection);
                com.ExecuteNonQuery();
                System.Threading.Thread.Sleep(1000);
                string select = "select id from  status_obsh where f='" + textBox1.Text + "' and i='" + textBox2.Text + "' and o='" + textBox3.Text + "' and dz='" + dateTimePicker1.Text + "' ";


                SqlCommand com2 = new SqlCommand(select, connection);

                SqlDataReader rd = com2.ExecuteReader();

                while (rd.Read())
                {
                    idp = rd.GetInt32(0);
                }
                System.Threading.Thread.Sleep(1000);
                string command1 = "update obsh set id_persona='" + idp + "'  where id_korpus='" + textBox5.Text + "' and id_komnata='" + textBox6.Text + "' and id_mesto='" + textBox7.Text + "' ;";
                SqlCommand com1 = new SqlCommand(command1, connection);
                com1.ExecuteNonQuery();
                System.Threading.Thread.Sleep(1000);
                int sait = 1;
                string command2 = "delete zayvki where f='" + textBox1.Text + "' and i='" + textBox2.Text + "' and o='" + textBox3.Text + "'and status='" + status + "' and sait='" + sait + "';";
                SqlCommand com3 = new SqlCommand(command2, connection);
                com3.ExecuteNonQuery();
                MessageBox.Show("Успешно!");
            }

        }
    }
}
