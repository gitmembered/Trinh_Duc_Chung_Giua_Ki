using System.Data;
using De1.DAL;

namespace De1.BUS
{
    public class LopService
    {
        SinhVienConnect dal = new SinhVienConnect();
        public DataTable LayDSLop() => dal.GetAllLop();
    }
}
