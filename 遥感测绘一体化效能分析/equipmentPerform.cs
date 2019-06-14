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
    public partial class equipmentPerform : Form
    {
        public equipmentPerform()
        {
            InitializeComponent();
            dataInit();
        }
        private void dataInit()
        {
            equipmentPerformdataGrid.Rows[0].Cells[0].Value = "4";//
            equipmentPerformdataGrid.Rows[0].Cells[1].Value = "5";
            equipmentPerformdataGrid.Rows[0].Cells[2].Value = "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.taskRespon_obserCoverRange = Convert.ToDouble(equipmentPerformdataGrid.Rows[0].Cells[0].Value.ToString());
            p.taskRespon_starResouUse = Convert.ToDouble(equipmentPerformdataGrid.Rows[0].Cells[1].Value.ToString());
            p.obserCoverRange_starResouUse = Convert.ToDouble(equipmentPerformdataGrid.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
    }
}
