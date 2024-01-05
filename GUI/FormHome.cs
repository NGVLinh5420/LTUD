using NGVL.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVL
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
            }


            FormNhanVien form = new FormNhanVien();
            form.MdiParent = this;
            form.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
            }

            FormReport form = new FormReport();
            form.MdiParent = this;
            form.Show();
        }
    }
}
