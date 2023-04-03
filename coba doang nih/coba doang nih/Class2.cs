using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coba_doang_nih
{
    internal class Class2
    {
       
        public string stockproduct { get; set; }
        public string idcatagory { get; set; }
        public string namacatagory { get; set; }
        public string Idproduct { get; set; }
        public string namaproduct { get; set; }
        public string hargaproduct { get; set; }
        public Class2(string namaproduct, string hargaproduct, string stockproduct, string namacatagory)
        {
            
            this.stockproduct = stockproduct;
            this.namacatagory = namacatagory;
            this.namaproduct = namaproduct;
            this.hargaproduct = hargaproduct;
        }
    }
}
