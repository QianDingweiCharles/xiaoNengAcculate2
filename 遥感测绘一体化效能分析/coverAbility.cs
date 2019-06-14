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
    public partial class coverAbility : Form
    {
        public coverAbility()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.coverRange_coverNum = Convert.ToDouble(coverAbilitydataGrid1.Rows[0].Cells[0].Value.ToString());
            p.coverRange_xianlingImageOverlap= Convert.ToDouble(coverAbilitydataGrid1.Rows[0].Cells[1].Value.ToString());
            p.coverRange_manyViewImageNum = Convert.ToDouble(coverAbilitydataGrid1.Rows[0].Cells[2].Value.ToString());
            p.coverRange_danWeiTargetNum = Convert.ToDouble(coverAbilitydataGrid1.Rows[0].Cells[3].Value.ToString());
            p.coverNum_xianlingImageOverlap = Convert.ToDouble(coverAbilitydataGrid1.Rows[0].Cells[4].Value.ToString());

            p.coverNum_manyViewImageNum = Convert.ToDouble(coverAbilitydataGrid2.Rows[0].Cells[0].Value.ToString());
            p.coverNum_danWeiTargetNum = Convert.ToDouble(coverAbilitydataGrid2.Rows[0].Cells[1].Value.ToString());
            p.xianlingImageOverlap_manyViewImageNum = Convert.ToDouble(coverAbilitydataGrid2.Rows[0].Cells[2].Value.ToString());
            p.xianlingImageOverlap_danWeiTargetNum = Convert.ToDouble(coverAbilitydataGrid2.Rows[0].Cells[3].Value.ToString());
            p.manyViewImageNum_danWeiTargetNum = Convert.ToDouble(coverAbilitydataGrid2.Rows[0].Cells[4].Value.ToString());


            this.Close();
        }
        private void dataInit()
        {
            coverAbilitydataGrid1.Rows[0].Cells[0].Value = "2";//
            coverAbilitydataGrid1.Rows[0].Cells[1].Value = "3";
            coverAbilitydataGrid1.Rows[0].Cells[2].Value = "4";
            coverAbilitydataGrid1.Rows[0].Cells[3].Value = "1";
            coverAbilitydataGrid1.Rows[0].Cells[4].Value = "3";

            coverAbilitydataGrid2.Rows[0].Cells[0].Value = "4";//
            coverAbilitydataGrid2.Rows[0].Cells[1].Value = "3";
            coverAbilitydataGrid2.Rows[0].Cells[2].Value = "5";
            coverAbilitydataGrid2.Rows[0].Cells[3].Value = "1";
            coverAbilitydataGrid2.Rows[0].Cells[4].Value = "2";
        }
    }
}
