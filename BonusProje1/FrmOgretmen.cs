﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void btnKulupIslemleri_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void btnDersIslemleri_Click(object sender, EventArgs e)
        {
            FrmDersler fr=new FrmDersler();
            fr.Show();
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr=new FrmOgrenci();
            fr.Show();
        }

        private void btnSınavNotları_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr=new FrmSınavNotlar();
            fr.Show();
        }
    }
}
