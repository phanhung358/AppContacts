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
    public partial class frmNhom_ChiTiet : Form
    {
        Nhom nhom;
        public frmNhom_ChiTiet(Nhom nhom)
        {
            InitializeComponent();
            this.nhom = nhom;
            if(nhom == null)
            {
                this.Text = "Thêm mới nhóm danh bạ.";
            }
            else
            {
                this.Text = "Chỉnh sửa nhóm danh bạ.";
                txtTenNhom.Text = nhom.TenNhom;
            }
        }

        private void BtnDongY_Click(object sender, EventArgs e)
        {
            var f = new frmDanhBa();
            if(nhom == null)
            {
                //Tạo mới
                nhom.MaNhom = Guid.NewGuid().ToString();
                nhom.TenNhom = txtTenNhom.Text;
                Nhom.Add(Path.pathDataNhom, nhom);
                f.Refresh();
            }
            else
            {
                //Sửa
                nhom.TenNhom = txtTenNhom.Text;
                Nhom.Add(Path.pathDataNhom, nhom);
                f.Refresh();
            }
        }
    }
}
