using NGVL.DAO;
using NGVL.Report;
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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DAO_NhanVien.Instance.TimKiem_NV(txtKey.Text);

            CrystalReport crystalReport = new CrystalReport();
            crystalReport.SetDataSource(dataTable);

            crystalReportViewer.ReportSource = crystalReport;

        }
    }
}
