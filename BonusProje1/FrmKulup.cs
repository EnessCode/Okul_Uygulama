using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
      
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-UHPV4QF\\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");
        void listele()
        { 
            SqlDataAdapter da=new SqlDataAdapter("Select * from TBLKULUPLER", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();     
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutekle = new SqlCommand("insert into tblkulupler (kulupad) values (@p1)", baglantı);
            komutekle.Parameters.AddWithValue("@p1",txtKulupAdı.Text);
            komutekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulup eklendi!");
            listele();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutgüncelle = new SqlCommand("update tblkulupler set kulupad=@p1 where KUlUPID=@p2", baglantı);
            komutgüncelle.Parameters.AddWithValue("@p1", txtKulupAdı.Text);
            komutgüncelle.Parameters.AddWithValue("@p2", txtKulupID.Text);
            komutgüncelle .ExecuteNonQuery();
            baglantı .Close();
            MessageBox.Show("Kulup güncellendi!");
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete from tblkulupler where KULUPID=@p1", baglantı);
            komutsil.Parameters.AddWithValue("@p1", txtKulupID.Text);
            komutsil .ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulup silindi!");
            listele();
        }
    }
}
