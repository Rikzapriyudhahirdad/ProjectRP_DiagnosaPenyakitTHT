using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectRP
{
    public partial class Diagnosa : Form
    {
        public Diagnosa()
        {
            InitializeComponent();
        }

        private void Diagnosa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fungsi f = new Fungsi();
            Akun akun = new Akun();
            f.hasilmemilih();
            //Model m = new Model();
            //m.jumlahgejalatiapkelas("P1");
            //double a = f.nilaiprior("otitis media serosa");
            //double b = f.nilailikelihood("G4");
            //f.hasilcheckterpilih();
            //MessageBox.Show(Fungsi.cbgejala[0].CheckState.ToString());
            //MessageBox.Show(f.nilaiprior("P1").ToString() + "\n"
            //    + f.nilaiprior("P2").ToString() + "\n"
            //    + f.nilaiprior("P3").ToString() + "\n"
            //    + f.nilaiprior("P4").ToString() + "\n"
            //    + f.nilaiprior("P5").ToString() + "\n"
            //    + f.nilaiprior("P6").ToString() + "\n"
            //    + f.nilaiprior("P7").ToString());
            //MessageBox.Show(Fungsi.hasilterpilih2[0].ToString() + "\n"
            //    + Fungsi.hasilterpilih2[1].ToString() + "\n" 
            //    + Fungsi.hasilterpilih2[2].ToString() + "\n"                  
            //    + Fungsi.hasilterpilih2.Count.ToString());
            //MessageBox.Show(f.nilailikelihood("P1", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P1", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P1", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P2", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P2", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P2", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P3", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P3", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P3", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P4", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P4", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P4", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P5", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P5", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P5", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P6", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P6", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P6", "G15").ToString() + "\n"
            //    + f.nilailikelihood("P7", "G4").ToString() + "\n"
            //    + f.nilailikelihood("P7", "G6").ToString() + "\n"
            //    + f.nilailikelihood("P7", "G15").ToString());
            //MessageBox.Show(m.jumlahgejalatiapkelas("P1").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P2").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P3").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P4").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P5").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P6").ToString()+"\n"
            //    + m.jumlahgejalatiapkelas("P7").ToString()+"\n");
            //MessageBox.Show(Fungsi.hasilterpilih2[0].ToString()+"\n"
            //    + Fungsi.hasilterpilih2[1].ToString() + "\n"
            //    + Fungsi.hasilterpilih2[2].ToString());
            MessageBox.Show(f.hitung().ToString()+"\n"+f.Npenyakit(Fungsi.penyakit).ToString());
            //MessageBox.Show(Fungsi.gejaladidatabasetiapkelas[0].ToString()+"\n"
            //    + Fungsi.gejaladidatabasetiapkelas[1].ToString() + "\n" 
            //    + Fungsi.gejaladidatabasetiapkelas[2].ToString() + "\n" 
            //    + Fungsi.gejaladidatabasetiapkelas[3].ToString() + "\n"                                 
            //    + Fungsi.gejaladidatabasetiapkelas[4].ToString());      
            if (f.nilai0()==0){                
            }
            else
            {
                akun.nambahhasilkedatabase();
                hasil h = new hasil();                
                this.Hide();
                h.Show();
            }            
        }

        private void Diagnosa_Load(object sender, EventArgs e)
        {
            Fungsi fungsi = new Fungsi();
            fungsi.gejala(flowLayoutPanel1);
        }
    }
}
