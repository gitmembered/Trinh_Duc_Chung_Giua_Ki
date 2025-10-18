using System;
using System.Data;
using De1.DAL;

namespace De1.BUS
{
    public class SinhvienService
    {
        SinhVienConnect dal = new SinhVienConnect();

        public DataTable LayDSSinhVien() => dal.GetAllSinhVien();
        public void Them(string ma, string ten, string lop, DateTime ns) => dal.InsertSinhVien(ma, ten, lop, ns);
        public void Sua(string ma, string ten, string lop, DateTime ns) => dal.UpdateSinhVien(ma, ten, lop, ns);
        public void Xoa(string ma) => dal.DeleteSinhVien(ma);
    }
}
