using System;
using System.Data;
using System.Windows.Forms;
using De1.BUS;

namespace De1
{
    public partial class frmSinhvien : Form
    {
        SinhvienService svBUS = new SinhvienService();
        LopService lopBUS = new LopService();
        bool isThem = false;

        public frmSinhvien()
        {
            InitializeComponent();
        }

        private void frmSinhvien_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadSinhVien();
            SetButton(true);
        }

        private void LoadLop()
        {
            cboLop.DataSource = lopBUS.LayDSLop();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        private void LoadSinhVien()
        {
            lvSinhvien.Items.Clear();
            DataTable dt = svBUS.LayDSSinhVien();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaSV"].ToString());
                item.SubItems.Add(row["HoTenSV"].ToString());
                item.SubItems.Add(row["MaLop"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["NgaySinh"]).ToShortDateString());
                lvSinhvien.Items.Add(item);
            }
        }

        private void lvSinhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhvien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhvien.SelectedItems[0];
                txtMaSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                cboLop.SelectedValue = item.SubItems[2].Text;
                dtNgaySinh.Value = Convert.ToDateTime(item.SubItems[3].Text);
            }
        }

        private void SetButton(bool normal)
        {
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btThoat.Enabled = normal;
            btLuu.Enabled = btKhong.Enabled = !normal;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtMaSV.Focus();
            SetButton(false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (lvSinhvien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn sinh viên cần sửa!");
                return;
            }
            isThem = false;
            SetButton(false);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhvien.SelectedItems.Count == 0) return;
            string ma = lvSinhvien.SelectedItems[0].SubItems[0].Text;
            if (MessageBox.Show("Xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                svBUS.Xoa(ma);
                LoadSinhVien();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string lop = cboLop.SelectedValue.ToString();
            DateTime ns = dtNgaySinh.Value;

            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (isThem)
                svBUS.Them(ma, ten, lop, ns);
            else
                svBUS.Sua(ma, ten, lop, ns);

            LoadSinhVien();
            SetButton(true);
        }

        private void btKhong_Click(object sender, EventArgs e)
        {
            SetButton(true);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = btTim.Text.Trim().ToLower();
            foreach (ListViewItem item in lvSinhvien.Items)
            {
                bool match = item.SubItems[1].Text.ToLower().Contains(keyword);
                item.BackColor = match ? System.Drawing.Color.LightYellow : System.Drawing.Color.White;
            }
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
