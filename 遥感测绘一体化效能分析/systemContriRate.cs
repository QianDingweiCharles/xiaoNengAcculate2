using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 遥感测绘一体化效能分析
{
    public partial class systemContriRate : Form
    {
        public systemContriRate()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.equipmentPerfom_appPerform = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[0].Value.ToString());
            p.equipmentPerfom_taskPerfom = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[1].Value.ToString());
            p.appPerform_taskPerfom = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            systemContriDataGrid.Rows[0].Cells[0].Value = "2";//
            systemContriDataGrid.Rows[0].Cells[1].Value = "3";
            systemContriDataGrid.Rows[0].Cells[2].Value = "4";


        }
    }
}
