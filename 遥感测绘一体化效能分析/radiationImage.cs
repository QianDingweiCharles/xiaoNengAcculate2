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
    public partial class radiationImage : Form
    {
        public radiationImage()
        {
            InitializeComponent();
            dataInit();
        }
        private void dataInit()
        {
            radImagedataGrid.Rows[0].Cells[0].Value = "3";
            radImagedataGrid.Rows[0].Cells[1].Value = "2";
            radImagedataGrid.Rows[0].Cells[2].Value = "1";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.MTF_dynamicRange = Convert.ToDouble(radImagedataGrid.Rows[0].Cells[0].Value.ToString());
            p.MTF_sinal = Convert.ToDouble(radImagedataGrid.Rows[0].Cells[1].Value.ToString());
            p.dynamicRange_sinal = Convert.ToDouble(radImagedataGrid.Rows[0].Cells[2].Value.ToString());
            this.Close();



        }
    }
}
