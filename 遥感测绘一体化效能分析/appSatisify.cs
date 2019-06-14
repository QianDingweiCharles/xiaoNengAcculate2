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
    public partial class appSatisify : Form
    {
        public appSatisify()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.targetDetection_physisObservation = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[0].Value.ToString());
            p.targetDetection_threeDimensional = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[1].Value.ToString());
            p.targetDetection_dynamic = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[2].Value.ToString());
            p.physisObservation_threeDimensional = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[3].Value.ToString());
            p.physisObservation_dynamic = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[4].Value.ToString());
            p.threeDimensional_dynamic = Convert.ToDouble(appSatisfydataGrid.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            appSatisfydataGrid.Rows[0].Cells[0].Value = "2";//
            appSatisfydataGrid.Rows[0].Cells[1].Value = "3";
            appSatisfydataGrid.Rows[0].Cells[2].Value = "4";
            appSatisfydataGrid.Rows[0].Cells[3].Value = "1";
            appSatisfydataGrid.Rows[0].Cells[4].Value = "3";
            appSatisfydataGrid.Rows[0].Cells[5].Value = "4";//
            
        }
    }
}
