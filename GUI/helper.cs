using quanlydiemsinhvien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlydiemsinhvien.GUI
{
    public class helper
    {
        public static string MsgAddSuccess = "Thêm thành công";
        public static string MsgEditSuccess = "Cập nhật thành công";
        public static string MsgDelSuccess = "Xóa thành công";
        public static string MsgExecuteErr = "Lỗi không xác định";
        public static string MsgXoaSinhVien = "Đã xóa sinh viên và toàn bộ kết quả liên quan";
        public static string MsgTrungTenLop = "tên lớp không được trùng";
        public static string MsgXoaBaiThi = "Đã xóa bài thi và toàn bộ két quả liên quan";
        public static void ConfigureForm(Form x)
        {
            x.MinimizeBox = false;
            x.MaximizeBox = false;
            x.FormBorderStyle = FormBorderStyle.FixedSingle;
            x.Text = "Quản lý điểm sinh viên";
            x.StartPosition = FormStartPosition.CenterScreen;
        }
        public static void LoadTabcontrol(TabPage _tabpage, Form _form, string _tabpage_text)
        {
            _form.TopLevel = false;
            _form.FormBorderStyle = FormBorderStyle.None;
            _form.Dock = DockStyle.Fill;
            _tabpage.Controls.Clear();
            _tabpage.Controls.Add(_form);
            _tabpage.Text = _tabpage_text;
            _form.Show();
        }
        public static bool XacNhan()
        {
            DialogResult x = MessageBox.Show("chắc chắn muốn xóa mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes) { return true; }
            else { return false; }
        }

        public static void ShowForm(Form x, Form y)
        {
            x.Hide();
            y.ShowDialog();
            x.Show();
        }
        public static void ShowFormDialog(Form x, Form y)
        {
            y.ShowDialog();
            x.Show();
        }
        public static void LoadComboBox<T>(ComboBox comboBox, List<T> data, string displayMember, string valueMember)
        {
            comboBox.DataSource = data;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ConfigureDataGridView(DataGridView dataGridView, List<dgv_ColInfo> columns)
        {
            dataGridView.Columns.Clear();
            foreach (var colInfo in columns)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = colInfo.DataPropertyName,
                    HeaderText = colInfo.HeaderText,
                    ReadOnly = colInfo.ReadOnly,
                    Width = colInfo.Width
                    
                };

                dataGridView.Columns.Add(column);
            }
            //dataGridView.Width = ;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
    public class dgv_ColInfo
    {
        public string DataPropertyName { get; set; }
        public string HeaderText { get; set; }
        public bool ReadOnly { get; set; } = false;
        public int Width { get; set; } = 100;
    };
    public class hinhthuc
    {
        public string _hinhthuc { get; set; }
    }
}
