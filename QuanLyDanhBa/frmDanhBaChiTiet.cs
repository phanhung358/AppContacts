using QuanLyDanhBa.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhBa
{
    public partial class frmDanhBaChiTiet : Form
    {
        DanhBa danhBa;
        public frmDanhBaChiTiet(DanhBa danhBa)
        {
            InitializeComponent();
            this.danhBa = danhBa;
            if(danhBa == null)
            {
                this.Text = "Thêm mới danh bạ";
            }
            else
            {
                this.Text = "Chỉnh sửa danh bạ";
                txtTenGoi.Text = danhBa.TenDanhBa;
                txtEmail.Text = danhBa.Email;
                txtSoDienThoai.Text = danhBa.SoDienThoai;
                txtNhom.Text = danhBa.TenNhom;
                txtDiaChi.Text = danhBa.DiaChi;

            }
        }

        private void BtnDongY_Click(object sender, EventArgs e)
        {
            var f = new frmDanhBa();
            if(danhBa == null)
            {
                //Tạo mới
                danhBa = new DanhBa();
                danhBa.MaDanhBa = Guid.NewGuid().ToString();
                danhBa.TenDanhBa = txtTenGoi.Text;
                danhBa.Email = txtEmail.Text;
                danhBa.SoDienThoai = txtSoDienThoai.Text;
                danhBa.TenNhom = txtNhom.Text;
                danhBa.DiaChi = txtDiaChi.Text;
                DanhBa.Add(Path.pathDataDanhBa, danhBa);
                f.Refresh();
            }
            else
            {
                //Sửa
                danhBa.TenDanhBa = txtTenGoi.Text;
                danhBa.Email = txtEmail.Text;
                danhBa.SoDienThoai = txtSoDienThoai.Text;
                danhBa.TenNhom = txtNhom.Text;
                danhBa.DiaChi = txtDiaChi.Text;
                DanhBa.Update(Path.pathDataDanhBa, danhBa);
                f.Refresh();
            }
        }
    }
}
