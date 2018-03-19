using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;

namespace projectRP
{
    class Fungsi
    {
        public static List<CheckBox> cbgejala = new List<CheckBox>();
        public static List<string> kelas = new List<string>();        
        public static List<string> hasilterpilih2 = new List<string>();
        public static string [] gejaladidatabasetiapkelas = new string [10];
        public static string penyakit;
        double temp3 = 0;
        public void gejala(FlowLayoutPanel flp)
        {
            Model m = new Model();
            m.pgejala(flp);
            m.penyakit();
            //hasilterpilih2.Add("G2");
        }
        public void dataG(DataGridView dtg)
        {
            Model model = new Model();
            model.isidatapenderita(dtg);
        }
        public void hasilmemilih()
        {
            for (int i = 0; i < cbgejala.Count; i++)
            {
                if (cbgejala[i].Checked)
                {
                    hasilterpilih2.Add(cbgejala[i].Name.ToString());
                }
            }
        }
        
        public double nilaiprior(string kode)
        {
            Model model = new Model();            
            return model.prior(kode);
        }

        public double nilailikelihood(string kodekel, string kodegej)
        {
            Model m = new Model();
            return m.likelihood(kodekel,kodegej);
        }

        public string Npenyakit(string kode)
        {
            Model m = new Model();
            return m.namapenyakit(kode);
        }

        public double hitung()
        {
            Model mod = new Model();
            double temp1 = 0;            
            double hasil = 0;
            Boolean tanda,tanda2;
            penyakit = "xxx";
           
                for (int i = 0; i < kelas.Count; i++)//kelas
                {
                    double temp2 = nilaiprior(kelas[i].ToString());
                    tanda = false;
                    temp1 = 1;
                    for (int j = 0; j < hasilterpilih2.Count; j++) //pilihan
                    {
                        tanda2 = false;                    
                        for (int k = 0; k < mod.jumlahgejalatiapkelas(kelas[i].ToString()); k++) //gejaladidatabase
                        {
                            if (hasilterpilih2[j].ToString()==gejaladidatabasetiapkelas[k].ToString())
                            {
                                tanda = true;
                                tanda2 = true;
                                temp1 *= nilailikelihood(kelas[i].ToString(), hasilterpilih2[j]);
                                break;

                            }                        
                        }
                        if (tanda2 == false)
                        {
                            temp2 *= 0;
                        }
                    }
                    if (tanda==true)
                    {
                        hasil = temp2 * temp1;
                    }
                    if (hasil>temp3)
                    {
                        temp3 = hasil;
                        penyakit = kelas[i];
                    }
                }
        
            if (temp3==0)
            {
                for (int l = 0; l < kelas.Count; l++)//kelas
                {                    
                    tanda = false;
                    temp1 = 0;                    
                    for (int m = 0; m < hasilterpilih2.Count; m++) //pilihan
                    {                        
                        for (int n = 0; n < mod.jumlahgejalatiapkelas(kelas[l].ToString()); n++) //gejaladidatabase
                        {
                            if (hasilterpilih2[m].ToString() == gejaladidatabasetiapkelas[n].ToString())
                            {
                                tanda = true;                                
                                temp1 += 1;
                                break;
                            }
                        }                        
                    }
                    if (tanda == true)
                    {
                        hasil = temp1;
                    }
                    if (hasil > temp3)
                    {
                        temp3 = hasil;
                        penyakit = kelas[l];
                    }
                }
            }
            return temp3; 
        }
        public double nilai0()
        {
            if (temp3==0)
            {
                MessageBox.Show("Anda tidak memasukkan gejala");                
            }
            return temp3;
        }
        public string saran(string namapenyakit)
        {
            string sar = "";
            Boolean tanda;
            if (namapenyakit == "Otitis Media Serosa")
            {
                tanda = false;
                for (int i = 0; i < hasilterpilih2.Count; i++)
                {                    
                    if (hasilterpilih2[i]=="Badan Panas")
                    {
                        tanda = true;
                        sar = "- Dibawa ke dokter";
                    }
                }
                if (tanda==false)
                {
                    sar = "- Telinga jangan di korek"+"\n"+"- Sembuh sendiri";
                }
            }
            if (namapenyakit == "Polip Hidung")
            {
                sar = "- Dibawa ke dokter "+"\n"+"- Operasi "+"\n"+"- Jangan minum yang dingin";
               
            }
            if (namapenyakit == "Faringitis Akut")
            {
                sar = "- Hindari makan yang terlalu panas, dingin, keras dan besar "+"\n"+"- Istirahat berbicara "+"\n"+ "- Dibawa ke dokter";
            }
            if (namapenyakit == "Infeksi Leher Dalam")
            {               
                sar = "- Hindari makan yang terlalu panas, dingin, keras dan besar "+"\n"+"- Dibawa ke dokter";
            }
            if (namapenyakit == "Abses Retrofaring")
            {                                  
                sar = "- Istirahat berbicara "+"\n"+"- Hindari makan yang terlalu panas, dingin, keras dan besar "+"\n"+"- Dibawa ke dokter";            
            }
            if (namapenyakit == "Karsinoma Nasofaring")
            {
                sar = "- Dibawa ke dokter";
            }
            if (namapenyakit == "Serumen Obsturan")
            {
                tanda = false;
                for (int i = 0; i < hasilterpilih2.Count; i++)
                {
                    if (hasilterpilih2[i] == "Pendengaran Menurun")
                    {
                        tanda = true;
                        sar = "- Dibawa ke dokter";
                    }
                }
                if (tanda == false)
                {
                    sar = "- Telinga jangan di korek "+"\n"+"- Menghentikan kegiatan renang ";
                }
            }
            return sar;
        }

        public void caripen(DataGridView dt, string cari)
        {
            Model m = new Model();
            m.caripenderita(dt, cari);           
        }
        
    }
}
