using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Drawing;
using System.ComponentModel;

namespace projectRP
{
    class Model:Sql
    {
        string queri;        
        public void penderita(string nama, string tgl, string jeniskel, int usia, string alamat, string pekerjaan)
        {          
            koneksi.Open();
            queri = "insert into penderita (kode_penderita,nama,tgl_lahir,jenis_kelamin,usia,alamat,pekerjaan,kode_penyakit) value('PS001','" + nama + "','" + tgl + "','" + jeniskel + "','" + usia + "','" + alamat + "','" + pekerjaan + "','')";
            command = new MySqlCommand(queri, koneksi);
            command.ExecuteNonQuery();            
            koneksi.Close();
        }
        public void tambahPenyakit(string kode, string nama)
        {
            koneksi.Open();
            queri = "update penderita set kode_penyakit = '" + kode + "' where nama = '" + nama + "' ";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            koneksi.Close();
        }
        public void penyakit()
        {
            koneksi.Open();
            queri = "SELECT * from penyakit";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Fungsi.kelas.Add(reader.GetString("kode_penyakit"));
            }
            koneksi.Close();
        }
        public string namapenyakit(string kode)
        {
            koneksi.Open();
            string nama = "";
            queri = "SELECT * from penyakit where kode_penyakit = '"+kode+"'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nama = reader.GetString("nama_penyakit");
            }
            koneksi.Close();
            return nama;
        }
        public double prior(string kode)
        {
            double kelas = 0, total = 0, hasil = 0;            
            koneksi.Open();
            queri = "SELECT * from penyakit where kode_penyakit = '"+kode+"'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                kelas = int.Parse(reader.GetString("jumlah"));                
            }             
            koneksi.Close();

            koneksi.Open();
            queri = "SELECT sum(jumlah) as total from penyakit";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                total = int.Parse(reader.GetString("total"));
            }
            koneksi.Close();
            hasil = kelas/total;
            return hasil;
        }
        public double likelihood(string kodekel, string kodegej )
        {
            double fitur = 0, kelas = 0, hasil = 0;
            string kode2 = "";
            koneksi.Open();
            queri = "SELECT * from basis_pengetahuan where kode_penyakit = '" + kodekel + "' and kode_gejala = '" + kodegej + "'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                fitur = int.Parse(reader.GetString("jumlah"));                
            }
            koneksi.Close();

            koneksi.Open();
            queri = "SELECT * from penyakit where kode_penyakit = '"+kodekel+"'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                kelas = int.Parse(reader.GetString("jumlah"));
            }
            koneksi.Close();
            hasil = fitur / kelas;
            return hasil;
        }
        public int jumlahgejalatiapkelas(string kode)
        {
            int jumlah = 0;
            koneksi.Open();
            queri = "SELECT * from basis_pengetahuan where kode_penyakit = '" + kode + "'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Fungsi.gejaladidatabasetiapkelas[jumlah] = reader.GetString("kode_gejala");
                jumlah++;
                //Fungsi.gejaladidatabasetiapkelas.Add(reader.GetString("kode_gejala"));                
            }
            koneksi.Close();
            return jumlah;
        }       
        public void pgejala(FlowLayoutPanel fl)
        {
            koneksi.Open();            
            queri = "SELECT * from gejala";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            while (reader.Read())
            {                
                string gej = reader.GetString("nama_gejala");
                string kode = reader.GetString("kode_gejala");
                Fungsi.cbgejala.Add(check(gej, kode));
                fl.Controls.Add(panelcheck(gej,kode));
            }
            koneksi.Close();
        }
        public Panel panelcheck(string gj, string kd)
        {
            Panel p = new Panel();
            p.BackColor = System.Drawing.Color.LightSteelBlue;
            p.Controls.Add(check(gj, kd));
            p.Location = new System.Drawing.Point(3, 3);
            p.Size = new System.Drawing.Size(175, 26);
            p.TabIndex = 4;            
            return p;
        }
        
        public CheckBox check(string gejala, string kode)
        {
            CheckBox c = new CheckBox();
            c.AutoSize = true;
            c.Location = new System.Drawing.Point(3, 3);
            c.Name = kode;            
            c.Size = new System.Drawing.Size(90, 17);
            c.TabIndex = 0;
            c.Text = gejala;
            c.UseVisualStyleBackColor = true;
            c.CheckedChanged += new System.EventHandler(hasilcheckterpilih);
            return c;
        }
        public void hasilcheckterpilih(object sender, EventArgs e)
        {
            CheckBox checki = (CheckBox)sender;
            if (checki.Checked)
            {
                Fungsi.hasilterpilih2.Add(checki.Name);
            } else {
                Fungsi.hasilterpilih2.Remove(checki.Name);
            }
            
        }
        public void isidatapenderita(DataGridView dt)
        {
            koneksi.Open();
            queri = "SELECT * from penderita join penyakit on penderita.kode_penyakit = penyakit.kode_penyakit";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("Nama", typeof(string));
            data.Columns.Add("Jenis Kelamin", typeof(string));
            data.Columns.Add("Usia", typeof(string));
            data.Columns.Add("Alamat", typeof(string));
            data.Columns.Add("Pekerjaan", typeof(string));
            data.Columns.Add("Penyakit", typeof(string));

            while (reader.Read())
            {
                object[] tmp = new object[6];
                tmp[0] = reader[1];
                tmp[1] = reader[3];
                tmp[2] = reader[4];
                tmp[3] = reader[5];
                tmp[4] = reader[6];
                tmp[5] = reader[9];
                data.Rows.Add(tmp);
            }
            dt.DataSource = data;
            koneksi.Close();
        }
        public void caripenderita(DataGridView dt, string cari)
        {
            koneksi.Open();
            queri = "select * from penderita join penyakit on penderita.kode_penyakit = penyakit.kode_penyakit " +
                "where nama = '" + cari + "' or jenis_kelamin = '" + cari +"' or usia = '" + cari + 
                "'or alamat = '" + cari + "'or pekerjaan = '" + cari + "'";
            command = new MySqlCommand(queri, koneksi);
            reader = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("Nama", typeof(string));
            data.Columns.Add("Jenis Kelamin", typeof(string));
            data.Columns.Add("Usia", typeof(string));
            data.Columns.Add("Alamat", typeof(string));
            data.Columns.Add("Pekerjaan", typeof(string));
            data.Columns.Add("Penyakit", typeof(string));

            while (reader.Read())
            {
                object[] tmp = new object[6];
                tmp[0] = reader[1];
                tmp[1] = reader[3];
                tmp[2] = reader[4];
                tmp[3] = reader[5];
                tmp[4] = reader[6];
                tmp[5] = reader[9];
                data.Rows.Add(tmp);
            }
            dt.DataSource = data;
            koneksi.Close();
        }
    }
}