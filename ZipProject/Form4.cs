using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ZipProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        void griddoldur()
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bilgiler1.accdb");
            da = new OleDbDataAdapter("Select *from bilgiler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "bilgiler");
            dataGridView1.DataSource = ds.Tables["bilgiler"];
            con.Close();

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " insert into bilgiler (ID , Ad, Soyad, KullanıcıAdı, Sıfre)values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + " ' , '" + textBox4.Text + " ' , '" + textBox5.Text + "' )";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("başaralı şekilde kayıt olunmuştur");


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
