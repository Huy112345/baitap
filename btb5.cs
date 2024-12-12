using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battapbuoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic; // Toggle Italic
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        private void gfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa nội dung RichTextBox
            richText.Clear();

            // Đặt Font và Size mặc định
            comboBoxFont.SelectedItem = "Tahoma";
            comboBoxSize.SelectedItem = 14;
            richText.Font = new Font("Tahoma", 14);

        }

        private void lưuNộiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Lưu nội dung RichTextBox
                richText.SaveFile(filePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo");
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            // Thêm các Font chữ vào ComboBox Font
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }

            // Thêm các kích thước chữ vào ComboBox Size
            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            comboBoxSize.Items.AddRange(fontSizes.Cast<object>().ToArray());

            // Thiết lập giá trị mặc định
            comboBoxFont.SelectedItem = "Tahoma";
            comboBoxSize.SelectedItem = 14;

            // Thiết lập Font mặc định cho RichTextBox
            richText.Font = new Font("Tahoma", 14);
        }

        private void mởTệpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Mở tệp văn bản
                if (filePath.EndsWith(".rtf"))
                {
                    richText.LoadFile(filePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.Text = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold; // Toggle Bold
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline; // Toggle Underline
            richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        private void comboBoxFont_Click(object sender, EventArgs e)
        {
            string selectedFont = comboBoxFont.SelectedItem.ToString();
            float currentSize = richText.SelectionFont.Size;

            richText.SelectionFont = new Font(selectedFont, currentSize);
        }

        private void comboBoxSize_Click(object sender, EventArgs e)
        {
            string selectedFont = richText.SelectionFont.FontFamily.Name;
            float selectedSize = float.Parse(comboBoxSize.SelectedItem.ToString());

            richText.SelectionFont = new Font(selectedFont, selectedSize);
        }
    }
    }


