using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listview.View = View.Details;
        }


        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string ho = txtlastname.Text;
            string tenDem = txtfirstname.Text;
            string ten = txtphone.Text;

            // Tạo một Item mới và thêm vào ListView
            ListViewItem item = new ListViewItem(ho);
            item.SubItems.Add(tenDem);
            item.SubItems.Add(ten);
            listview.Items.Add(item);

            // Xóa text trong các TextBox sau khi thêm
            txtlastname.Clear();
            txtfirstname.Clear();
            txtphone.Clear();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (listview.SelectedItems.Count > 0)
            {
                // Xóa item đã chọn
                listview.Items.RemoveAt(listview.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listview.SelectedItems.Count > 0)
            {
                // Lấy thông tin của dòng đã chọn
                ListViewItem item = listview.SelectedItems[0];
                string ho = item.SubItems[0].Text;
                string tenDem = item.SubItems[1].Text;
                string ten = item.SubItems[2].Text;

                // Hiển thị thông tin trong các TextBox để sửa
                txtlastname.Text = ho;
                txtfirstname.Text = tenDem;
                txtphone.Text = ten;

                // Xóa item cũ khỏi ListView
                listview.Items.RemoveAt(listview.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
            }
        }

    }
}
