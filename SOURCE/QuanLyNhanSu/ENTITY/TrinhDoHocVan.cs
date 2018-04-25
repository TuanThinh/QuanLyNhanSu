using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    class TrinhDoHocVan
    {
        public string MaTDHV { get; set; }         public string TenTDHV { get; set; }         public string ChuyenNganhHoc { get; set; }                   public TrinhDoHocVan(string maTDHV, string tenTDHV, string chuyennganhhoc)         {             MaTDHV = maTDHV;             TenTDHV = tenTDHV;             ChuyenNganhHoc = chuyennganhhoc;         }
    }
}
