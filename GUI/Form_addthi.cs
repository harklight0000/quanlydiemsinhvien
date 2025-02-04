using quanlydiemsinhvien.BUS;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlydiemsinhvien.GUI
{
    
    public partial class Form_addthi : Form
    {
        //DTO_lop _lop;
        //int lanthi;
        List<DTO_mon> list_mon = BUS_mon.GetInstance.GetAll();
        List<DTO_nganh> list_nganh = BUS_nganh.GetInstance.GetAll();
        List<DTO_lop> list_lop = BUS_lop.GetInstance.GetAll();
        List<DTO_khoa> list_khoa = BUS_khoa.GetInstance.GetAll();
        List<DTO_nganh> list_filteredNganh;
        List<DTO_mon> list_filterdedMon;
        List<DTO_lop> list_filteredLop;
        DTO_thi thi = new DTO_thi();
        DTO_viewThi v_thi;
        DTO_nganh selectedNganh;
        DTO_mon SelectedMon;
        DTO_lop SelectedLop;

        string type; // add1 add2 edit1 edit2
        //add
      
        //edit
        public Form_addthi( string _type, DTO_viewThi _thi)
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            if(_thi != null) { v_thi = _thi; }
            type = _type;
        }



        private void Form_addbaithi_Load(object sender, EventArgs e)
        {
            List<hinhthuc> list_hinhthuc = new List<hinhthuc>();
            list_hinhthuc.Add(new hinhthuc() { _hinhthuc = "Lý thuyết" });
            list_hinhthuc.Add(new hinhthuc() { _hinhthuc = "Thực hành" });
            helper.LoadComboBox(comboBox_hinhthuc, list_hinhthuc, "_hinhthuc", "_hinhthuc");
            if (type == "edit2")
            {
                panel6.Hide();
                groupBox1.Text = $"Bài thi lần 2 (sinh viên chưa đạt điểm < 5)";
                DTO_mon mon = list_mon.Where(y => y.Mamonhoc == v_thi.Mamonhoc).FirstOrDefault();
               
                DTO_nganh nganh = list_nganh.Where(y => y.Id == mon.Id_nganhhoc).FirstOrDefault();
                DTO_khoa khoa = list_khoa.Where(y => y.Id == nganh.Id_khoahoc).FirstOrDefault();
                comboBox_khoa.Enabled = false;
                comboBox_khoa.Text = khoa.Tenkhoa;

                comboBox_nganh.Enabled = false;
                comboBox_nganh.Text = nganh.Tennganhhoc;



                comboBox_mon.Enabled = false;
                comboBox_mon.Text = mon.Tenmonhoc;

                dateTimePicker_ngaythi.Value = v_thi.Ngaythi;
            

                comboBox_hinhthuc.Enabled = false;
                comboBox_hinhthuc.Text = v_thi.Hinhthuc;

                button1.Text = "Cập nhật";
                button2.Text = "Xóa";
                button3.Text = "In báo cáo";

            }
            if (type == "edit1")
            {
                groupBox1.Text = $"Bài thi lần 1";
                DTO_mon mon = list_mon.Where(y => y.Mamonhoc == v_thi.Mamonhoc).FirstOrDefault();
                DTO_lop lop = list_lop.Where(y => y.Id == v_thi.Id_lophoc).FirstOrDefault();
                DTO_nganh nganh = list_nganh.Where(y => y.Id == mon.Id_nganhhoc).FirstOrDefault();
                DTO_khoa khoa = list_khoa.Where(y => y.Id == nganh.Id_khoahoc).FirstOrDefault();

                comboBox_khoa.Enabled = false;
                comboBox_khoa.Text = khoa.Tenkhoa;

                comboBox_nganh.Enabled = false;
                comboBox_nganh.Text = nganh.Tennganhhoc;



                comboBox_mon.Enabled = false;
                comboBox_mon.Text = mon.Tenmonhoc;

                dateTimePicker_ngaythi.Value = v_thi.Ngaythi;
                comboBox_lop.Enabled = false;
                comboBox_lop.Text = lop.Tenlop;

                comboBox_hinhthuc.Enabled = false;
                comboBox_hinhthuc.Text = v_thi.Hinhthuc;

                button1.Text = "Cập nhật";
                button2.Text = "Xóa";
                button3.Text = "In báo cáo";
            }
            if(type == "add1")
            {
                groupBox1.Text = $"Thêm bài thi lần 1";
                helper.LoadComboBox(comboBox_khoa, list_khoa, "tenkhoa", "id");
                button1.Hide();
                button2.Text = "Thêm";
                button3.Hide();
            }
            if (type == "add2")
            {
                groupBox1.Text = $"Thêm bài thi lần 2 (sinh viên chưa đạt điểm < 5)";
                helper.LoadComboBox(comboBox_khoa, list_khoa, "tenkhoa", "id");
                panel6.Hide();
                button1.Hide();
                button2.Text = "Thêm";
                button3.Hide();
            }

           
        }

        

        private void GetInput()
        {
            if (type == "add1" || type == "add2")
            {
            selectedNganh = (DTO_nganh)comboBox_nganh.SelectedItem;
            SelectedLop = (DTO_lop)comboBox_lop.SelectedItem;
            SelectedMon = (DTO_mon)comboBox_mon.SelectedItem;

            thi.Hinhthuc = comboBox_hinhthuc.SelectedValue.ToString();
            thi.Ngaythi = dateTimePicker_ngaythi.Value;
            thi.Mamonhoc = SelectedMon.Mamonhoc;
            thi.Id_lophoc = SelectedLop.Id;
            }
            else if(type == "edit1" || type == "edit2")
            {
                thi.Id = v_thi.Id;
                thi.Hinhthuc = v_thi.Hinhthuc;
                thi.Mamonhoc = v_thi.Mamonhoc;
                thi.Id_lophoc = v_thi.Id_lophoc;
                thi.Ngaythi = dateTimePicker_ngaythi.Value;
                MessageBox.Show(thi.Hinhthuc + thi.Mamonhoc + thi.Lanthi + thi.Ngaythi);
            }

           
        }

        private void comboBox_khoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            list_filteredNganh = list_nganh.Where(x => x.Id_khoahoc == (int)comboBox_khoa.SelectedValue).ToList();
            helper.LoadComboBox(comboBox_nganh, list_filteredNganh, "tennganhhoc", "id");
            comboBox_mon.DataSource = null;
            comboBox_lop.DataSource = null;
        }
        
        private void comboBox_nganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNganh = (DTO_nganh)comboBox_nganh.SelectedItem;
            list_filteredLop = list_lop.Where(x => x.Id_nganhhoc == selectedNganh.Id).ToList();
            helper.LoadComboBox(comboBox_lop, list_filteredLop, "tenlop", "id");

            list_filterdedMon = list_mon.Where(x => x.Id_nganhhoc == selectedNganh.Id).ToList();
            helper.LoadComboBox(comboBox_mon, list_filterdedMon, "tenmonhoc", "mamonhoc");
        }
        //edit 
        //USP_InsertThiLan2 @i_mamonhoc NVARCHAR(100),  @i_hinhthuc NVARCHAR(100),  @i_ngaythi DATE
        private void button1_Click(object sender, EventArgs e)
        {
            GetInput();
            if(type == "edit1" || type == "edit2")
            {
                if (BUS_thi.GetInstance.Edit(thi)) { MessageBox.Show(helper.MsgEditSuccess); }
                //else { MessageBox.Show(helper.MsgExecuteErr); }
            }
            if(type == "edit2")
            {
                MessageBox.Show(BUS_thi.GetInstance.InsertThilan2_x(thi));
                //if (BUS_thi.GetInstance.InsertThilan2(thi)) { MessageBox.Show("Cập nhật danh sách sinh viên viên thi lần 2"); }
                //else { MessageBox.Show(helper.MsgExecuteErr); }

            }
            this.Close();
        }
        //add or del
        private void button2_Click(object sender, EventArgs e)
        {
            GetInput();
            if(type == "add1")
            {
                if (BUS_thi.GetInstance.InsertThilan1(thi)) { MessageBox.Show(helper.MsgAddSuccess); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
                this.Close();
            }
            if(type == "add2")
            {
                if (BUS_thi.GetInstance.InsertThilan2(thi)) { MessageBox.Show(helper.MsgAddSuccess); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
                this.Close();
            }
            if (type == "edit1" || type == "edit2")
            {
                if (BUS_thi.GetInstance.Delete(thi)) { MessageBox.Show(helper.MsgDelSuccess); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
                this.Close();
            }
        }
        //in bao cao
        private void button3_Click(object sender, EventArgs e)
        {
            List<DTO_viewThi> v = new List<DTO_viewThi>();
            v.Add(v_thi);
            List<DTO_viewKetqua> list_viewKetqua = BUS_view.GetInstance.GetAllViewKetqua(v[0]);
            if(type == "edit1")
            {
                helper.ShowFormDialog(this, new Form_rpThi1(v , list_viewKetqua));
            }
            if (type == "edit2")
            {
                helper.ShowFormDialog(this, new Form_rpThi2(v, list_viewKetqua));
            }
        }
    }
    
}
