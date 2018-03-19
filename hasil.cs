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
    public partial class hasil : Form
    {
        public hasil()
        {
            InitializeComponent();
        }

        private void hasil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void hasil_Load(object sender, EventArgs e)
        {
            Fungsi f = new Fungsi();            
            textBox1.Text = Akun.tempnama;
            textBox2.Text = Akun.susia.ToString();
            textBox3.Text = Akun.sjeniskel;
            textBox4.Text = f.Npenyakit(Fungsi.penyakit);
            richTextBox1.Text = f.saran(f.Npenyakit(Fungsi.penyakit));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fungsi.hasilterpilih2.Clear();
            Fungsi fungsi = new Fungsi();
            //            beranda b = new beranda();
            Diagnosa d = new Diagnosa();
            this.Hide();
            d.Show();
        }
    }
}
