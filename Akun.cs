using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectRP
{
    class Akun
    {
        public static string  sjeniskel = "",tempnama = "";
        public static int susia = 0;
        public void pengguna(string nama, string tgl, string jeniskel, int usia, string alamat, string pekerjaan)
        {
            Model m = new Model();
            tempnama = nama;
            sjeniskel = jeniskel;
            susia = usia;
            m.penderita(nama, tgl, jeniskel, usia, alamat, pekerjaan);
        }
        public void nambahhasilkedatabase()
        {
            Model m = new Model();
            m.tambahPenyakit(Fungsi.penyakit,tempnama);
        }
    }
}
