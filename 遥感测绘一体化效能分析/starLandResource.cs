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
    public partial class starLandResource : Form
    {
        public starLandResource()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.starResource_starEnergy = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[0].Value.ToString());
            p.starResource_shuChuanResource = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[1].Value.ToString());
            p.starResource_ceKong = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[2].Value.ToString());
            p.starEnergy_shuChuanResource = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[3].Value.ToString());
            p.starEnergy_ceKong = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[4].Value.ToString());
            p.shuChuanResource_ceKong = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            starLanddataGrid.Rows[0].Cells[0].Value = "2";//
            starLanddataGrid.Rows[0].Cells[1].Value = "5";
            starLanddataGrid.Rows[0].Cells[2].Value = "4";
            starLanddataGrid.Rows[0].Cells[3].Value = "3";
            starLanddataGrid.Rows[0].Cells[4].Value = "3";
            starLanddataGrid.Rows[0].Cells[5].Value = "1";//

        }
    }
}
