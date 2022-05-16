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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("lütfen boş geçmeyiniz");
            }
            else if (textBox1.Text == "admin" && textBox2.Text == "1256" && textBox3.Text == label3.Text)
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();               
            }
            else
            {
                String KullanıcıAdı = textBox1.Text;
                String Sıfre = textBox2.Text;
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bilgiler1.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select *from bilgiler where KullanıcıAdı='" + textBox1.Text + "' AND Sıfre=" + textBox2.Text + "";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Form3 frm = new Form3();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre yanlış");
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            string harfler = "ABC1ÇDE4546F0GĞHIİ0JKLM4N7OÖPR778S5654674684TUÜ547VYZ52abcçdefgğhı9ijklmno9öp5rsş5tuü87vy6z";
            string uret = "";
            for (int i = 0; i < 4; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            label3.Text = uret;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "göster";
            }
        }
    }
}
