using ajanda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ajanda
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            lbl_Tarih.Text = DateTime.Now.ToString("dd.MM.yyyy"); 

            

            Notlari_Getir();
        }



        private void btn_ekle_Click(object sender, EventArgs e)
        {
            new Not_Ekle() { }.ShowDialog();
        }

        void Notlari_Getir()
        {
            flowLayoutPanel1.Controls.Clear();

            DataTable dt = Cls.SQLConnectionClass.Table("select not_RECno, not_Baslik, not_Icerik from NOTLAR" +
                " where not_Tarih >= '" + Convert.ToDateTime(lbl_Tarih.Text).ToString("yyyyMMdd") + "' + ' 00:00:00'   " +
                " and not_Tarih <= '" + Convert.ToDateTime(lbl_Tarih.Text).ToString("yyyyMMdd") + "' + ' 23:59:59' ");




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NotGoster not = new NotGoster();
                not.lbl_Baslik.Text = dt.Rows[i]["not_Baslik"].ToString();
                not.rtxt_icerk.Text = dt.Rows[i]["not_Icerik"].ToString();
                not.lbl_id.Text = dt.Rows[i]["not_RECno"].ToString();
                flowLayoutPanel1.Controls.Add(not);
            }






        }

        private void btn_sonraki_Click(object sender, EventArgs e)
        {
            lbl_Tarih.Text = Convert.ToDateTime(lbl_Tarih.Text).AddDays(1).ToString("dd.MM.yyyy");
            Notlari_Getir();
        }

        private void btn_onceki_Click(object sender, EventArgs e)
        {
            lbl_Tarih.Text = Convert.ToDateTime(lbl_Tarih.Text).AddDays(-1).ToString("dd.MM.yyyy");
            Notlari_Getir();
        }

        private void btn_tarihe_git_Click(object sender, EventArgs e)
        {
            Tarihe_Git fr = new Tarihe_Git();
            fr.ShowDialog();
            if (fr.Devam == 1)
            {
                lbl_Tarih.Text = fr.Tarih.ToString("dd.MM.yyyy");
                Notlari_Getir();
            }

        }
    }
}
