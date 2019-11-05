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
    public partial class frmDanhBa : Form
    {
        private string pathDataDanhBa;
        private string pathDataNhom;
        private List<DanhBa> listDanhBa;
        private List<Nhom> nhomDanhBa;

        public frmDanhBa()
        {
            InitializeComponent();
            pathDataDanhBa = Application.StartupPath + @"\Data\DanhBa.data";
            pathDataNhom = Application.StartupPath + @"\Data\Nhom.data";
            dgvDanhBa.AutoGenerateColumns = false;
            dgvNhom.AutoGenerateColumns = false;
            nhomDanhBa = Nhom.GetListFromFile(pathDataNhom);
            bdsNhom.DataSource = nhomDanhBa;
            dgvNhom.DataSource = bdsNhom;
        }

        private void DgvNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                listDanhBa = DanhBa.GetListFromFile(pathDataDanhBa, dgvNhom.CurrentRow.Cells[0].Value.ToString());
                bdsDanhBa.DataSource = listDanhBa;
                dgvDanhBa.DataSource = bdsDanhBa;
            }
            catch (Exception tt)
            {
                _ = tt.StackTrace;
            }
        }

        private void DgvDanhBa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTenGoi.Text = dgvDanhBa.CurrentRow.Cells[0].Value.ToString();
            lblEmail.Text = dgvDanhBa.CurrentRow.Cells[1].Value.ToString();
            lblSoDienThoai.Text = dgvDanhBa.CurrentRow.Cells[2].Value.ToString();
            lblDiaChi.Text = dgvDanhBa.CurrentRow.Cells[3].Value.ToString();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            var f = new frmDanhBaChiTiet(null);
            f.ShowDialog();
        }

        private void DgvDanhBa_DoubleClick(object sender, EventArgs e)
        {
            var danhBa = bdsDanhBa.Current as DanhBa;
            if(danhBa != null)
            {
                var f = new frmDanhBaChiTiet(danhBa);
                f.ShowDialog();
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có thực sự muốn xóa liên hệ này.",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                var danhBa = bdsDanhBa.Current as DanhBa;
                bdsDanhBa.RemoveCurrent();
                DanhBa.Remove(Path.pathDataDanhBa, danhBa);
                MessageBox.Show(
                     "Đã xóa liên hệ có tên là: " + danhBa.TenDanhBa,
                     "Thông báo",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                     );
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có thực sự muốn xóa nhóm liên hệ này.",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                var nhom = bdsNhom.Current as Nhom;
                bdsNhom.RemoveCurrent();
                Nhom.Remove(Path.pathDataNhom, nhom);
                MessageBox.Show(
                     "Đã xóa nhóm liên hệ có tên là: " + nhom.TenNhom,
                     "Thông báo",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                     );
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new frmNhom_ChiTiet(null);
            f.ShowDialog();
        }

        private void DgvNhom_DoubleClick(object sender, EventArgs e)
        {
            var nhom = bdsNhom.Current as Nhom;
            if (nhom != null)
            {
                var f = new frmNhom_ChiTiet(nhom);
                f.ShowDialog();
            }
        }
    }
}
