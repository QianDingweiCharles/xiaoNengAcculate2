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
    public partial class geoImage : Form
    {
        public geoImage()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.spatialReso_fuWidth = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[0].Value.ToString());
            p.spatialReso_tiaoDai = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[1].Value.ToString());
            p.spatialReso_flatDingwei = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[2].Value.ToString());
            p.fuWidth_tiaoDai = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[3].Value.ToString());
            p.fuWidth_flatDingwei = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[4].Value.ToString());
            p.tiaoDai_flatDingwei = Convert.ToDouble(geoImagedataGrid.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            geoImagedataGrid.Rows[0].Cells[0].Value = "2";//
            geoImagedataGrid.Rows[0].Cells[1].Value = "3";
            geoImagedataGrid.Rows[0].Cells[2].Value = "5";
            geoImagedataGrid.Rows[0].Cells[3].Value = "1";
            geoImagedataGrid.Rows[0].Cells[4].Value = "4";
            geoImagedataGrid.Rows[0].Cells[5].Value = "3";//

        }
    }
}
