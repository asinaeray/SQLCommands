using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLcommands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=DESKTOP-49IJTPL;Initial Catalog=commands;Integrated Security=True");
        private void eklebtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT into tablokullanici(Ad,Soyad,tc,telefon,cinsiyet) values (@Ad,@Soyad,@tc,@telefon,@cinsiyet)",bagla);
            komut.Parameters.AddWithValue("@Ad", textBox1.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@tc", textBox3.Text);
            komut.Parameters.AddWithValue("@telefon", textBox4.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedIndex);
            bagla.Open();
            komut.ExecuteNonQuery();
            bagla.Close();
            listele();
            temizle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            comboBox1.Items.Add("Erkek");
            comboBox1.Items.Add("Kız");
        }

        private void listele()
        {
            bagla.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tablokullanici",bagla);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bagla.Close();

        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
        }
       
        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tablokullanici set Ad=@Ad, Soyad=@Soyad, tc=@tc, telefon=@telefon, cinsiyet=@cinsiyet where id=@id",bagla);
            komut.Parameters.AddWithValue("@Ad", textBox1.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@tc", textBox3.Text);
            komut.Parameters.AddWithValue("@telefon", textBox4.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedIndex);
            komut.Parameters.AddWithValue("@id", textBox5.Text);
            bagla.Open();
            komut.ExecuteNonQuery();
            bagla.Close();
            listele();
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void deletbtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM tablokullanici WHERE id=@id",bagla);
            komut.Parameters.AddWithValue("@id",textBox5.Text);
            bagla.Open();
            komut.ExecuteNonQuery();
            bagla.Close();
            listele();
            temizle();
        }
    }
}
