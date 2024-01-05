using NGVL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVL.DAO
{
    internal class DAO_NhanVien
    {
        private static DAO_NhanVien _instance;

        public DAO_NhanVien()
        {
        }

        internal static DAO_NhanVien Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_NhanVien();
                }
                return _instance;
            }
        }

        //Doc NV
        public List<NhanVien> Doc_NV()
        {
            List<NhanVien> lstNV = new List<NhanVien>();
            DataTable dataTable = CSDL.Instance.TruyVan("EXEC READ_NV");

            foreach (DataRow row in dataTable.Rows)
            {
                NhanVien nv = new NhanVien(row);
                lstNV.Add(nv);
            }
            return lstNV;
        }

        //Them NV
        public void Them_NV(NhanVien nv)
        {
            object[] parameters = new object[] { nv.Ma, nv.Ten, nv.Gioitinh, nv.Ngaysinh, nv.Diachi, nv.Sdt };
            CSDL.Instance.ThucThi("EXEC INSERT_NV @MaNV, @TenNV, @GioiTinh, @NgaySinh, @DiaChi, @SDT", parameters);
        }

        //Sua NV
        public void Sua_NV(NhanVien nv)
        {
            object[] parameters = new object[] { nv.Ma, nv.Ten, nv.Gioitinh, nv.Ngaysinh, nv.Diachi, nv.Sdt };
            CSDL.Instance.ThucThi("EXEC UPDATE_NV @MaNV , @TenNV , @GioiTinh , @NgaySinh , @DiaChi , @SDT", parameters);
        }

        //Xoa NV
        public void Xoa_NV(string MaNV)
        {
            object[] parameters = new object[] { MaNV };
            CSDL.Instance.ThucThi("EXEC DELETE_NV @MaNV", parameters);
        }

        //Tim Kiem NV
        public DataTable TimKiem_NV(string Key)
        {
            object[] parameters = new object[] { Key};
            DataTable dataTable = CSDL.Instance.TruyVan("EXEC SEARCH_NV @Key", parameters);
            return dataTable;
        }
    }
}
