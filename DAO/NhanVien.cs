using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVL.DAO
{
    internal class NhanVien
    {
        private string _ma;
        private string _ten;
        private string _gioitinh;
        private string _ngaysinh;
        private string _diachi;
        private string _sdt;

        public NhanVien(string ma, string ten, string gioitinh, string ngaysinh, string diachi, string sdt)
        {
            _ma = ma;
            _ten = ten;
            _gioitinh = gioitinh;
            _ngaysinh = ngaysinh;
            _diachi = diachi;
            _sdt = sdt;
        }

        public NhanVien(DataRow row)
        {
            Ma = row["MaNV"].ToString();
            Ten = row["TenNV"].ToString();
            Gioitinh = row["GioiTinh"].ToString();
            Ngaysinh = row["NgaySinh"].ToString();
            Diachi = row["DiaChi"].ToString();
            Sdt = row["SDT"].ToString();
        }

        public string Ma { get => _ma; set => _ma = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public string Ngaysinh { get => _ngaysinh; set => _ngaysinh = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Sdt { get => _sdt; set => _sdt = value; }
    }
}
