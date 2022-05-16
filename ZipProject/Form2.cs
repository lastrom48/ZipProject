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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        DataSet dset;
        private void listele()
        {
            baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bilgiler1.accdb");
            adaptor = new OleDbDataAdapter("Select *From bilgiler", baglanti);
            dset = new DataSet();
            baglanti.Open();
            adaptor.Fill(dset, "bilgiler");
            dataGridView1.DataSource = dset.Tables["bilgiler"];
            baglanti.Close();
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = " insert into bilgiler (ID , Ad, Soyad, KullanıcıAdı, Sıfre)values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + " ' , '" + textBox4.Text + " ' , '" + textBox5.Text + "' )";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("başaralı şekilde kayıt olunmuştur");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from bilgiler where ID=" + textBox7.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("başaralı şekilde veri silinmiştir");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update bilgiler set ID='" + textBox1.Text + "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',KullanıcıAdı='" + textBox4.Text + "',Sıfre='" + textBox5.Text + "' where ID=" + textBox7.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("başaralı şekilde veri güncellenmiştir");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bilgiler1.accdb");
            adaptor = new OleDbDataAdapter("Select * from bilgiler where ID like '%" + textBox6.Text + "%'", baglanti);
            dset = new DataSet();
            baglanti.Open();
            adaptor.Fill(dset, "bilgiler");
            dataGridView1.DataSource = dset.Tables["bilgiler"];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
