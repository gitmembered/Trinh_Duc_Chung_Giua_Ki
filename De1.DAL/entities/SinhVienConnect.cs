using System;
using System.Data;
using System.Data.SqlClient;

namespace De1.DAL
{
    public class SinhVienConnect
    {
    
        private string connStr = @"Data Source=.;Initial Catalog=QuanLySV;Integrated Security=True";

        // ====== Lấy danh sách Sinh viên ======
        public DataTable GetAllSinhVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaSV, HoTenSV, MaLop, NgaySinh FROM SinhVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ====== Lấy danh sách Lớp ======
        public DataTable GetAllLop()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM Lop";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ====== Thêm Sinh viên ======
        public void InsertSinhVien(string ma, string ten, string lop, DateTime ns)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO SinhVien (MaSV, HoTenSV, MaLop, NgaySinh) VALUES (@MaSV, @HoTenSV, @MaLop, @NgaySinh)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSV", ma);
                cmd.Parameters.AddWithValue("@HoTenSV", ten);
                cmd.Parameters.AddWithValue("@MaLop", lop);
                cmd.Parameters.AddWithValue("@NgaySinh", ns);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ====== Sửa Sinh viên ======
        public void UpdateSinhVien(string ma, string ten, string lop, DateTime ns)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE SinhVien SET HoTenSV=@HoTenSV, MaLop=@MaLop, NgaySinh=@NgaySinh WHERE MaSV=@MaSV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSV", ma);
                cmd.Parameters.AddWithValue("@HoTenSV", ten);
                cmd.Parameters.AddWithValue("@MaLop", lop);
                cmd.Parameters.AddWithValue("@NgaySinh", ns);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ====== Xóa Sinh viên ======
        public void DeleteSinhVien(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSV", ma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
