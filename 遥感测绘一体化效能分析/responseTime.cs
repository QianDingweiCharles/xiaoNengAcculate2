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
    public partial class responseTime : Form
    {
        public responseTime()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.responseDelayTime_perTimeGuanceTask = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[0].Value.ToString());
            p.responseDelayTime_RevisiteCycle = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[1].Value.ToString());
            p.responseDelayTime_minTime = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[2].Value.ToString());
            p.responseDelayTime_maxTime = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[3].Value.ToString());
            p.responseDelayTime_neiborMinTime = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[4].Value.ToString());
            p.responseDelayTime_neiborMaxTime = Convert.ToDouble(respTimedataGrid1.Rows[0].Cells[5].Value.ToString());

            p.responseDelayTime_oneResponseTime= Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[0].Value.ToString());
            p.responseDelayTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[1].Value.ToString());
            p.perTimeGuanceTask_RevisiteCycle = Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[2].Value.ToString());
            p.perTimeGuanceTask_minTime = Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[3].Value.ToString());
            p.perTimeGuanceTask_maxTime = Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[4].Value.ToString());
            p.perTimeGuanceTask_neiborMinTime = Convert.ToDouble(respTimedataGrid2.Rows[0].Cells[5].Value.ToString());

            p.perTimeGuanceTask_neiborMaxTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[0].Value.ToString());
            p.perTimeGuanceTask_oneResponseTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[1].Value.ToString());
            p.perTimeGuanceTask_oneGuanceTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[2].Value.ToString());
            p.RevisiteCycle_minTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[3].Value.ToString());
            p.RevisiteCycle_maxTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[4].Value.ToString());
            p.RevisiteCycle_neiborMinTime = Convert.ToDouble(respTimedataGrid3.Rows[0].Cells[5].Value.ToString());

            p.RevisiteCycle_neiborMaxTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[0].Value.ToString());
            p.RevisiteCycle_oneResponseTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[1].Value.ToString());
            p.RevisiteCycle_oneGuanceTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[2].Value.ToString());
            p.minTime_maxTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[3].Value.ToString());
            p.minTime_neiborMinTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[4].Value.ToString());
            p.minTime_neiborMaxTime = Convert.ToDouble(respTimedataGrid4.Rows[0].Cells[5].Value.ToString());

            p.minTime_oneResponseTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[0].Value.ToString());
            p.minTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[1].Value.ToString());
            p.maxTime_neiborMinTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[2].Value.ToString());
            p.maxTime_neiborMaxTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[3].Value.ToString());
            p.maxTime_oneResponseTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[4].Value.ToString());
            p.maxTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid5.Rows[0].Cells[5].Value.ToString());

            p.neiborMinTime_neiborMaxTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[0].Value.ToString());
            p.neiborMinTime_oneResponseTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[1].Value.ToString());
            p.neiborMinTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[2].Value.ToString());
            p.neiborMaxTime_oneResponseTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[3].Value.ToString());
            p.neiborMaxTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[4].Value.ToString());
            p.oneResponseTime_oneGuanceTime = Convert.ToDouble(respTimedataGrid6.Rows[0].Cells[5].Value.ToString());
            this.Close();
           
        }
        private void dataInit()
        {
            respTimedataGrid1.Rows[0].Cells[0].Value = "2";//
            respTimedataGrid1.Rows[0].Cells[1].Value = "3";
            respTimedataGrid1.Rows[0].Cells[2].Value = "5";
            respTimedataGrid1.Rows[0].Cells[3].Value = "1";
            respTimedataGrid1.Rows[0].Cells[4].Value = "4";
            respTimedataGrid1.Rows[0].Cells[5].Value = "3";//

            respTimedataGrid2.Rows[0].Cells[0].Value = "4";//
            respTimedataGrid2.Rows[0].Cells[1].Value = "3";
            respTimedataGrid2.Rows[0].Cells[2].Value = "5";
            respTimedataGrid2.Rows[0].Cells[3].Value = "2";
            respTimedataGrid2.Rows[0].Cells[4].Value = "1";
            respTimedataGrid2.Rows[0].Cells[5].Value = "5";//

            respTimedataGrid3.Rows[0].Cells[0].Value = "5";//
            respTimedataGrid3.Rows[0].Cells[1].Value = "4";
            respTimedataGrid3.Rows[0].Cells[2].Value = "3";
            respTimedataGrid3.Rows[0].Cells[3].Value = "1";
            respTimedataGrid3.Rows[0].Cells[4].Value = "2";
            respTimedataGrid3.Rows[0].Cells[5].Value = "3";//

            respTimedataGrid4.Rows[0].Cells[0].Value = "1";//
            respTimedataGrid4.Rows[0].Cells[1].Value = "2";
            respTimedataGrid4.Rows[0].Cells[2].Value = "3";
            respTimedataGrid4.Rows[0].Cells[3].Value = "4";
            respTimedataGrid4.Rows[0].Cells[4].Value = "5";
            respTimedataGrid4.Rows[0].Cells[5].Value = "6";//

            respTimedataGrid5.Rows[0].Cells[0].Value = "6";//
            respTimedataGrid5.Rows[0].Cells[1].Value = "5";
            respTimedataGrid5.Rows[0].Cells[2].Value = "4";
            respTimedataGrid5.Rows[0].Cells[3].Value = "3";
            respTimedataGrid5.Rows[0].Cells[4].Value = "2";
            respTimedataGrid5.Rows[0].Cells[5].Value = "1";//

            respTimedataGrid6.Rows[0].Cells[0].Value = "5";//
            respTimedataGrid6.Rows[0].Cells[1].Value = "4";
            respTimedataGrid6.Rows[0].Cells[2].Value = "3";
            respTimedataGrid6.Rows[0].Cells[3].Value = "1";
            respTimedataGrid6.Rows[0].Cells[4].Value = "2";
            respTimedataGrid6.Rows[0].Cells[5].Value = "3";//


        }
    }
}
