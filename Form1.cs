using btb5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btb5
{
    public partial class Form1 : Form
    {
        private List<Faculty> listFacultys = new List<Faculty>(); // Biến toàn cục
        private StudentContextDB context = new StudentContextDB(); // Ngữ cảnh CSDL
        private int ID = 1; // Biến ID dùng chung trong lớp
        public Form1()
        {
            InitializeComponent();
            LoadData();

            //  StudentContextDB context = new StudentContextDB();
            List<Student> listStudent = context.Student.ToList();
        Student db = context.Student.FirstOrDefault(p => p.StudentID == ID);
        Student newStudent = new Student()
        {
            StudentID = 9,
            FullName = "test insert",
            AverageScore = 100
        };
        
        context.Student.Add(newStudent);
           // context.SaveChanges();
            Student dbUpdate = context.Student.FirstOrDefault(p => p.StudentID == ID);

    if (dbUpdate != null)
    {
    dbUpdate.FullName = "Update FullName";
    context.SaveChanges(); 
    }
    Student dbDelete = context.Student.FirstOrDefault(p => p.StudentID == ID);
    if (dbDelete != null)
{
    context.Student.Remove(dbDelete);
    context.SaveChanges(); }}
        private void LoadData()
        {
            try
            {
                listFacultys = context.Faculty.ToList();
                FillFacultyCombobox(listFacultys);
                BindGrid(context.Student.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbFaculty.DataSource = listFacultys;

            this.cmbFaculty.DisplayMember = "FacultyName";

            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void FillFacultyCombobox(List<Faculty> listFaculty)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> listStudent)

        {
            dgvStudent.Rows.Clear();  // Đảm bảo xoá hết dòng cũ

            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Faculty?.FacultyName;  // Thêm dấu hỏi chấm để tránh lỗi null reference
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị StudentID từ TextBox và chuyển sang kiểu int
                if (!int.TryParse(txtStudentID.Text.Trim(), out int studentID))
                {
                    MessageBox.Show("MSSV phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fullName = txtFullName.Text.Trim();
                string facultyID = cmbFaculty.SelectedValue?.ToString();

                // Parse giá trị từ txtAverageScore.Text
                if (!float.TryParse(txtAverageScore.Text, out float averageScore))
                {
                    MessageBox.Show("Vui lòng nhập điểm trung bình hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng sinh viên mới
                Student newStudent = new Student
                {
                    StudentID = studentID,  // Gán giá trị StudentID (kiểu int)
                    FullName = fullName,
                    FacultyID = int.Parse(facultyID),
                    // Chuyển đổi float sang decimal? (nullable decimal)
                    AverageScore = (decimal?)Convert.ToDecimal(averageScore)
                };

                // Thêm sinh viên vào cơ sở dữ liệu
                context.Student.Add(newStudent);
                context.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách hiển thị
                BindGrid(context.Student.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtStudentID.Text.Trim(); // Lấy MSSV từ TextBox
                string fullName = txtFullName.Text.Trim();
                string facultyID = cmbFaculty.SelectedValue?.ToString();

                // Parse giá trị từ txtAverageScore.Text
                if (!float.TryParse(txtAverageScore.Text, out float averageScore))
                {
                    MessageBox.Show("Vui lòng nhập điểm trung bình hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm sinh viên theo MSSV
                Student dbStudent = context.Student.FirstOrDefault(s => s.StudentID == int.Parse(studentID));

                if (dbStudent == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi float sang decimal? (nullable decimal)
                dbStudent.FullName = fullName;
                dbStudent.FacultyID = int.Parse(facultyID);
                dbStudent.AverageScore = (decimal?)Convert.ToDecimal(averageScore);  // Chuyển đổi tại đây

                context.SaveChanges();

                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách hiển thị
                BindGrid(context.Student.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtStudentID.Text.Trim(); // Lấy MSSV từ TextBox
                Student dbStudent = context.Student.FirstOrDefault(s => s.StudentID == int.Parse(studentID));
                if (dbStudent == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                context.Student.Remove(dbStudent);
                context.SaveChanges();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.Student.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

