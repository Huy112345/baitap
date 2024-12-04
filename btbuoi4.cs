using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitapbuoi4
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnthem_Click(object sender, EventArgs e)
        {

            NhanVien formNhanVien = new NhanVien();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                // Lấy dữ liệu từ Form 2 và thêm vào ListView
                string msnv = formNhanVien.MSNV;
                string tenNV = formNhanVien.TenNV;
                string luongCB = formNhanVien.LuongCB.ToString();
                lvNhanVien.Items.Add(new ListViewItem(new[] { msnv, tenNV, luongCB }));
            }


        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvNhanVien.SelectedItems[0];
                NhanVien formNhanVien = new NhanVien(
                    selectedItem.SubItems[0].Text, // MSNV
                    selectedItem.SubItems[1].Text, // Tên NV
                    decimal.Parse(selectedItem.SubItems[2].Text) // Lương CB
                );

                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật lại dữ liệu trong ListView
                    selectedItem.SubItems[1].Text = formNhanVien.TenNV;
                    selectedItem.SubItems[2].Text = formNhanVien.LuongCB.ToString();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một nhân viên để sửa!", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
    {
        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            lvNhanVien.Items.Remove(lvNhanVien.SelectedItems[0]);
        }
    }
    else
    {
        MessageBox.Show("Hãy chọn một nhân viên để xóa!", "Thông báo");
    }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
