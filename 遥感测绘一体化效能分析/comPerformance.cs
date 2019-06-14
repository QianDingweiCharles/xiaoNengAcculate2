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
    public partial class comPerformance : Form
    {
        public comPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void comPerformance_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.response_image = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[0].Value.ToString());
            p.response_cover = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[1].Value.ToString());
            p.response_appSatisify = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[2].Value.ToString());
            p.response_starLand= Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[3].Value.ToString());
            p.image_cover = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[4].Value.ToString());

            p.image_appSatisify= Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[0].Value.ToString());
            p.image_starLand = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[1].Value.ToString());
            p.cover_appSatisify= Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[2].Value.ToString());
            p.cover_starLand = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[3].Value.ToString());
            p.appSatisify_starLand= Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[4].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            comPerformancedataGrid1.Rows[0].Cells[0].Value = "1";//
            comPerformancedataGrid1.Rows[0].Cells[1].Value = "2";
            comPerformancedataGrid1.Rows[0].Cells[2].Value = "3";
            comPerformancedataGrid1.Rows[0].Cells[3].Value = "2";
            comPerformancedataGrid1.Rows[0].Cells[4].Value = "3";

            comPerformancedataGrid2.Rows[0].Cells[0].Value = "5";
            comPerformancedataGrid2.Rows[0].Cells[1].Value = "2";
            comPerformancedataGrid2.Rows[0].Cells[2].Value = "3";
            comPerformancedataGrid2.Rows[0].Cells[3].Value = "5";
            comPerformancedataGrid2.Rows[0].Cells[4].Value = "3";


        }
        private void comPerformancedataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
