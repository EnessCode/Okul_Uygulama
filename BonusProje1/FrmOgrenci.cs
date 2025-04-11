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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-UHPV4QF\\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from tblkulupler", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbOgrkulup.DisplayMember = "KULUPAD";
            cmbOgrkulup.ValueMember = "KULUPID";
            cmbOgrkulup.DataSource = dt;
            baglantı.Close();
        }
        
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {  
            if (rbErkek.Checked == true) 
            {
                c = "ERKEK";
            }
            if(rbKız.Checked == true)
            {
                c = "KIZ";
            }

            ds.OgrenciEkle(txtOgrAd.Text,txtOgrSoyad.Text,byte.Parse(cmbOgrkulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbOgrkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtOgrID.Text=cmbOgrkulup.SelectedValue.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrID.Text));
            MessageBox.Show("Öğrenci başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGüncelle(txtOgrAd.Text, txtOgrSoyad.Text, byte.Parse(cmbOgrkulup.SelectedValue.ToString()), c, int.Parse(txtOgrID.Text));
        }

        private void rbKız_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKız.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void rbErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbErkek.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
