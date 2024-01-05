using NGVL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVL.GUI
{
    public partial class FormNhanVien : Form
    {
        //
        List<NhanVien> lstNV = new List<NhanVien>();
        ListViewItem itemSelected;

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            cobGioiTinh.SelectedIndex = 1;
            LoadListView();
        }

        private void LoadListView()
        {
            lvNhanVien.Items.Clear();
            lstNV.Clear();

            lstNV = DAO_NhanVien.Instance.Doc_NV();

            foreach (var nv in lstNV)
            {
                ListViewItem item = new ListViewItem(nv.Ma);
                lvNhanVien.Items.Add(item);

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, nv.Ten);
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem(item, nv.Gioitinh);
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem(item, nv.Ngaysinh);
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem(item, nv.Diachi);
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem(item, nv.Sdt);
                item.SubItems.Add(subItem);
            }

        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoi();

            if (lvNhanVien.SelectedItems.Count == 1)
            {
                itemSelected = lvNhanVien.SelectedItems[0];
                txtMa.Text = itemSelected.SubItems[0].Text;
                txtTen.Text = itemSelected.SubItems[1].Text;

                if (itemSelected.SubItems[2].Text.Equals("NAM"))
                {
                    cobGioiTinh.SelectedIndex = 0;
                }
                else cobGioiTinh.SelectedIndex = 1;

                dtpNgaySinh.Text = itemSelected.SubItems[3].Text;

                txtDiaChi.Text = itemSelected.SubItems[4].Text;
                txtSDT.Text = itemSelected.SubItems[5].Text;
            }
            else LamMoi();
        }

        private void LamMoi()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            cobGioiTinh.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem Tra
            if (txtMa.Text.Length == 0 || txtTen.Text.Length == 0)
            {
                MessageBox.Show("Nhap Thieu Thong Tin");
                return;
            }

            foreach (ListViewItem item in lvNhanVien.Items)
            {

                if (item.SubItems[0].Text.Equals(txtMa.Text))
                {
                    MessageBox.Show("Trung Ma Nhan Vien");
                    return;
                }

                if (item.SubItems[5].Text.Equals(txtSDT.Text))
                {
                    MessageBox.Show("Trung SDT");
                    return;
                }
            }

            //Them
            NhanVien nv;
            nv = new NhanVien(txtMa.Text, txtTen.Text, cobGioiTinh.SelectedItem.ToString(), dtpNgaySinh.Text, txtDiaChi.Text, txtSDT.Text);

            DAO_NhanVien.Instance.Them_NV(nv);
            MessageBox.Show("Them Thanh Cong");

            LoadListView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //kiem tra
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                if (!itemSelected.SubItems[0].Text.Equals(txtMa.Text))
                {
                    MessageBox.Show("Khong Sua Ma NV");
                    return;
                }

                if (txtTen.Text.Length == 0)
                {
                    MessageBox.Show("Nhap thieu thong tin");
                    return;
                }

                if (!itemSelected.SubItems[5].Text.Equals(txtSDT.Text))
                {
                    foreach (ListViewItem item in lvNhanVien.Items)
                    {
                        if (item.SubItems[5].Text.Equals(txtSDT.Text))
                        {
                            MessageBox.Show("Trung SDT");
                            return;
                        }
                    }
                }

                //Sua
                NhanVien nv;
                nv = new NhanVien(txtMa.Text, txtTen.Text, cobGioiTinh.SelectedItem.ToString(), dtpNgaySinh.Text, txtDiaChi.Text, txtSDT.Text);

                DAO_NhanVien.Instance.Sua_NV(nv);
                MessageBox.Show("Sua Thanh Cong");

                LoadListView();
            }
            else
                MessageBox.Show("Chua Chon NV");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //kiem tra
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                DAO_NhanVien.Instance.Xoa_NV(itemSelected.SubItems[0].Text);
                MessageBox.Show("Xoa Thanh Cong");
                LoadListView();
            }
            else
                MessageBox.Show("Chua Chon NV");
        }

        //Chi nhan phim so
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
