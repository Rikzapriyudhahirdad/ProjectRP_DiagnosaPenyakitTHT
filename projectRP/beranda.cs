using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projectRP
{
    public partial class beranda : Form
    {
        public beranda()
        {
            InitializeComponent();
            
        }

        private void beranda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            string tgl = date.ToString("yyyy-MM-dd");
            Akun akun = new Akun();
            if (textBox1.Text=="" || numericUpDown1.Value.ToString()=="0" || richTextBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Data tidak boleh ada yang kosong");
            }
            else
            {
                akun.pengguna(textBox1.Text, tgl, comboBox1.SelectedItem.ToString(), int.Parse(numericUpDown1.Value.ToString()), richTextBox1.Text, textBox2.Text);
                Diagnosa d = new Diagnosa();
                this.Hide();
                d.Show();
            }
            
        }

        private void dataPenderitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datapenderita dp = new datapenderita();
            this.Hide();
            dp.Show();
        }
    }
}
