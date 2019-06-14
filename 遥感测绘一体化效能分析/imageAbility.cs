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
    public partial class imageAbility : Form
    {
        public imageAbility()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiaoNengPerformance p = (xiaoNengPerformance)this.Owner;
            p.radiationImage_geoImage = Convert.ToDouble(imageAbilitydataGrid.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            imageAbilitydataGrid.Rows[0].Cells[0].Value = "1";//
        }
        }
}
