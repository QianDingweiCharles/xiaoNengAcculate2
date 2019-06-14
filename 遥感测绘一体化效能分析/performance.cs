using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Drawing.Drawing2D;

namespace 遥感测绘一体化效能分析
{
    public partial class xiaoNengPerformance : Form
    {
        public xiaoNengPerformance()
        {
            InitializeComponent();
        }
        private void xiaoNeng_Load(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());
            comboxInit();
        
        }
        //窗口最大化
        #region
        private float X;
        private float Y;
        public string str;
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }
        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            combox_ToFormResize();



        }
        #endregion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = btnFirst2.Location.X + btnFirst2.Width / 2.0;//btn1是效能分析按钮的中下点
            btn1y = btnFirst2.Location.Y + btnFirst2.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//效能分析按钮的中下点
            btn2x = btnCoverAbility2.Location.X + btnCoverAbility2.Width / 2.0;//btn2是覆盖能力上中点
            btn2y = btnCoverAbility2.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是覆盖能力上中点
            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//效能分析按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));
            g.DrawLine(pen, btnPoint1, midPoint1);
            //覆盖能力上面的中间点
            x2 = btn2x;
            y2 = y1;
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));
            g.DrawLine(pen, midPoint2, midPoint1);//连接覆盖能力上面的中间点和效能分析下面的中间点
            g.DrawLine(pen, midPoint2, btnPoint2);//连接覆盖能力上面的中间点和覆盖能力上中点；
            //成像能力上面的中间点
            x3 = btnImageAbility2.Location.X + btnImageAbility2.Width / 2.0;
            y3 = y1;
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));
            g.DrawLine(pen, midPoint3, midPoint1);

            //成像能力上中间点
            btn3x = btnImageAbility2.Location.X + btnImageAbility2.Width / 2.0;//btn2是覆盖能力上中点
            btn3y = btnImageAbility2.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));
            g.DrawLine(pen, midPoint3, btnPoint3);
            //------------------------------------------
            //应用满足度上面的中间点
            x4 = btnAppSatisfaction2.Location.X + btnAppSatisfaction2.Width / 2.0;
            y4 = y1;
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));
            g.DrawLine(pen, midPoint4, midPoint1);

            //应用满足度上中间点
            btn4x = btnAppSatisfaction2.Location.X + btnAppSatisfaction2.Width / 2.0;//btn4是应用满足度上中点
            btn4y = btnImageAbility2.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));
            g.DrawLine(pen, midPoint4, btnPoint5);
            //响应时效性
            x5 = btnRespTime2.Location.X + btnRespTime2.Width / 2.0;
            y5 = y1;
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));
            g.DrawLine(pen, midPoint5, midPoint1);

            //响应时效性上中间点
            btn5x = btnRespTime2.Location.X + btnRespTime2.Width / 2.0;//btn2是覆盖能力上中点
            btn5y = btnImageAbility2.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));
            g.DrawLine(pen, midPoint5, btnPoint6);
            //星地资源利用
            x6 = btnStartLand2.Location.X + btnStartLand2.Width / 2.0;
            y6 = y1;
            Point midPoint7 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));
            g.DrawLine(pen, midPoint7, midPoint1);

            //星地资源利用上中间点
            btn6x = btnStartLand2.Location.X + btnStartLand2.Width / 2.0;//btn6是星地资源利用上中点
            btn6y = btnStartLand2.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));
            g.DrawLine(pen, midPoint7, btnPoint7);
            //------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12;
            btn7x = btnCoverAbility2.Location.X + btnCoverAbility2.Width / 2.0;//btn1是覆盖能力按钮的中下点
            btn7y = btnCoverAbility2.Location.Y + btnCoverAbility2.Height;
            Point btnPoint8 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//覆盖能力按钮的中下点
            btn8x = btnNeiborOverlap2.Location.X + btnNeiborOverlap2.Width / 2.0;//btn8是相邻成像区域重叠度上中点
            btn8y = btnNeiborOverlap2.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//btnPoint9是相邻成像区域重叠度上中点
            x7 = btn7x;
            y7 = btn7y + (btn8y - btn7y) / 2;//覆盖能力按钮下面的中点，重点
            Point midPoint10 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));
            g.DrawLine(pen, btnPoint8, midPoint10);
            //相邻成像区域重叠度上面的中间点
            x8 = btn8x;
            y8 = y7;
            Point midPoint11 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));
            g.DrawLine(pen, midPoint10, midPoint11);//连接覆盖能力下面的中间点和相邻成像区域重叠度上面的中间点
            g.DrawLine(pen, midPoint11, btnPoint9);//相邻成像区域重叠度上中点和相邻成像区域重叠度上面的中间点
            ////覆盖区域次数上面的中间点
            x9 = btnCoverTime2.Location.X + btnCoverTime2.Width / 2.0;
            y9 = y7;
            Point midPoint12 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));
            g.DrawLine(pen, midPoint12, midPoint10);

            //覆盖区域次数上中间点
            btn9x = btnCoverTime2.Location.X + btnCoverTime2.Width / 2.0;//btn9是覆盖区域次数上中点
            btn9y = btnCoverTime2.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));
            g.DrawLine(pen, midPoint12, btnPoint10);
            //----------------------------
            //多视角成像次数
            x10 = btnManyViewTime2.Location.X + btnManyViewTime2.Width / 2.0;
            y10 = y7;
            Point midPoint13 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));
            g.DrawLine(pen, midPoint13, midPoint10);

            //多视角成像次数上中间点
            btn10x = btnManyViewTime2.Location.X + btnManyViewTime2.Width / 2.0;//btn9是覆盖区域次数上中点
            btn10y = btnManyViewTime2.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, midPoint13, btnPoint11);
            //---------------------
            //覆盖范围
            x11 = btnConverRange2.Location.X + btnConverRange2.Width / 2.0;
            y11 = y7;
            Point midPoint14 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, midPoint14, midPoint10);

            //覆盖范围上中间点
            btn11x = btnConverRange2.Location.X + btnConverRange2.Width / 2.0;//btn11是覆盖范围上中点
            btn11y = btnManyViewTime2.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));
            g.DrawLine(pen, midPoint14, btnPoint12);
            //----------------------
            //单位区域可观测目标数目
            x12 = btnPerRangeTargetNum2.Location.X + btnPerRangeTargetNum2.Width / 2.0;
            y12 = y7;
            Point midPoint15 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            g.DrawLine(pen, midPoint15, midPoint10);

            //单位区域可观测目标数目上中间点
            btn12x = btnPerRangeTargetNum2.Location.X + btnPerRangeTargetNum2.Width / 2.0;//btn11是覆盖范围上中点
            btn12y = btnPerRangeTargetNum2.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));
            g.DrawLine(pen, midPoint15, btnPoint13);
            //-------------------------------------
            double btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y, btn19x, btn19y;
            double x13, y13, x14, y14, x15, y15, x16, y16, x17, y17, x18, y18, x19, y19, x20, y20;
            btn13x = btnImageAbility2.Location.X + btnImageAbility2.Width / 2.0;//btn13是成像能力的中下点
            btn13y = btnImageAbility2.Location.Y + btnImageAbility2.Height;
            Point btnPoint14 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));//btn13是成像能力的中下点
            btn14x = btnRadiationImage2.Location.X + btnRadiationImage2.Width / 2.0;//btn14辐射成像质量上中点
            btn14y = btnRadiationImage2.Location.Y;
            Point btnPoint15 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));//btn14是辐射成像质量上中点
            x13 = btn13x;
            y13 = y7;//成像能力按钮下面的中点，重点
            Point midPoint16 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13));
            g.DrawLine(pen, btnPoint14, midPoint16);
            //辐射成像质量上面的中间点
            x14 = btn14x;
            y14 = y7;
            Point midPoint17 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14));
            g.DrawLine(pen, midPoint16, midPoint17);//连接成像能力下面的中间点和辐射成像上面的中间点
            g.DrawLine(pen, midPoint17, btnPoint15);//连接辐射成像上面的中间点和辐射成像质量上中点
            //-------------------
            //几何成像质量         
            x15 = btnGeoImage2.Location.X + btnGeoImage2.Width / 2.0;
            y15 = y7;
            Point midPoint18 = new Point(Convert.ToInt32(x15), Convert.ToInt32(y15));
            g.DrawLine(pen, midPoint16, midPoint18);
            //几何成像质量上中间点
            btn15x = btnGeoImage2.Location.X + btnGeoImage2.Width / 2.0;//btn15几何成像质量上中点
            btn15y = btnGeoImage2.Location.Y;
            Point btnPoint18 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));
            g.DrawLine(pen, midPoint18, btnPoint18);
            //---------------------------
            //应用满足度
            btn16x = btnAppSatisfaction2.Location.X + btnAppSatisfaction2.Width / 2.0;//btn16是应用满足度的中下点
            btn16y = btnAppSatisfaction2.Location.Y + btnAppSatisfaction2.Height;
            Point btnPoint19 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y));//btn16是应用满足度中下点
            btn17x = btnDynamic2.Location.X + btnDynamic2.Width / 2.0;//btn17动态监测上中点
            btn17y = btnDynamic2.Location.Y;
            Point btnPoint20 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));//btn17是动态监测上中点
            x16 = btn16x;
            y16 = y7;//应用满足度按钮下面的中点，重点
            Point midPoint21 = new Point(Convert.ToInt32(x16), Convert.ToInt32(y16));
            g.DrawLine(pen, btnPoint19, midPoint21);
            //动态监测能力上面的中间点
            x17 = btn17x;
            y17 = y7;
            Point midPoint22 = new Point(Convert.ToInt32(x17), Convert.ToInt32(y17));
            g.DrawLine(pen, midPoint22, midPoint21);//应用满足度下面的中间点和动态监测能力上面的中间点
            g.DrawLine(pen, midPoint22, btnPoint20);//连接辐射成像上面的中间点和辐射成像质量上中点
            //-------------------
            //物理特性探测能力
            x18 = btnPhysisObservation2.Location.X + btnPhysisObservation2.Width / 2.0;
            y18 = y7;
            Point midPoint23 = new Point(Convert.ToInt32(x18), Convert.ToInt32(y18));
            g.DrawLine(pen, midPoint23, midPoint21);
            //物理特性探测能力上中间点
            btn17x = btnPhysisObservation2.Location.X + btnPhysisObservation2.Width / 2.0;//btn15几何成像质量上中点
            btn17y = btnPhysisObservation2.Location.Y;
            Point btnPoint21 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));
            g.DrawLine(pen, midPoint23, btnPoint21);
            //-------------------
            //目标监测识别能力
            x19 = btnTargetDetection2.Location.X + btnTargetDetection2.Width / 2.0;
            y19 = y7;
            Point midPoint24 = new Point(Convert.ToInt32(x19), Convert.ToInt32(y19));
            g.DrawLine(pen, midPoint24, midPoint21);
            //目标识别能力上中间点
            btn18x = btnTargetDetection2.Location.X + btnTargetDetection2.Width / 2.0;//btn15几何成像质量上中点
            btn18y = btnTargetDetection2.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y));
            g.DrawLine(pen, midPoint24, btnPoint22);
            //-------------------
            //三维立体观测能力
            x20 = btnThreeDimensional2.Location.X + btnThreeDimensional2.Width / 2.0;
            y20 = y7;
            Point midPoint25 = new Point(Convert.ToInt32(x20), Convert.ToInt32(y20));
            g.DrawLine(pen, midPoint25, midPoint21);
            //目标识别能力上中间点
            btn19x = btnThreeDimensional2.Location.X + btnThreeDimensional2.Width / 2.0;//btn15几何成像质量上中点
            btn19y = btnThreeDimensional2.Location.Y;
            Point btnPoint23 = new Point(Convert.ToInt32(btn19x), Convert.ToInt32(btn19y));
            g.DrawLine(pen, midPoint25, btnPoint23);
            //---------------------------
            double btn20x, btn20y, btn21x, btn21y, btn22x, btn22y, btn23x, btn23y, btn24x, btn24y;
            double x21, y21, x22, y22, x23, y23, x24, y24, x25, y25;
            //星地资源利用
            btn20x = btnStartLand2.Location.X + btnStartLand2.Width / 2.0;//btn20是星上资源的中下点
            btn20y = btnStartLand2.Location.Y + btnStartLand2.Height;
            Point btnPoint24 = new Point(Convert.ToInt32(btn20x), Convert.ToInt32(btn20y));//btn20是星地资源中下点
            btn21x = btnStarEnergy2.Location.X + btnStarEnergy2.Width / 2.0;//btn21星上能源利用率上中点
            btn21y = btnStarEnergy2.Location.Y;
            Point btnPoint25 = new Point(Convert.ToInt32(btn21x), Convert.ToInt32(btn21y));//btn21是星上能源利用率上中点
            x21 = btn20x;
            y21 = y7;//星地资源下面的中点，重点
            Point midPoint26 = new Point(Convert.ToInt32(x21), Convert.ToInt32(y21));
            g.DrawLine(pen, btnPoint24, midPoint26);
            //星上能源利用率上面的中间点
            x22 = btn21x;
            y22 = y7;
            Point midPoint27 = new Point(Convert.ToInt32(x22), Convert.ToInt32(y22));
            g.DrawLine(pen, midPoint27, midPoint26);//星地资源下面的中点，星上能源利用率上面的中间点
            g.DrawLine(pen, midPoint27, btnPoint25);//星上能源利用率上面的中间点，星上能源利用率上中点
            //-------------------
            //数传资源
            x23 = btnShuChuanResource2.Location.X + btnShuChuanResource2.Width / 2.0;
            y23 = y7;
            Point midPoint28 = new Point(Convert.ToInt32(x23), Convert.ToInt32(y23));
            g.DrawLine(pen, midPoint26, midPoint28);
            //数传资源上中间点
            btn22x = btnShuChuanResource2.Location.X + btnShuChuanResource2.Width / 2.0;//btn22数传资源上中点
            btn22y = btnShuChuanResource2.Location.Y;
            Point btnPoint26 = new Point(Convert.ToInt32(btn22x), Convert.ToInt32(btn22y));
            g.DrawLine(pen, midPoint28, btnPoint26);
            //-------------------
            //星上资源利用率
            x24 = btnStarResource2.Location.X + btnStarResource2.Width / 2.0;
            y24 = y7;
            Point midPoint29 = new Point(Convert.ToInt32(x24), Convert.ToInt32(y24));
            g.DrawLine(pen, midPoint29, midPoint26);
            //星上资源利用率上中点
            btn23x = btnStarResource2.Location.X + btnStarResource2.Width / 2.0;//btn23星上资源利用率上中点
            btn23y = btnStarResource2.Location.Y;
            Point btnPoint27 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y));
            g.DrawLine(pen, midPoint29, btnPoint27);
            //测控资源利用率
            x25 = btnCeKong2.Location.X + btnCeKong2.Width / 2.0;
            y25 = y7;
            Point midPoint30 = new Point(Convert.ToInt32(x25), Convert.ToInt32(y25));
            g.DrawLine(pen, midPoint30, midPoint26);
            //测控资源利用率上中点
            btn24x = btnCeKong2.Location.X + btnCeKong2.Width / 2.0;//btn23星上资源利用率上中点
            btn24y = btnCeKong2.Location.Y;
            Point btnPoint28 = new Point(Convert.ToInt32(btn24x), Convert.ToInt32(btn24y));
            g.DrawLine(pen, midPoint30, btnPoint28);
            //响应时效性
            double btn25x, btn25y, btn26x, btn26y, btn27x, btn27y, btn28x, btn28y, btn29x, btn29y, btn30x, btn30y;
            double x26, y26, x27, y27, x28, y28, x29, y29, x30, y30, x31, y31;
            btn25x = btnRespTime2.Location.X + btnRespTime2.Width / 2.0;//btn25是响应时效性的中下点
            btn25y = btnRespTime2.Location.Y + btnRespTime2.Height;
            Point btnPoint29 = new Point(Convert.ToInt32(btn25x), Convert.ToInt32(btn25y));//响应时效性的中下点
            btn26x = btnNeiborMaxTime2.Location.X + btnNeiborMaxTime2.Width / 2.0;//btn26是邻近观测最大时间间隔上中点
            btn26y = btnNeiborMaxTime2.Location.Y;
            Point btnPoint30 = new Point(Convert.ToInt32(btn26x), Convert.ToInt32(btn26y));//btn26是邻近观测最大时间间隔上中点
            x26 = btn25x;
            y26 = y7;//邻近观测最大时间间隔下面的中点，重点
            Point midPoint31 = new Point(Convert.ToInt32(x26), Convert.ToInt32(y26));
            g.DrawLine(pen, btnPoint29, midPoint31);
            //邻近观测最大时间间隔上面的中间点
            x27 = btn26x;
            y27 = y7;
            Point midPoint32 = new Point(Convert.ToInt32(x27), Convert.ToInt32(y27));
            g.DrawLine(pen, midPoint31, midPoint32);//连接覆盖能力上面的中间点和效能分析下面的中间点
            g.DrawLine(pen, midPoint32, btnPoint30);//连接覆盖能力上面的中间点和覆盖能力上中点；

            //邻近观测最小间隔时长
            x28 = btnNeiborMinTime2.Location.X + btnNeiborMinTime2.Width / 2.0;
            y28 = y7;
            Point midPoint33 = new Point(Convert.ToInt32(x28), Convert.ToInt32(y28));
            g.DrawLine(pen, midPoint33, midPoint31);
            //邻近观测最小间隔时长上中点
            btn27x = btnNeiborMinTime2.Location.X + btnNeiborMinTime2.Width / 2.0;//btn23邻近观测最小间隔时长上中点
            btn27y = btnCeKong2.Location.Y;
            Point btnPoint31 = new Point(Convert.ToInt32(btn27x), Convert.ToInt32(btn27y));
            g.DrawLine(pen, midPoint33, btnPoint31);


            //最大连续监测时长
            x29 = btnMaxTime2.Location.X + btnMaxTime2.Width / 2.0;
            y29 = y7;
            Point midPoint34 = new Point(Convert.ToInt32(x29), Convert.ToInt32(y29));
            g.DrawLine(pen, midPoint34, midPoint31);
            //最大连续监测时长上中点
            btn28x = btnMaxTime2.Location.X + btnMaxTime2.Width / 2.0;
            btn28y = btnMaxTime2.Location.Y;
            Point btnPoint32 = new Point(Convert.ToInt32(btn28x), Convert.ToInt32(btn28y));
            g.DrawLine(pen, midPoint34, btnPoint32);

            //最小连续监测时长
            x30 = btnMinTime2.Location.X + btnMinTime2.Width / 2.0;
            y30 = y7;
            Point midPoint35 = new Point(Convert.ToInt32(x30), Convert.ToInt32(y30));
            g.DrawLine(pen, midPoint35, midPoint31);
            //最小连续监测时长上中点
            btn29x = btnMinTime2.Location.X + btnMinTime2.Width / 2.0;
            btn29y = btnMinTime2.Location.Y;
            Point btnPoint33 = new Point(Convert.ToInt32(btn29x), Convert.ToInt32(btn29y));
            g.DrawLine(pen, midPoint35, btnPoint33);
            //重访周期
            x31 = btnRevisiteCycle2.Location.X + btnRevisiteCycle2.Width / 2.0;
            y31 = y7;
            Point midPoint36 = new Point(Convert.ToInt32(x31), Convert.ToInt32(y31));
            g.DrawLine(pen, midPoint36, midPoint31);
            //重访周期上中点
            btn30x = btnRevisiteCycle2.Location.X + btnRevisiteCycle2.Width / 2.0;
            btn30y = btnRevisiteCycle2.Location.Y;
            Point btnPoint34 = new Point(Convert.ToInt32(btn30x), Convert.ToInt32(btn30y));
            g.DrawLine(pen, midPoint36, btnPoint34);

            double btn31x, btn31y, btn32x, btn32y, btn33x, btn33y, btn34x, btn34y, btn35x, btn35y, btn36x, btn36y;
            double x32, y32, x33, y33, x34, y34, x35, y35;

            //单次任务响应时长
            x32 = btnOneResponseTime2.Location.X + btnOneResponseTime2.Width / 2.0;
            y32 = y7;
            Point midPoint37 = new Point(Convert.ToInt32(x32), Convert.ToInt32(y32));
            g.DrawLine(pen, midPoint37, midPoint31);
            //单次任务响应时长上中点
            btn31x = btnOneResponseTime2.Location.X + btnOneResponseTime2.Width / 2.0;
            btn31y = btnOneResponseTime2.Location.Y;
            Point btnPoint35 = new Point(Convert.ToInt32(btn31x), Convert.ToInt32(btn31y));
            g.DrawLine(pen, midPoint37, btnPoint35);
            //单次连续观测时长
            x33 = btnOneGuanceTime2.Location.X + btnOneGuanceTime2.Width / 2.0;
            y33 = y7;
            Point midPoint38 = new Point(Convert.ToInt32(x33), Convert.ToInt32(y33));
            g.DrawLine(pen, midPoint38, midPoint31);
            //单次连续观测时长上中点
            btn32x = btnOneGuanceTime2.Location.X + btnOneGuanceTime2.Width / 2.0;
            btn32y = btnOneGuanceTime2.Location.Y;
            Point btnPoint36 = new Point(Convert.ToInt32(btn32x), Convert.ToInt32(btn32y));
            g.DrawLine(pen, midPoint38, btnPoint36);

            //响应延迟时间
            x34 = btnResponseDelayTime2.Location.X + btnResponseDelayTime2.Width / 2.0;
            y34 = y7;
            Point midPoint39 = new Point(Convert.ToInt32(x34), Convert.ToInt32(y34));
            g.DrawLine(pen, midPoint39, midPoint31);
            //响应延迟时间上中点
            btn33x = btnResponseDelayTime2.Location.X + btnResponseDelayTime2.Width / 2.0;
            btn33y = btnResponseDelayTime2.Location.Y;
            Point btnPoint37 = new Point(Convert.ToInt32(btn33x), Convert.ToInt32(btn33y));
            g.DrawLine(pen, midPoint39, btnPoint37);

            //单位时间可观测任务数
            x35 = btnPerTimeGuanceTask2.Location.X + btnPerTimeGuanceTask2.Width / 2.0;
            y35 = y7;
            Point midPoint40 = new Point(Convert.ToInt32(x35), Convert.ToInt32(y35));
            g.DrawLine(pen, midPoint40, midPoint31);
            //单位时间可观测任务数上中点
            btn34x = btnPerTimeGuanceTask2.Location.X + btnPerTimeGuanceTask2.Width / 2.0;
            btn34y = btnPerTimeGuanceTask2.Location.Y;
            Point btnPoint38 = new Point(Convert.ToInt32(btn34x), Convert.ToInt32(btn34y));
            g.DrawLine(pen, midPoint40, btnPoint38);

            //目标解译度
            btn35x = btnTargetDetection2.Location.X + btnTargetDetection2.Width / 2.0;
            btn35y = btnTargetDetection2.Location.Y + btnTargetDetection2.Height;
            Point btnPoint39 = new Point(Convert.ToInt32(btn35x), Convert.ToInt32(btn35y));
            btn36x = btnTargetJieyi2.Location.X + btnTargetJieyi2.Width / 2.0;
            btn36y = btnTargetJieyi2.Location.Y;
            Point btnPoint40 = new Point(Convert.ToInt32(btn36x), Convert.ToInt32(btn36y));
            g.DrawLine(pen, btnPoint39, btnPoint40);
            //-----------------------------------
            double btn37x, btn37y, btn38x, btn38y, btn39x, btn39y, btn40x, btn40y;
            double x36, y36, x37, y37, y38, x38, x39, y39;
            btn37x = btnThreeDimensional2.Location.X + btnThreeDimensional2.Width / 2.0;//btn37三维立体观测能力的中下点
            btn37y = btnThreeDimensional2.Location.Y + btnThreeDimensional2.Height;
            Point btnPoint41 = new Point(Convert.ToInt32(btn37x), Convert.ToInt32(btn37y));//三维立体观测能力的中下点

            btn38x = btnLiTiGaoChenDingwei2.Location.X + btnLiTiGaoChenDingwei2.Width / 2.0;//btn38x是立体高程定位精度上中点
            btn38y = btnLiTiGaoChenDingwei2.Location.Y;
            Point btnPoint42 = new Point(Convert.ToInt32(btn38x), Convert.ToInt32(btn38y));//btn38是立体高程定位精度上中点

            x36 = btn37x;
            y36 = btn37y + (btn38y - btn37y) / 2;//三维立体观测能力下面的中点，重点
            Point midPoint41 = new Point(Convert.ToInt32(x36), Convert.ToInt32(y36));
            g.DrawLine(pen, btnPoint41, midPoint41);
            //立体高程定位精度上面的中间点
            x37 = btn38x;
            y37 = y36;
            Point midPoint42 = new Point(Convert.ToInt32(x37), Convert.ToInt32(y37));
            g.DrawLine(pen, midPoint42, midPoint41);
            g.DrawLine(pen, midPoint42, btnPoint42);

            //立体平面定位精度
            x38 = btnLiTIFlatDingWei2.Location.X + btnLiTIFlatDingWei2.Width / 2.0;
            y38 = y36;
            Point midPoint43 = new Point(Convert.ToInt32(x38), Convert.ToInt32(y38));
            g.DrawLine(pen, midPoint43, midPoint41);
            //立体平面定位精度上中点
            btn39x = btnLiTIFlatDingWei2.Location.X + btnLiTIFlatDingWei2.Width / 2.0;
            btn39y = btnLiTIFlatDingWei2.Location.Y;
            Point btnPoint43 = new Point(Convert.ToInt32(btn39x), Convert.ToInt32(btn39y));
            g.DrawLine(pen, midPoint43, btnPoint43);
            //测图比例尺
            x39 = btnCeTu2.Location.X + btnCeTu2.Width / 2.0;
            y39 = y36;
            Point midPoint44 = new Point(Convert.ToInt32(x39), Convert.ToInt32(y39));
            g.DrawLine(pen, midPoint44, midPoint41);
            //测图比例尺上中点
            btn40x = btnCeTu2.Location.X + btnCeTu2.Width / 2.0;
            btn40y = btnCeTu2.Location.Y;
            Point btnPoint44 = new Point(Convert.ToInt32(btn40x), Convert.ToInt32(btn40y));
            g.DrawLine(pen, midPoint44, btnPoint44);

            //--------------------------------------------
            double btn41x, btn41y, btn42x, btn42y, btn43x, btn43y, btn44x, btn44y;
            double x40, y40, x41, y41, y42, x42, x43, y43;
            btn41x = btnRadiationImage2.Location.X + btnRadiationImage2.Width / 2.0;//btn41辐射成像质量的中下点
            btn41y = btnRadiationImage2.Location.Y + btnRadiationImage2.Height;
            Point btnPoint45 = new Point(Convert.ToInt32(btn41x), Convert.ToInt32(btn41y));//辐射成像质量的中下点

            btn42x = btnDynamicRange2.Location.X + btnDynamicRange2.Width / 2.0;//btn38x是动态范围上中点
            btn42y = btnDynamicRange2.Location.Y;
            Point btnPoint46 = new Point(Convert.ToInt32(btn42x), Convert.ToInt32(btn42y));//btn42是立体高程定位精度上中点

            x40 = btn41x;
            y40 = y36 / 2;//辐射成像质量下面的中点，重点
            Point midPoint45 = new Point(Convert.ToInt32(x40), Convert.ToInt32(y40));
            g.DrawLine(pen, btnPoint45, midPoint45);
            //动态范围上面的中间点
            x41 = btn42x;
            y41 = y36;
            Point midPoint46 = new Point(Convert.ToInt32(x41), Convert.ToInt32(y41));
            g.DrawLine(pen, midPoint46, midPoint45);
            g.DrawLine(pen, midPoint46, btnPoint46);


            //信噪比
            x42 = btnSinal2.Location.X + btnSinal2.Width / 2.0;
            y42 = y36;
            Point midPoint47 = new Point(Convert.ToInt32(x42), Convert.ToInt32(y42));
            g.DrawLine(pen, midPoint47, midPoint46);
            //信噪比上中点
            btn43x = btnSinal2.Location.X + btnSinal2.Width / 2.0;
            btn43y = btnSinal2.Location.Y;
            Point btnPoint47 = new Point(Convert.ToInt32(btn43x), Convert.ToInt32(btn43y));
            g.DrawLine(pen, midPoint47, btnPoint47);
            //MTF
            x43 = btnMTF2.Location.X + btnMTF2.Width / 2.0;
            y43 = y36;
            Point midPoint48 = new Point(Convert.ToInt32(x43), Convert.ToInt32(y43));
            g.DrawLine(pen, midPoint48, midPoint46);
            //MTF上中点
            btn44x = btnMTF2.Location.X + btnMTF2.Width / 2.0;
            btn44y = btnMTF2.Location.Y;
            Point btnPoint48 = new Point(Convert.ToInt32(btn44x), Convert.ToInt32(btn44y));
            g.DrawLine(pen, midPoint48, btnPoint48);

            //--------------------------------------------
            double btn45x, btn45y, btn46x, btn46y, btn47x, btn47y, btn48x, btn48y, btn49x, btn49y;
            double x44, y44, x45, y45, y46, x46, x47, y47, x48, y48;
            btn45x = btnGeoImage2.Location.X + btnGeoImage2.Width / 2.0;//btn41几何成像质量的中下点
            btn45y = btnGeoImage2.Location.Y + btnGeoImage2.Height;
            Point btnPoint49 = new Point(Convert.ToInt32(btn45x), Convert.ToInt32(btn45y));//几何成像质量的中下点

            btn46x = btnSpatialReso2.Location.X + btnSpatialReso2.Width / 2.0;//btn38x是空间分辨率上中点
            btn46y = btnSpatialReso2.Location.Y;
            Point btnPoint50 = new Point(Convert.ToInt32(btn46x), Convert.ToInt32(btn46y));//btn46是空间分辨率上中点

            x44 = btn45x;
            y44 = y36 / 2;//几何成像质量下面的中点，重点
            Point midPoint49 = new Point(Convert.ToInt32(x44), Convert.ToInt32(y44));
            g.DrawLine(pen, btnPoint49, midPoint49);
            //空间分辨率上面的中间点
            x45 = btn46x;
            y45 = y36;
            Point midPoint50 = new Point(Convert.ToInt32(x45), Convert.ToInt32(y45));
            g.DrawLine(pen, midPoint50, midPoint49);
            g.DrawLine(pen, midPoint50, btnPoint50);
            //幅宽
            x46 = btnFuwidth2.Location.X + btnFuwidth2.Width / 2.0;
            y46 = y36;
            Point midPoint51 = new Point(Convert.ToInt32(x46), Convert.ToInt32(y46));
            g.DrawLine(pen, midPoint51, midPoint50);
            //幅宽上中点
            btn47x = btnFuwidth2.Location.X + btnFuwidth2.Width / 2.0;
            btn47y = btnFuwidth2.Location.Y;
            Point btnPoint51 = new Point(Convert.ToInt32(btn47x), Convert.ToInt32(btn47y));
            g.DrawLine(pen, midPoint51, btnPoint51);

            //条带长度
            x47 = btnTiaoDai2.Location.X + btnTiaoDai2.Width / 2.0;
            y47 = y36;
            Point midPoint52 = new Point(Convert.ToInt32(x47), Convert.ToInt32(y47));
            g.DrawLine(pen, midPoint52, midPoint50);
            //条带长度上中点
            btn48x = btnTiaoDai2.Location.X + btnTiaoDai2.Width / 2.0;
            btn48y = btnTiaoDai2.Location.Y;
            Point btnPoint52 = new Point(Convert.ToInt32(btn48x), Convert.ToInt32(btn48y));
            g.DrawLine(pen, midPoint52, btnPoint52);

            //条带长度
            x48 = btnFlatDingwei2.Location.X + btnFlatDingwei2.Width / 2.0;
            y48 = y36;
            Point midPoint53 = new Point(Convert.ToInt32(x48), Convert.ToInt32(y48));
            g.DrawLine(pen, midPoint53, midPoint50);
            //条带长度上中点
            btn49x = btnFlatDingwei2.Location.X + btnFlatDingwei2.Width / 2.0;
            btn49y = btnFlatDingwei2.Location.Y;
            Point btnPoint53 = new Point(Convert.ToInt32(btn49x), Convert.ToInt32(btn49y));
            g.DrawLine(pen, midPoint53, btnPoint53);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = btnFirst.Location.X + btnFirst.Width / 2.0;//btn1是效能分析按钮的中下点
            btn1y = btnFirst.Location.Y + btnFirst.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//效能分析按钮的中下点
            btn2x = btnCoverAbility.Location.X + btnCoverAbility.Width / 2.0;//btn2是覆盖能力上中点
            btn2y = btnCoverAbility.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是覆盖能力上中点
            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//效能分析按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));
            g.DrawLine(pen, btnPoint1, midPoint1);
            //覆盖能力上面的中间点
            x2 = btn2x;
            y2 = y1;
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));
            g.DrawLine(pen, midPoint2, midPoint1);//连接覆盖能力上面的中间点和效能分析下面的中间点
            g.DrawLine(pen, midPoint2, btnPoint2);//连接覆盖能力上面的中间点和覆盖能力上中点；
            //成像能力上面的中间点
            x3 = btnImageAbility.Location.X + btnImageAbility.Width / 2.0;
            y3 = y1;
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));
            g.DrawLine(pen, midPoint3, midPoint1);

            //成像能力上中间点
            btn3x = btnImageAbility.Location.X + btnImageAbility.Width / 2.0;//btn2是覆盖能力上中点
            btn3y = btnImageAbility.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));
            g.DrawLine(pen, midPoint3, btnPoint3);
            //------------------------------------------
            //应用满足度上面的中间点
            x4 = btnAppSatisfaction.Location.X + btnAppSatisfaction.Width / 2.0;
            y4 = y1;
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));
            g.DrawLine(pen, midPoint4, midPoint1);

            //应用满足度上中间点
            btn4x = btnAppSatisfaction.Location.X + btnAppSatisfaction.Width / 2.0;//btn4是应用满足度上中点
            btn4y = btnImageAbility.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));
            g.DrawLine(pen, midPoint4, btnPoint5);
            //响应时效性
            x5 = btnRespTime.Location.X + btnRespTime.Width / 2.0;
            y5 = y1;
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));
            g.DrawLine(pen, midPoint5, midPoint1);

            //响应时效性上中间点
            btn5x = btnRespTime.Location.X + btnRespTime.Width / 2.0;//btn2是覆盖能力上中点
            btn5y = btnImageAbility.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));
            g.DrawLine(pen, midPoint5, btnPoint6);
            //星地资源利用
            x6 = btnStartLand.Location.X + btnStartLand.Width / 2.0;
            y6 = y1;
            Point midPoint7 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));
            g.DrawLine(pen, midPoint7, midPoint1);

            //星地资源利用上中间点
            btn6x = btnStartLand.Location.X + btnStartLand.Width / 2.0;//btn6是星地资源利用上中点
            btn6y = btnStartLand.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));
            g.DrawLine(pen, midPoint7, btnPoint7);
            //------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12;
            btn7x = btnCoverAbility.Location.X + btnCoverAbility.Width / 2.0;//btn1是覆盖能力按钮的中下点
            btn7y = btnCoverAbility.Location.Y + btnCoverAbility.Height;
            Point btnPoint8 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//覆盖能力按钮的中下点
            btn8x = btnNeiborOverlap.Location.X + btnNeiborOverlap.Width / 2.0;//btn8是相邻成像区域重叠度上中点
            btn8y = btnNeiborOverlap.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//btnPoint9是相邻成像区域重叠度上中点
            x7 = btn7x;
            y7 = btn7y + (btn8y - btn7y) / 2;//覆盖能力按钮下面的中点，重点
            Point midPoint10 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));
            g.DrawLine(pen, btnPoint8, midPoint10);
            //相邻成像区域重叠度上面的中间点
            x8 = btn8x;
            y8 = y7;
            Point midPoint11 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));
            g.DrawLine(pen, midPoint10, midPoint11);//连接覆盖能力下面的中间点和相邻成像区域重叠度上面的中间点
            g.DrawLine(pen, midPoint11, btnPoint9);//相邻成像区域重叠度上中点和相邻成像区域重叠度上面的中间点
            ////覆盖区域次数上面的中间点
            x9 = btnCoverTime.Location.X + btnCoverTime.Width / 2.0;
            y9 = y7;
            Point midPoint12 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));
            g.DrawLine(pen, midPoint12, midPoint10);

            //覆盖区域次数上中间点
            btn9x = btnCoverTime.Location.X + btnCoverTime.Width / 2.0;//btn9是覆盖区域次数上中点
            btn9y = btnCoverTime.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));
            g.DrawLine(pen, midPoint12, btnPoint10);
            //----------------------------
            //多视角成像次数
            x10 = btnManyViewTime.Location.X + btnManyViewTime.Width / 2.0;
            y10 = y7;
            Point midPoint13 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));
            g.DrawLine(pen, midPoint13, midPoint10);

            //多视角成像次数上中间点
            btn10x = btnManyViewTime.Location.X + btnManyViewTime.Width / 2.0;//btn9是覆盖区域次数上中点
            btn10y = btnManyViewTime.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, midPoint13, btnPoint11);
            //---------------------
            //覆盖范围
            x11 = btnConverRange.Location.X + btnConverRange.Width / 2.0;
            y11 = y7;
            Point midPoint14 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, midPoint14, midPoint10);

            //覆盖范围上中间点
            btn11x = btnConverRange.Location.X + btnConverRange.Width / 2.0;//btn11是覆盖范围上中点
            btn11y = btnManyViewTime.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));
            g.DrawLine(pen, midPoint14, btnPoint12);
            //----------------------
            //单位区域可观测目标数目
            x12 = btnPerRangeTargetNum.Location.X + btnPerRangeTargetNum.Width / 2.0;
            y12 = y7;
            Point midPoint15 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            g.DrawLine(pen, midPoint15, midPoint10);

            //单位区域可观测目标数目上中间点
            btn12x = btnPerRangeTargetNum.Location.X + btnPerRangeTargetNum.Width / 2.0;//btn11是覆盖范围上中点
            btn12y = btnPerRangeTargetNum.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));
            g.DrawLine(pen, midPoint15, btnPoint13);
            //-------------------------------------
            double btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y, btn19x, btn19y;
            double x13, y13, x14, y14, x15, y15, x16, y16, x17, y17, x18, y18, x19, y19, x20, y20;
            btn13x = btnImageAbility.Location.X + btnImageAbility.Width / 2.0;//btn13是成像能力的中下点
            btn13y = btnImageAbility.Location.Y + btnImageAbility.Height;
            Point btnPoint14 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));//btn13是成像能力的中下点
            btn14x = btnRadiationImage2.Location.X + btnRadiationImage2.Width / 2.0;//btn14辐射成像质量上中点
            btn14y = btnRadiationImage2.Location.Y;
            Point btnPoint15 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));//btn14是辐射成像质量上中点
            x13 = btn13x;
            y13 = y7;//成像能力按钮下面的中点，重点
            Point midPoint16 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13));
            g.DrawLine(pen, btnPoint14, midPoint16);
            //辐射成像质量上面的中间点
            x14 = btn14x;
            y14 = y7;
            Point midPoint17 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14));
            g.DrawLine(pen, midPoint16, midPoint17);//连接成像能力下面的中间点和辐射成像上面的中间点
            g.DrawLine(pen, midPoint17, btnPoint15);//连接辐射成像上面的中间点和辐射成像质量上中点
            //-------------------
            //几何成像质量         
            x15 = btnGeoImage.Location.X + btnGeoImage.Width / 2.0;
            y15 = y7;
            Point midPoint18 = new Point(Convert.ToInt32(x15), Convert.ToInt32(y15));
            g.DrawLine(pen, midPoint16, midPoint18);
            //几何成像质量上中间点
            btn15x = btnGeoImage.Location.X + btnGeoImage.Width / 2.0;//btn15几何成像质量上中点
            btn15y = btnGeoImage.Location.Y;
            Point btnPoint18 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));
            g.DrawLine(pen, midPoint18, btnPoint18);
            //---------------------------
            //应用满足度
            btn16x = btnAppSatisfaction.Location.X + btnAppSatisfaction.Width / 2.0;//btn16是应用满足度的中下点
            btn16y = btnAppSatisfaction.Location.Y + btnAppSatisfaction.Height;
            Point btnPoint19 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y));//btn16是应用满足度中下点
            btn17x = btnDynamic.Location.X + btnDynamic.Width / 2.0;//btn17动态监测上中点
            btn17y = btnDynamic.Location.Y;
            Point btnPoint20 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));//btn17是动态监测上中点
            x16 = btn16x;
            y16 = y7;//应用满足度按钮下面的中点，重点
            Point midPoint21 = new Point(Convert.ToInt32(x16), Convert.ToInt32(y16));
            g.DrawLine(pen, btnPoint19, midPoint21);
            //动态监测能力上面的中间点
            x17 = btn17x;
            y17 = y7;
            Point midPoint22 = new Point(Convert.ToInt32(x17), Convert.ToInt32(y17));
            g.DrawLine(pen, midPoint22, midPoint21);//应用满足度下面的中间点和动态监测能力上面的中间点
            g.DrawLine(pen, midPoint22, btnPoint20);//连接辐射成像上面的中间点和辐射成像质量上中点
            //-------------------
            //物理特性探测能力
            x18 = btnPhysisObservation.Location.X + btnPhysisObservation.Width / 2.0;
            y18 = y7;
            Point midPoint23 = new Point(Convert.ToInt32(x18), Convert.ToInt32(y18));
            g.DrawLine(pen, midPoint23, midPoint21);
            //物理特性探测能力上中间点
            btn17x = btnPhysisObservation.Location.X + btnPhysisObservation.Width / 2.0;//btn15几何成像质量上中点
            btn17y = btnPhysisObservation.Location.Y;
            Point btnPoint21 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));
            g.DrawLine(pen, midPoint23, btnPoint21);
            //-------------------
            //目标监测识别能力
            x19 = btnTargetDetection.Location.X + btnTargetDetection.Width / 2.0;
            y19 = y7;
            Point midPoint24 = new Point(Convert.ToInt32(x19), Convert.ToInt32(y19));
            g.DrawLine(pen, midPoint24, midPoint21);
            //目标识别能力上中间点
            btn18x = btnTargetDetection.Location.X + btnTargetDetection.Width / 2.0;//btn15几何成像质量上中点
            btn18y = btnTargetDetection.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y));
            g.DrawLine(pen, midPoint24, btnPoint22);
            //-------------------
            //三维立体观测能力
            x20 = btnThreeDimensional.Location.X + btnThreeDimensional.Width / 2.0;
            y20 = y7;
            Point midPoint25 = new Point(Convert.ToInt32(x20), Convert.ToInt32(y20));
            g.DrawLine(pen, midPoint25, midPoint21);
            //目标识别能力上中间点
            btn19x = btnThreeDimensional.Location.X + btnThreeDimensional.Width / 2.0;//btn15几何成像质量上中点
            btn19y = btnThreeDimensional.Location.Y;
            Point btnPoint23 = new Point(Convert.ToInt32(btn19x), Convert.ToInt32(btn19y));
            g.DrawLine(pen, midPoint25, btnPoint23);
            //---------------------------
            double btn20x, btn20y, btn21x, btn21y, btn22x, btn22y, btn23x, btn23y, btn24x, btn24y;
            double x21, y21, x22, y22, x23, y23, x24, y24, x25, y25;
            //星地资源利用
            btn20x = btnStartLand.Location.X + btnStartLand.Width / 2.0;//btn20是星上资源的中下点
            btn20y = btnStartLand.Location.Y + btnStartLand.Height;
            Point btnPoint24 = new Point(Convert.ToInt32(btn20x), Convert.ToInt32(btn20y));//btn20是星地资源中下点
            btn21x = btnStartEnergy.Location.X + btnStartEnergy.Width / 2.0;//btn21星上能源利用率上中点
            btn21y = btnStartEnergy.Location.Y;
            Point btnPoint25 = new Point(Convert.ToInt32(btn21x), Convert.ToInt32(btn21y));//btn21是星上能源利用率上中点
            x21 = btn20x;
            y21 = y7;//星地资源下面的中点，重点
            Point midPoint26 = new Point(Convert.ToInt32(x21), Convert.ToInt32(y21));
            g.DrawLine(pen, btnPoint24, midPoint26);
            //星上能源利用率上面的中间点
            x22 = btn21x;
            y22 = y7;
            Point midPoint27 = new Point(Convert.ToInt32(x22), Convert.ToInt32(y22));
            g.DrawLine(pen, midPoint27, midPoint26);//星地资源下面的中点，星上能源利用率上面的中间点
            g.DrawLine(pen, midPoint27, btnPoint25);//星上能源利用率上面的中间点，星上能源利用率上中点
            //-------------------
            //数传资源
            x23 = btnShuChuanResource.Location.X + btnShuChuanResource.Width / 2.0;
            y23 = y7;
            Point midPoint28 = new Point(Convert.ToInt32(x23), Convert.ToInt32(y23));
            g.DrawLine(pen, midPoint26, midPoint28);
            //数传资源上中间点
            btn22x = btnShuChuanResource.Location.X + btnShuChuanResource.Width / 2.0;//btn22数传资源上中点
            btn22y = btnShuChuanResource.Location.Y;
            Point btnPoint26 = new Point(Convert.ToInt32(btn22x), Convert.ToInt32(btn22y));
            g.DrawLine(pen, midPoint28, btnPoint26);
            //-------------------
            //星上资源利用率
            x24 = btnStartResource.Location.X + btnStartResource.Width / 2.0;
            y24 = y7;
            Point midPoint29 = new Point(Convert.ToInt32(x24), Convert.ToInt32(y24));
            g.DrawLine(pen, midPoint29, midPoint26);
            //星上资源利用率上中点
            btn23x = btnStartResource.Location.X + btnStartResource.Width / 2.0;//btn23星上资源利用率上中点
            btn23y = btnStartResource.Location.Y;
            Point btnPoint27 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y));
            g.DrawLine(pen, midPoint29, btnPoint27);
            //测控资源利用率
            x25 = btnCeKong.Location.X + btnCeKong.Width / 2.0;
            y25 = y7;
            Point midPoint30 = new Point(Convert.ToInt32(x25), Convert.ToInt32(y25));
            g.DrawLine(pen, midPoint30, midPoint26);
            //测控资源利用率上中点
            btn24x = btnCeKong.Location.X + btnCeKong.Width / 2.0;//btn23星上资源利用率上中点
            btn24y = btnCeKong.Location.Y;
            Point btnPoint28 = new Point(Convert.ToInt32(btn24x), Convert.ToInt32(btn24y));
            g.DrawLine(pen, midPoint30, btnPoint28);
            //响应时效性
            double btn25x, btn25y, btn26x, btn26y, btn27x, btn27y, btn28x, btn28y, btn29x, btn29y, btn30x, btn30y;
            double x26, y26, x27, y27, x28, y28, x29, y29, x30, y30, x31, y31;
            btn25x = btnRespTime.Location.X + btnRespTime.Width / 2.0;//btn25是响应时效性的中下点
            btn25y = btnRespTime.Location.Y + btnRespTime.Height;
            Point btnPoint29 = new Point(Convert.ToInt32(btn25x), Convert.ToInt32(btn25y));//响应时效性的中下点
            btn26x = btnNeiborMaxTime.Location.X + btnNeiborMaxTime.Width / 2.0;//btn26是邻近观测最大时间间隔上中点
            btn26y = btnNeiborMaxTime.Location.Y;
            Point btnPoint30 = new Point(Convert.ToInt32(btn26x), Convert.ToInt32(btn26y));//btn26是邻近观测最大时间间隔上中点
            x26 = btn25x;
            y26 = y7;//邻近观测最大时间间隔下面的中点，重点
            Point midPoint31 = new Point(Convert.ToInt32(x26), Convert.ToInt32(y26));
            g.DrawLine(pen, btnPoint29, midPoint31);
            //邻近观测最大时间间隔上面的中间点
            x27 = btn26x;
            y27 = y7;
            Point midPoint32 = new Point(Convert.ToInt32(x27), Convert.ToInt32(y27));
            g.DrawLine(pen, midPoint31, midPoint32);//连接覆盖能力上面的中间点和效能分析下面的中间点
            g.DrawLine(pen, midPoint32, btnPoint30);//连接覆盖能力上面的中间点和覆盖能力上中点；

            //邻近观测最小间隔时长
            x28 = btnNeiborMinTime.Location.X + btnNeiborMinTime.Width / 2.0;
            y28 = y7;
            Point midPoint33 = new Point(Convert.ToInt32(x28), Convert.ToInt32(y28));
            g.DrawLine(pen, midPoint33, midPoint31);
            //邻近观测最小间隔时长上中点
            btn27x = btnNeiborMinTime.Location.X + btnNeiborMinTime.Width / 2.0;//btn23邻近观测最小间隔时长上中点
            btn27y = btnCeKong.Location.Y;
            Point btnPoint31 = new Point(Convert.ToInt32(btn27x), Convert.ToInt32(btn27y));
            g.DrawLine(pen, midPoint33, btnPoint31);


            //最大连续监测时长
            x29 = btnMaxTime.Location.X + btnMaxTime.Width / 2.0;
            y29 = y7;
            Point midPoint34 = new Point(Convert.ToInt32(x29), Convert.ToInt32(y29));
            g.DrawLine(pen, midPoint34, midPoint31);
            //最大连续监测时长上中点
            btn28x = btnMaxTime.Location.X + btnMaxTime.Width / 2.0;
            btn28y = btnMaxTime.Location.Y;
            Point btnPoint32 = new Point(Convert.ToInt32(btn28x), Convert.ToInt32(btn28y));
            g.DrawLine(pen, midPoint34, btnPoint32);

            //最小连续监测时长
            x30 = btnMinTime.Location.X + btnMinTime.Width / 2.0;
            y30 = y7;
            Point midPoint35 = new Point(Convert.ToInt32(x30), Convert.ToInt32(y30));
            g.DrawLine(pen, midPoint35, midPoint31);
            //最小连续监测时长上中点
            btn29x = btnMinTime.Location.X + btnMinTime.Width / 2.0;
            btn29y = btnMinTime.Location.Y;
            Point btnPoint33 = new Point(Convert.ToInt32(btn29x), Convert.ToInt32(btn29y));
            g.DrawLine(pen, midPoint35, btnPoint33);
            //重访周期
            x31 = btnRevisiteCycle.Location.X + btnRevisiteCycle.Width / 2.0;
            y31 = y7;
            Point midPoint36 = new Point(Convert.ToInt32(x31), Convert.ToInt32(y31));
            g.DrawLine(pen, midPoint36, midPoint31);
            //重访周期上中点
            btn30x = btnRevisiteCycle.Location.X + btnRevisiteCycle.Width / 2.0;
            btn30y = btnRevisiteCycle.Location.Y;
            Point btnPoint34 = new Point(Convert.ToInt32(btn30x), Convert.ToInt32(btn30y));
            g.DrawLine(pen, midPoint36, btnPoint34);

            double btn31x, btn31y, btn32x, btn32y, btn33x, btn33y, btn34x, btn34y, btn35x, btn35y, btn36x, btn36y;
            double x32, y32, x33, y33, x34, y34, x35, y35;

            //单次任务响应时长
            x32 = btnOneResponseTime.Location.X + btnOneResponseTime.Width / 2.0;
            y32 = y7;
            Point midPoint37 = new Point(Convert.ToInt32(x32), Convert.ToInt32(y32));
            g.DrawLine(pen, midPoint37, midPoint31);
            //单次任务响应时长上中点
            btn31x = btnOneResponseTime.Location.X + btnOneResponseTime.Width / 2.0;
            btn31y = btnOneResponseTime.Location.Y;
            Point btnPoint35 = new Point(Convert.ToInt32(btn31x), Convert.ToInt32(btn31y));
            g.DrawLine(pen, midPoint37, btnPoint35);
            //单次连续观测时长
            x33 = btnOneGuanceTime.Location.X + btnOneGuanceTime.Width / 2.0;
            y33 = y7;
            Point midPoint38 = new Point(Convert.ToInt32(x33), Convert.ToInt32(y33));
            g.DrawLine(pen, midPoint38, midPoint31);
            //单次连续观测时长上中点
            btn32x = btnOneGuanceTime.Location.X + btnOneGuanceTime.Width / 2.0;
            btn32y = btnOneGuanceTime.Location.Y;
            Point btnPoint36 = new Point(Convert.ToInt32(btn32x), Convert.ToInt32(btn32y));
            g.DrawLine(pen, midPoint38, btnPoint36);

            //响应延迟时间
            x34 = btnResponseDelayTime.Location.X + btnResponseDelayTime.Width / 2.0;
            y34 = y7;
            Point midPoint39 = new Point(Convert.ToInt32(x34), Convert.ToInt32(y34));
            g.DrawLine(pen, midPoint39, midPoint31);
            //响应延迟时间上中点
            btn33x = btnResponseDelayTime.Location.X + btnResponseDelayTime.Width / 2.0;
            btn33y = btnResponseDelayTime.Location.Y;
            Point btnPoint37 = new Point(Convert.ToInt32(btn33x), Convert.ToInt32(btn33y));
            g.DrawLine(pen, midPoint39, btnPoint37);

            //单位时间可观测任务数
            x35 = btnPerTimeGuanceTask.Location.X + btnPerTimeGuanceTask.Width / 2.0;
            y35 = y7;
            Point midPoint40 = new Point(Convert.ToInt32(x35), Convert.ToInt32(y35));
            g.DrawLine(pen, midPoint40, midPoint31);
            //单位时间可观测任务数上中点
            btn34x = btnPerTimeGuanceTask.Location.X + btnPerTimeGuanceTask.Width / 2.0;
            btn34y = btnPerTimeGuanceTask.Location.Y;
            Point btnPoint38 = new Point(Convert.ToInt32(btn34x), Convert.ToInt32(btn34y));
            g.DrawLine(pen, midPoint40, btnPoint38);

            //目标解译度
            btn35x = btnTargetDetection.Location.X + btnTargetDetection.Width / 2.0;
            btn35y = btnTargetDetection.Location.Y + btnTargetDetection.Height;
            Point btnPoint39 = new Point(Convert.ToInt32(btn35x), Convert.ToInt32(btn35y));
            btn36x = btnTargetJieyi.Location.X + btnTargetJieyi.Width / 2.0;
            btn36y = btnTargetJieyi.Location.Y;
            Point btnPoint40 = new Point(Convert.ToInt32(btn36x), Convert.ToInt32(btn36y));
            g.DrawLine(pen, btnPoint39, btnPoint40);
            //-----------------------------------
            double btn37x, btn37y, btn38x, btn38y, btn39x, btn39y, btn40x, btn40y;
            double x36, y36, x37, y37, y38, x38, x39, y39;
            btn37x = btnThreeDimensional.Location.X + btnThreeDimensional.Width / 2.0;//btn37三维立体观测能力的中下点
            btn37y = btnThreeDimensional.Location.Y + btnThreeDimensional.Height;
            Point btnPoint41 = new Point(Convert.ToInt32(btn37x), Convert.ToInt32(btn37y));//三维立体观测能力的中下点

            btn38x = btnLiTiGaoChenDingwei.Location.X + btnLiTiGaoChenDingwei.Width / 2.0;//btn38x是立体高程定位精度上中点
            btn38y = btnLiTiGaoChenDingwei.Location.Y;
            Point btnPoint42 = new Point(Convert.ToInt32(btn38x), Convert.ToInt32(btn38y));//btn38是立体高程定位精度上中点

            x36 = btn37x;
            y36 = btn37y + (btn38y - btn37y) / 2;//三维立体观测能力下面的中点，重点
            Point midPoint41 = new Point(Convert.ToInt32(x36), Convert.ToInt32(y36));
            g.DrawLine(pen, btnPoint41, midPoint41);
            //立体高程定位精度上面的中间点
            x37 = btn38x;
            y37 = y36;
            Point midPoint42 = new Point(Convert.ToInt32(x37), Convert.ToInt32(y37));
            g.DrawLine(pen, midPoint42, midPoint41);
            g.DrawLine(pen, midPoint42, btnPoint42);

            //立体平面定位精度
            x38 = btnLiTIFlatDingWei.Location.X + btnLiTIFlatDingWei.Width / 2.0;
            y38 = y36;
            Point midPoint43 = new Point(Convert.ToInt32(x38), Convert.ToInt32(y38));
            g.DrawLine(pen, midPoint43, midPoint41);
            //立体平面定位精度上中点
            btn39x = btnLiTIFlatDingWei.Location.X + btnLiTIFlatDingWei.Width / 2.0;
            btn39y = btnLiTIFlatDingWei.Location.Y;
            Point btnPoint43 = new Point(Convert.ToInt32(btn39x), Convert.ToInt32(btn39y));
            g.DrawLine(pen, midPoint43, btnPoint43);
            //测图比例尺
            x39 = btnCeTu.Location.X + btnCeTu.Width / 2.0;
            y39 = y36;
            Point midPoint44 = new Point(Convert.ToInt32(x39), Convert.ToInt32(y39));
            g.DrawLine(pen, midPoint44, midPoint41);
            //测图比例尺上中点
            btn40x = btnCeTu.Location.X + btnCeTu.Width / 2.0;
            btn40y = btnCeTu.Location.Y;
            Point btnPoint44 = new Point(Convert.ToInt32(btn40x), Convert.ToInt32(btn40y));
            g.DrawLine(pen, midPoint44, btnPoint44);

            //--------------------------------------------
            double btn41x, btn41y, btn42x, btn42y, btn43x, btn43y, btn44x, btn44y;
            double x40, y40, x41, y41, y42, x42, x43, y43;
            btn41x = btnRadiationImage.Location.X + btnRadiationImage.Width / 2.0;//btn41辐射成像质量的中下点
            btn41y = btnRadiationImage.Location.Y + btnRadiationImage.Height;
            Point btnPoint45 = new Point(Convert.ToInt32(btn41x), Convert.ToInt32(btn41y));//辐射成像质量的中下点

            btn42x = btnDynamicRange.Location.X + btnDynamicRange.Width / 2.0;//btn38x是动态范围上中点
            btn42y = btnDynamicRange.Location.Y;
            Point btnPoint46 = new Point(Convert.ToInt32(btn42x), Convert.ToInt32(btn42y));//btn42是立体高程定位精度上中点

            x40 = btn41x;
            y40 = y36 / 2;//辐射成像质量下面的中点，重点
            Point midPoint45 = new Point(Convert.ToInt32(x40), Convert.ToInt32(y40));
            g.DrawLine(pen, btnPoint45, midPoint45);
            //动态范围上面的中间点
            x41 = btn42x;
            y41 = y36;
            Point midPoint46 = new Point(Convert.ToInt32(x41), Convert.ToInt32(y41));
            g.DrawLine(pen, midPoint46, midPoint45);
            g.DrawLine(pen, midPoint46, btnPoint46);


            //信噪比
            x42 = btnSinal.Location.X + btnSinal.Width / 2.0;
            y42 = y36;
            Point midPoint47 = new Point(Convert.ToInt32(x42), Convert.ToInt32(y42));
            g.DrawLine(pen, midPoint47, midPoint46);
            //信噪比上中点
            btn43x = btnSinal.Location.X + btnSinal2.Width / 2.0;
            btn43y = btnSinal.Location.Y;
            Point btnPoint47 = new Point(Convert.ToInt32(btn43x), Convert.ToInt32(btn43y));
            g.DrawLine(pen, midPoint47, btnPoint47);
            //MTF
            x43 = btnMTF.Location.X + btnMTF.Width / 2.0;
            y43 = y36;
            Point midPoint48 = new Point(Convert.ToInt32(x43), Convert.ToInt32(y43));
            g.DrawLine(pen, midPoint48, midPoint46);
            //MTF上中点
            btn44x = btnMTF.Location.X + btnMTF.Width / 2.0;
            btn44y = btnMTF.Location.Y;
            Point btnPoint48 = new Point(Convert.ToInt32(btn44x), Convert.ToInt32(btn44y));
            g.DrawLine(pen, midPoint48, btnPoint48);

            //--------------------------------------------
            double btn45x, btn45y, btn46x, btn46y, btn47x, btn47y, btn48x, btn48y, btn49x, btn49y;
            double x44, y44, x45, y45, y46, x46, x47, y47, x48, y48;
            btn45x = btnGeoImage.Location.X + btnGeoImage.Width / 2.0;//btn41几何成像质量的中下点
            btn45y = btnGeoImage.Location.Y + btnGeoImage.Height;
            Point btnPoint49 = new Point(Convert.ToInt32(btn45x), Convert.ToInt32(btn45y));//几何成像质量的中下点

            btn46x = btnSpatialReso.Location.X + btnSpatialReso.Width / 2.0;//btn38x是空间分辨率上中点
            btn46y = btnSpatialReso.Location.Y;
            Point btnPoint50 = new Point(Convert.ToInt32(btn46x), Convert.ToInt32(btn46y));//btn46是空间分辨率上中点

            x44 = btn45x;
            y44 = y36 / 2;//几何成像质量下面的中点，重点
            Point midPoint49 = new Point(Convert.ToInt32(x44), Convert.ToInt32(y44));
            g.DrawLine(pen, btnPoint49, midPoint49);
            //空间分辨率上面的中间点
            x45 = btn46x;
            y45 = y36;
            Point midPoint50 = new Point(Convert.ToInt32(x45), Convert.ToInt32(y45));
            g.DrawLine(pen, midPoint50, midPoint49);
            g.DrawLine(pen, midPoint50, btnPoint50);
            //幅宽
            x46 = btnFuwidth.Location.X + btnFuwidth.Width / 2.0;
            y46 = y36;
            Point midPoint51 = new Point(Convert.ToInt32(x46), Convert.ToInt32(y46));
            g.DrawLine(pen, midPoint51, midPoint50);
            //幅宽上中点
            btn47x = btnFuwidth.Location.X + btnFuwidth.Width / 2.0;
            btn47y = btnFuwidth.Location.Y;
            Point btnPoint51 = new Point(Convert.ToInt32(btn47x), Convert.ToInt32(btn47y));
            g.DrawLine(pen, midPoint51, btnPoint51);

            //条带长度
            x47 = btnTiaoDai.Location.X + btnTiaoDai.Width / 2.0;
            y47 = y36;
            Point midPoint52 = new Point(Convert.ToInt32(x47), Convert.ToInt32(y47));
            g.DrawLine(pen, midPoint52, midPoint50);
            //条带长度上中点
            btn48x = btnTiaoDai.Location.X + btnTiaoDai.Width / 2.0;
            btn48y = btnTiaoDai.Location.Y;
            Point btnPoint52 = new Point(Convert.ToInt32(btn48x), Convert.ToInt32(btn48y));
            g.DrawLine(pen, midPoint52, btnPoint52);

            //条带长度
            x48 = btnFlatDingwei.Location.X + btnFlatDingwei.Width / 2.0;
            y48 = y36;
            Point midPoint53 = new Point(Convert.ToInt32(x48), Convert.ToInt32(y48));
            g.DrawLine(pen, midPoint53, midPoint50);
            //条带长度上中点
            btn49x = btnFlatDingwei.Location.X + btnFlatDingwei.Width / 2.0;
            btn49y = btnFlatDingwei.Location.Y;
            Point btnPoint53 = new Point(Convert.ToInt32(btn49x), Convert.ToInt32(btn49y));
            g.DrawLine(pen, midPoint53, btnPoint53);
        }

        private void parameterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parameterComboBox.SelectedIndex == 0)
            {
                panel1.Visible = true;
                //panel2.Location = new Point(125, 28);
                panel2.Visible = false;
                panel1.Location = new Point(0, 19);
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                //panel1.Location = new Point(115, 30);
                panel2.Location = new Point(0, 19);
            }
        }
        //参数选择初始化
        void comboxInit()
        {
            parameterComboBox.SelectedIndex = 0;
            panel1.Visible = true;
            panel2.Visible = false;
            panel1.Location = new Point(0, 19);

            parameterComboBox2.SelectedIndex = 0;
            panel3.Visible = true;
            panel4.Visible = false;
            panel3.Location = new Point(214, 108);

        }
        //窗体大小改变触发事件
        void combox_ToFormResize()
        {
            if (parameterComboBox.SelectedIndex == 0)
            {
                panel1.Visible = true;
                //panel2.Location = new Point(125, 28);
                panel2.Visible = false;
                panel1.Location = new Point(0, 40);
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                //panel1.Location = new Point(115, 30);
                panel2.Location = new Point(0, 40);
            }
        }
        //参数设置，点击某个按钮，弹出对应的填参数的窗口              

        public double targetDetection_physisObservation=2,//目标检测识别能力-物理特性探测能力
        targetDetection_threeDimensional=3,//目标检测识别能力-三维立体观测能力
        targetDetection_dynamic=4,//目标检测识别能力-动态监视能力
        physisObservation_threeDimensional=1,//物理特性探测能力-三维立体观测能力
        physisObservation_dynamic=3,//物理特性探测能力-动态监视能力
        threeDimensional_dynamic=4;//三维立体观测能力-动态监视能力

        private void btnAppSatisfaction2_Click(object sender, EventArgs e)
        {
            appSatisify con = new appSatisify();
            con.ShowDialog(this);
        }

        public double coverRange_coverNum=2,//覆盖范围—覆盖区域次数
            coverRange_xianlingImageOverlap=3,//覆盖范围-相邻成像区域重叠度
            coverRange_manyViewImageNum=4,//覆盖范围-多视角成像次数
            coverRange_danWeiTargetNum=1,//覆盖范围-单位区域可观测目标数
            coverNum_xianlingImageOverlap=3,//覆盖区域次数-相邻成像区域重叠度

            coverNum_manyViewImageNum=4,//覆盖区域次数-多视角成像次数
            coverNum_danWeiTargetNum=3,//覆盖区域次数-单位区域可观测目标数
            xianlingImageOverlap_manyViewImageNum=5,//相邻成像区域重叠度-多视角成像次数
            xianlingImageOverlap_danWeiTargetNum=1,//相邻成像区域重叠度-单位区域可观测目标数
            manyViewImageNum_danWeiTargetNum=2;//多视角成像次数-单位区域可观测目标数

        
        private void btnCoverAbility2_Click(object sender, EventArgs e)
        {
            coverAbility con = new coverAbility();
            con.ShowDialog(this);
        }
        public double response_image = 1, 
            response_cover = 2, 
            response_appSatisify = 3, 
            response_starLand = 2, 
            image_cover = 3,
            image_appSatisify = 5, 
            image_starLand = 2, 
            cover_appSatisify = 3, 
            cover_starLand = 5, 
            appSatisify_starLand = 3;//对应于btnCoverAbility2_Click        
        private void btnFirst2_Click(object sender, EventArgs e)
        {
            comPerformance com = new comPerformance();
            com.ShowDialog(this);
        }
        public double radiationImage_geoImage = 1;
        private void btnImageAbility2_Click(object sender, EventArgs e)
        {
            imageAbility img = new imageAbility();
            img.ShowDialog(this);
        }
        public double starResource_starEnergy=2,//星上存储资源利用率-星上能源资源利用率
            starResource_shuChuanResource=5,//星上存储资源利用率-数传资源利用率
            starResource_ceKong=4,//星上存储资源利用率-测控
            starEnergy_shuChuanResource=3,//星上能源资源利用率-数传
            starEnergy_ceKong=3,//星上能源资-测控
            shuChuanResource_ceKong=1;//数传比测控

        

        private void btnStarLand2_Click(object sender, EventArgs e)
        {
            starLandResource com = new starLandResource();
            com.ShowDialog(this);
        }
        public double liTIFlatDingWei_liTiGaoChenDingwei=2,//立体平面定位精度-立体高程定位精度
            liTIFlatDingWei_ceTu=3,//立体平面定位精度-测图比例尺
            liTiGaoChenDingwei_ceTu=1;//立体高程定位精度-测图比例尺
        private void btnThreeDimensional2_Click(object sender, EventArgs e)
        {
            threeDimensional com = new threeDimensional();
            com.ShowDialog(this);
        }
        public double MTF_dynamicRange=3, MTF_sinal=2, dynamicRange_sinal=1;
        private void btnRadiationImage2_Click(object sender, EventArgs e)
        {
            radiationImage com = new radiationImage();
            com.ShowDialog(this);
        }
        public double spatialReso_fuWidth=2, spatialReso_tiaoDai=3, spatialReso_flatDingwei=5, fuWidth_tiaoDai=1, fuWidth_flatDingwei=4, tiaoDai_flatDingwei=3;
        private void btnGeoImage2_Click(object sender, EventArgs e)
        {
            geoImage com = new geoImage();
            com.ShowDialog(this);
        }
        public double responseDelayTime_perTimeGuanceTask=2, //响应延迟时间-单位时间可观测任务数
            responseDelayTime_RevisiteCycle=3,//响应延迟-重访周期
            responseDelayTime_minTime=5, //响应延迟-最小连续监测时长
            responseDelayTime_maxTime=1,//响应延迟-最大连续监测时长
             responseDelayTime_neiborMinTime=4, //响应延迟-邻近观测最小时间间隔
            responseDelayTime_neiborMaxTime=3;//响应延迟-邻近观测最大时间间隔

        public double responseDelayTime_oneResponseTime=4,//响应延迟-单次任务响应时长
            responseDelayTime_oneGuanceTime=3,//响应延迟-单次连续观测时长
            perTimeGuanceTask_RevisiteCycle =5,//单位时间可观测任务数-重访周期
            perTimeGuanceTask_minTime=2,//单位时间可观测任务数-最小连续监测时长
            perTimeGuanceTask_maxTime=1,//单位时间可观测任务数-最大连续监测时长
            perTimeGuanceTask_neiborMinTime=5; //单位时间可观测任务数-邻近观测最小时间间隔

        public double perTimeGuanceTask_neiborMaxTime=5,//单位时间可观测任务数-邻近观测最大时间间隔
            perTimeGuanceTask_oneResponseTime=4,//单位时间可观测任务数-单次任务响应时长
            perTimeGuanceTask_oneGuanceTime=3,//单位时间可观测任务数-单次连续观测时长
            RevisiteCycle_minTime=1,//重访周期-最小连续监测时长
            RevisiteCycle_maxTime=2,//重访周期-最大连续监测时长
            RevisiteCycle_neiborMinTime=3;//重访周期-邻近观测最小时间间隔

        public double RevisiteCycle_neiborMaxTime=1,//重访周期-邻近观测最大时间间隔
            RevisiteCycle_oneResponseTime=2,//重访周期-单次任务响应时长
            RevisiteCycle_oneGuanceTime=3,//重访周期-单次连续观测时长
            minTime_maxTime=4,//最小连续监测时长-最大连续监测时长
            minTime_neiborMinTime=5, //最小连续监测时长-邻近观测最小时间间隔
            minTime_neiborMaxTime=6;//最小连续监测时长-邻近观测最大时间间隔

       
        public double minTime_oneResponseTime=6,//最小连续监测时长-单次任务响应时长
            minTime_oneGuanceTime=5,//最小连续监测时长-单次连续观测时长
            maxTime_neiborMinTime=4,//最大连续监测时长-邻近观测最小时间间隔
            maxTime_neiborMaxTime=3,//最大连续监测时长-邻近观测最大时间间隔
            maxTime_oneResponseTime=2,//最大连续监测时长-单次任务响应时长
            maxTime_oneGuanceTime=1;//最大连续监测时长-单次连续观测时长

        

        public double neiborMinTime_neiborMaxTime=5, //邻近观测最小时间间隔-邻近观测最大时间间隔
            neiborMinTime_oneResponseTime=4,//邻近观测最小时间间隔-单次任务响应时长
            neiborMinTime_oneGuanceTime=3,//邻近观测最小时间间隔-单次连续观测时长
            neiborMaxTime_oneResponseTime=1, //邻近观测最大时间间隔-单次任务响应时长
            neiborMaxTime_oneGuanceTime=2,//邻近观测最大时间间隔-单次连续观测时长
            oneResponseTime_oneGuanceTime=3;//单次任务响应时长-单次连续观测时长

     
        private void btnRespTime2_Click(object sender, EventArgs e)
        {
            responseTime com = new responseTime();
            com.ShowDialog(this);
        }

        //定义权重矩阵
        private double[,] comPerforMatrix;//第一层权重矩阵，响应时效性、成像能力、覆盖能力、应用满足度、星地资源利用

        private double[,] responseTimeMatrix;//响应时效性权重矩阵
        private double[,] imageAbilityMatrix;//成像能力权重矩阵

       
        private double[,] coverAbilityMatrix;//覆盖能力权重矩阵
        private double[,] appSatisfyMatrix;//应用满足度
        private double[,] starLandResouceMatrix;//星地资源利用

        private double[,] ratidationImageMatrix;//辐射成像质量
        private double[,] geoImageMatrix;//几何成像质量
        private double[,] threeLiTiGuanceMatrix;//三维立体观测能力

        private void coordinate_Paint(object sender, PaintEventArgs e)
        {
            double m1 = Convert.ToDouble(m1box.Text);
            double m2 = Convert.ToDouble(m2box.Text);
            double m3 = Convert.ToDouble(m3box.Text);
            //画两根直角坐标系
            AdjustableArrowCap acc = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 6);
            Pen pen = new Pen(Color.Black);
            pen.CustomEndCap = acc;
            e.Graphics.DrawLine(pen, 20, coordinatePanel.Height - 20, 20, 20);
            e.Graphics.DrawLine(pen, 20, coordinatePanel.Height - 20, coordinatePanel.Width - 20, coordinatePanel.Height - 20);

            e.Graphics.DrawLine(Pens.Red, 20, 60, (float)((coordinatePanel.Height - 80) * m1 + 20), coordinatePanel.Height - 20);//1
            e.Graphics.DrawLine(Pens.Gold, 20, coordinatePanel.Height - 20, (float)((coordinatePanel.Height - 80) * m1 + 20), 60);//2
            e.Graphics.DrawLine(Pens.Gold, (float)((coordinatePanel.Height - 80) * m1 + 20), 60, (float)((coordinatePanel.Height - 80) * m2 + 20), coordinatePanel.Height - 20);//3
            e.Graphics.DrawLine(Pens.Yellow, (float)((coordinatePanel.Height - 80) * m1 + 20), coordinatePanel.Height - 20, (float)((coordinatePanel.Height - 80) * m2 + 20), 60);//4
            e.Graphics.DrawLine(Pens.Yellow, (float)((coordinatePanel.Height - 80) * m2 + 20), 60, (float)((coordinatePanel.Height - 80) * m3 + 20), coordinatePanel.Height - 20);//5
            e.Graphics.DrawLine(Pens.LightGreen, (float)((coordinatePanel.Height - 80) * m2 + 20), coordinatePanel.Height - 20, (float)((coordinatePanel.Height - 80) * m3 + 20), 60);//6
            e.Graphics.DrawLine(Pens.LightGreen, (float)((coordinatePanel.Height - 80) * m3 + 20), 60, coordinatePanel.Height - 60, coordinatePanel.Height - 20);//7
            e.Graphics.DrawLine(Pens.LightBlue, (float)((coordinatePanel.Height - 80) * m3 + 20), coordinatePanel.Height - 20, coordinatePanel.Height - 60, 60);//8
            Pen dashPen = new Pen(Color.Black, 1);
            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawLine(dashPen, coordinatePanel.Height - 60, coordinatePanel.Height - 20, coordinatePanel.Height - 60, 60);//9

            m00.Location = new Point(20, (int)(coordinatePanel.Height - 15));//0定位
           
            m11.Location = new Point((int)((coordinatePanel.Height - 80) * m1 + 30), (int)(coordinatePanel.Height - 15));//m1定位
            m11.Text = m1box.Text.ToString();
            m22.Location = new Point((int)((coordinatePanel.Height - 80) * m2 + 30), (int)(coordinatePanel.Height - 15));//m2定位
            m22.Text = m2box.Text.ToString();
            m33.Location = new Point((int)((coordinatePanel.Height - 80) * m3 + 30), (int)(coordinatePanel.Height - 15));//m3定位
            m33.Text = m3box.Text.ToString();
            m5.Location = new Point((int)((coordinatePanel.Height - 60)), (int)(coordinatePanel.Height - 15));//1定位

            cha.Location = new Point(30, 50);//差定位

            jiaoCha.Location = new Point((int)((coordinatePanel.Height - 80) * m1 + 20), 50);//较差定位
            yiBan.Location = new Point((int)((coordinatePanel.Height - 80) * m2 + 20), 50);//一般定位
            liang.Location = new Point((int)((coordinatePanel.Height - 80) * m3 + 20), 50);//一般定位
            you.Location = new Point((int)((coordinatePanel.Height - 60)), 50);//一般定位
        }

        private void m1box_TextChanged(object sender, EventArgs e)
        {
            coordinatePanel.Refresh();
        }

        private void m2box_TextChanged(object sender, EventArgs e)
        {
            coordinatePanel.Refresh();
        }

        private void m3box_TextChanged(object sender, EventArgs e)
        {
            coordinatePanel.Refresh();
        }

        private void systemPerformResult_Click(object sender, EventArgs e)
        {

        }

        //定义权重向量

        private double[] comPerforVector;
        private double[] responseTimeVector;
        private double[] imageAbilityVector;
        private double[] coverAbilityVector;
        private double[] appSatisfyVector;
        private double[] starLandResouceVector;
        private double[] ratidationImageVector;
        private double[] geoImageVector;
        private double[] threeLiTiGuanceVector;
        //获取指标重要性比例算出权重向量或者直接获取权重向量
        private void boxText2Vector()
        {
            if (parameterComboBox.SelectedIndex == 0)
            {
                comPerforMatrix = new double[5, 5] {
                {1.0, response_image, response_cover,response_appSatisify, response_starLand  },
                {1.0/ response_image,1.0, image_cover,image_appSatisify, image_starLand},
                {1.0/ response_cover,1.0/image_cover,1.0,1.0/cover_appSatisify, cover_starLand},
                { 1.0/response_appSatisify,1.0/image_appSatisify ,1.0/cover_appSatisify,1.0,appSatisify_starLand},
                { 1.0/response_starLand ,1.0/image_starLand ,1.0/cover_starLand,1.0/appSatisify_starLand,1.0} };


                responseTimeMatrix = new double[9, 9] {
            {1.0,responseDelayTime_perTimeGuanceTask,responseDelayTime_RevisiteCycle,responseDelayTime_minTime,responseDelayTime_maxTime , responseDelayTime_neiborMinTime,responseDelayTime_neiborMaxTime,responseDelayTime_oneResponseTime,responseDelayTime_oneGuanceTime },
            {1.0/responseDelayTime_perTimeGuanceTask, 1.0,perTimeGuanceTask_RevisiteCycle,perTimeGuanceTask_minTime,perTimeGuanceTask_maxTime,perTimeGuanceTask_neiborMinTime,perTimeGuanceTask_neiborMaxTime ,perTimeGuanceTask_oneResponseTime,perTimeGuanceTask_oneGuanceTime},
            {1.0/responseDelayTime_RevisiteCycle,1.0/perTimeGuanceTask_RevisiteCycle, 1.0,RevisiteCycle_minTime,RevisiteCycle_maxTime,RevisiteCycle_neiborMinTime,RevisiteCycle_neiborMaxTime,RevisiteCycle_oneResponseTime,RevisiteCycle_oneGuanceTime},
            { 1.0/responseDelayTime_minTime,1.0/perTimeGuanceTask_minTime,1.0/RevisiteCycle_minTime,1.0,minTime_maxTime,minTime_neiborMinTime,minTime_neiborMaxTime,minTime_oneResponseTime,minTime_oneGuanceTime},
            { 1.0/responseDelayTime_maxTime ,1.0/perTimeGuanceTask_maxTime,1.0/RevisiteCycle_maxTime,1.0/minTime_maxTime,1.0,maxTime_neiborMinTime,maxTime_neiborMaxTime,neiborMaxTime_oneResponseTime, maxTime_oneGuanceTime},
            {1.0/ responseDelayTime_neiborMinTime, 1.0/perTimeGuanceTask_neiborMinTime,1.0/RevisiteCycle_neiborMinTime,1.0/minTime_neiborMinTime,1.0/maxTime_neiborMinTime,1.0,neiborMinTime_neiborMaxTime,neiborMinTime_oneResponseTime,neiborMinTime_oneGuanceTime},
            {1.0/responseDelayTime_neiborMaxTime,1.0/perTimeGuanceTask_neiborMaxTime , 1.0/RevisiteCycle_neiborMaxTime,1.0/minTime_neiborMaxTime,1.0/maxTime_neiborMaxTime,1.0/neiborMinTime_neiborMaxTime,1.0,neiborMaxTime_oneResponseTime,neiborMaxTime_oneGuanceTime},
            {1.0/responseDelayTime_oneResponseTime, 1.0/perTimeGuanceTask_oneResponseTime,1.0/RevisiteCycle_oneResponseTime,1.0/minTime_oneResponseTime,1.0/maxTime_oneResponseTime,1.0/neiborMinTime_oneResponseTime,1.0/neiborMaxTime_oneResponseTime,1.0,oneResponseTime_oneGuanceTime},
            {1.0/responseDelayTime_oneGuanceTime, 1.0/perTimeGuanceTask_oneGuanceTime,1.0/RevisiteCycle_oneGuanceTime,1.0/minTime_oneGuanceTime,1.0/ maxTime_oneGuanceTime,1.0/neiborMinTime_oneGuanceTime,1.0/neiborMaxTime_oneGuanceTime,1.0/oneResponseTime_oneGuanceTime,1.0} };

                imageAbilityMatrix = new double[2, 2] { { 1.0, radiationImage_geoImage }, {1.0/ radiationImage_geoImage ,1.0} };

                coverAbilityMatrix = new double[5, 5] { 
                    {1.0,coverRange_coverNum, coverRange_xianlingImageOverlap,coverRange_manyViewImageNum ,coverRange_danWeiTargetNum},
                    { 1.0/coverRange_coverNum,1.0,coverNum_xianlingImageOverlap,coverNum_manyViewImageNum ,coverNum_danWeiTargetNum},
                    {1.0/coverRange_xianlingImageOverlap, 1.0/coverNum_xianlingImageOverlap,1.0,xianlingImageOverlap_manyViewImageNum,xianlingImageOverlap_danWeiTargetNum},
                    { 1.0/coverRange_manyViewImageNum ,1.0/coverNum_manyViewImageNum ,1.0/xianlingImageOverlap_manyViewImageNum,1.0,manyViewImageNum_danWeiTargetNum},
                    { 1.0/coverRange_danWeiTargetNum,1.0/coverNum_danWeiTargetNum,1.0/xianlingImageOverlap_danWeiTargetNum,1.0/manyViewImageNum_danWeiTargetNum,1.0}};

                appSatisfyMatrix = new double[4, 4] { 
                {1.0, targetDetection_physisObservation, targetDetection_threeDimensional,targetDetection_dynamic},
                {1.0/targetDetection_physisObservation, 1.0,physisObservation_threeDimensional,physisObservation_dynamic},
                { 1.0/ targetDetection_threeDimensional,1.0/physisObservation_threeDimensional,1.0,threeDimensional_dynamic},
                {1.0/targetDetection_dynamic, 1.0/physisObservation_dynamic,1.0/threeDimensional_dynamic,1.0} };

                starLandResouceMatrix = new double[4, 4] { 
                    { 1.0,starResource_starEnergy,starResource_shuChuanResource, starResource_ceKong},
                { 1.0/starResource_starEnergy,1.0, starEnergy_shuChuanResource, starEnergy_ceKong},
                { 1.0/starResource_shuChuanResource,1.0/ starEnergy_shuChuanResource,1.0,shuChuanResource_ceKong},
                { 1.0/ starResource_ceKong,1.0/ starEnergy_ceKong,1.0/shuChuanResource_ceKong,1.0} };

                ratidationImageMatrix = new double[3, 3] {
                { 1.0,MTF_dynamicRange, MTF_sinal},
                { 1.0/MTF_dynamicRange,1.0,dynamicRange_sinal},
                {1.0/ MTF_sinal,1.0/dynamicRange_sinal,1.0 } };

                geoImageMatrix = new double[4, 4] {
                { 1.0,spatialReso_fuWidth,spatialReso_tiaoDai ,spatialReso_flatDingwei},
                { 1.0/spatialReso_fuWidth,1.0,fuWidth_tiaoDai,fuWidth_flatDingwei},
                {1.0/spatialReso_tiaoDai ,1.0/fuWidth_tiaoDai, 1.0,tiaoDai_flatDingwei},
                {1.0/spatialReso_flatDingwei, 1.0/fuWidth_flatDingwei,1.0/tiaoDai_flatDingwei,1.0} };

                threeLiTiGuanceMatrix = new double[3, 3] {
                {1.0,liTIFlatDingWei_liTiGaoChenDingwei, liTIFlatDingWei_ceTu},
                { 1.0/liTIFlatDingWei_liTiGaoChenDingwei,1.0,liTiGaoChenDingwei_ceTu},
                {1.0/liTIFlatDingWei_ceTu, 1.0/liTiGaoChenDingwei_ceTu,1.0} };

                comPerforVector=matrixTovector(comPerforMatrix);
                responseTimeVector = matrixTovector(responseTimeMatrix);
                imageAbilityVector = matrixTovector(imageAbilityMatrix);
                coverAbilityVector = matrixTovector(coverAbilityMatrix);
                appSatisfyVector = matrixTovector(appSatisfyMatrix);
                starLandResouceVector = matrixTovector(starLandResouceMatrix);
                ratidationImageVector = matrixTovector(ratidationImageMatrix);
                geoImageVector = matrixTovector(geoImageMatrix);
                threeLiTiGuanceVector = matrixTovector(threeLiTiGuanceMatrix);
            }          
            else {
                comPerforVector = new double[5] { Convert.ToDouble(responseTimetxt.Text.ToString()),
                    Convert.ToDouble(imageAbilitytxt.Text.ToString()),
                    Convert.ToDouble(coverAbilitytxt.Text.ToString()) ,
                    Convert.ToDouble(appSatisifytxt.Text.ToString()),
                    Convert.ToDouble(starResourcetxt.Text.ToString()) };

                responseTimeVector = new double[9] {
                    Convert.ToDouble(responseDelaytxt.Text.ToString()),
                    Convert.ToDouble(oneTastNumtxt.Text.ToString()),
                    Convert.ToDouble(revisitetxt.Text.ToString()),
                    Convert.ToDouble(minJiancetxt.Text.ToString()),
                    Convert.ToDouble(maxJiancetxt.Text.ToString()),
                    Convert.ToDouble(minNeibortxt.Text.ToString()),
                    Convert.ToDouble(maxNeibortxt.Text.ToString()),
                     Convert.ToDouble(oneResopnsetxt.Text.ToString()),
                      Convert.ToDouble(oneLianxutxt.Text.ToString())
                };

                imageAbilityVector = new double[2] {
                    Convert.ToDouble(radiationImagetxt.Text.ToString()),
                    Convert.ToDouble(geoImagetxt.Text.ToString())};

                coverAbilityVector = new double[5] {
                    Convert.ToDouble(coverRangetxt.Text.ToString()),
                    Convert.ToDouble(coverAreaNumtxt.Text.ToString()),
                    Convert.ToDouble(neiborImageOverlaptxt.Text.ToString()),
                    Convert.ToDouble(manyViewNumtxt.Text.ToString()),
                    Convert.ToDouble(oneAreaGuancetxt.Text.ToString()),
                };

                appSatisfyVector = new double[4] {
                    Convert.ToDouble(targetReconizetxt.Text.ToString()),
                    Convert.ToDouble(physicalDectiontxt.Text.ToString()),
                    Convert.ToDouble(threeDimensiontxt.Text.ToString()),
                    Convert.ToDouble(dynamicJiancetxt.Text.ToString()),
                };

                starLandResouceVector = new double[4] {
                    Convert.ToDouble(starResoucetxt.Text.ToString()),
                    Convert.ToDouble(starEnergytxt.Text.ToString()),
                    Convert.ToDouble(shuChuantxt.Text.ToString()),
                    Convert.ToDouble(ceKongtxt.Text.ToString()),
                };

                ratidationImageVector = new double[3] {
                    Convert.ToDouble(MTFtxt.Text.ToString()),
                    Convert.ToDouble(dynamicRangetxt.Text.ToString()),
                    Convert.ToDouble(sinaltxt.Text.ToString()),
                };

                geoImageVector = new double[4] {
                    Convert.ToDouble(spatialResotxt.Text.ToString()),
                    Convert.ToDouble(fuWidthtxt.Text.ToString()),
                    Convert.ToDouble(tiaoDaitxt.Text.ToString()),
                    Convert.ToDouble(perFlatDingweitxt.Text.ToString()),
                };

                threeLiTiGuanceVector = new double[3] {
                    Convert.ToDouble(liTiFlatDingweitxt.Text.ToString()),
                    Convert.ToDouble(liTiGaoChengtxt.Text.ToString()),
                    Convert.ToDouble(ceTutxt.Text.ToString()),
                };
            }
            //string str = "";
            //for (int i = 0; i < starLandResouceVector.GetLength(0); i++)
            //{
            //    str = str + starLandResouceVector[i].ToString() + ",";
            //}
            //MessageBox.Show(str);
        }
        #region
        //指标归一化后的值
        //指标归一化,每一个指标归一化后的值
        private double responseDelayTimeNor=1;//响应延迟
        private double perTimeGuanceTaskNor=0.76;//单位时间可观测任务数
        private double revisiteCycleNor=1;//重访周期
        private double minTimeNor=0.85;//最小连续监测时长
        private double maxTimeNor=0.75;//最大连续监测时长
        private double neiborMinTimeNor=0.69;//邻近观测最小时间监测
        private double neiborMaxTimeNor=0.88;//邻近观测最大时间监测
        private double oneResponseTimeNor=1;//单次任务响应时长
        private double oneGuanceTimeNor=0.95;//单次连续观测时长

        private double MTFNor=1;//MTF
        private double dynamicRangeNor=0.9;//动态范围
        private double sinalNor=0.85;//信噪比
        private double spatialResoNor=0.67;//空间分辨率
        private double fuWidthNor=1;//幅宽
        private double tiaoDaiNor=0.85;//条带长度
        private double flatDingweiNor=0.86;//单像平面定位精度

        private double converRangeNor=0.75;//覆盖范围
        private double coverTimeNor=0.89;//覆盖区域次数
        private double neiborOverlapNor=1;//相邻成像区域重叠度
        private double manyViewTimeNor=1;//多视角成像次数
        private double perRangeTargetNumNor=0.8;//单位区域可观测目标数

        private double liTIFlatDingWeiNor=0.89;//立体平面定位定位精度
        private double liTiGaoChenDingweiNor=0.9;//立体高程定位精度
        private double ceTuNor=0.59;//测图比例尺

        private double targetDetectionNor=0.81;//目标检测识别能力
        private double physisObservationNor=1;//物理特性探测能力
        private double dynamicNor=0.91;//动态监测能力

        private double starResourceNor=0.89;//星上存储资源利用率
        private double starEnergyNor=0.75;//星上能源利用率
        private double shuChuanNor=0.65;//数传资源利用率
        private double ceKong=0.66;//测控 

        //AHP-FCE计算
        private void AHPFCE_Click(object sender, EventArgs e)
        {
            boxText2Vector();
            double[] W =AHPFCEcalculate();
            //string str = "";
            //for (int i = 0; i < W.GetLength(0); i++)
            //{
            //    //for (int j = 0; j < W.GetLength(1); j++)
            //    //{
            //    //    str = str + W[i, j] + "!";
            //    //}

            //    //str = str + "\n";
            //    str = str + W[i] + ",";
            //}
            //MessageBox.Show(str);
            string[] Evaluation = new string[] { "差", "较差", "一般", "良", "优" };
           
            int index = 0;
            double Max = W[0];
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] > Max)
                {
                    Max = W[i];
                    index = i;
                }
                commentdataGrid.Rows[0].Cells[i].Value = W[i].ToString("f3");
            }
            AHPFCEresult.Text = "评估结果："+Evaluation[index].ToString();
            //MessageBox.Show(index.ToString()+Evaluation[index].ToString());
        }
        //这几个在后面进行体系贡献率计算的时候需要用到，多以public
        public double[] W21second_responseTime;
        public double[] W23second_coverAbility;
        public double[] W25second_starLand;
        public double[] W22second_imageAbility;
        public double[] W24second_appSatisify;

        double[] AHPFCEcalculate() {
            //第三层归一化指标变成一维数组

            double[] third_radiation = new double[3] { MTFNor, dynamicRangeNor, sinalNor };//辐射成像质量
            double[] third_geo = new double[4] { spatialResoNor, fuWidthNor, tiaoDaiNor, flatDingweiNor };//几何成像质量
            double[] third_three = new double[3] { liTIFlatDingWeiNor, liTiGaoChenDingweiNor, ceTuNor };//三维立体观测能力

            //第二层
            double[] second_responseTime = new double[9] { responseDelayTimeNor, perTimeGuanceTaskNor,
                revisiteCycleNor, minTimeNor, maxTimeNor,
                neiborMinTimeNor, neiborMaxTimeNor ,
                oneResponseTimeNor , oneGuanceTimeNor };//响应时效性
            double[] second_cover = new double[5] { converRangeNor, coverTimeNor, neiborOverlapNor , manyViewTimeNor, perRangeTargetNumNor };//覆盖能力
            double[] second_starLand = new double[4] { starResourceNor , starEnergyNor , shuChuanNor, ceKong };

            //第三层归一化指标的一维数组变模糊关系矩阵
            double[,] third_radiationR = index2Matrix(third_radiation);//辐射成像质量
            double[,] third_geoR = index2Matrix(third_geo);//几何成像质量
            double[,] third_threeR = index2Matrix(third_three);//三维立体观测能力

            //第三层模糊合成          
            double[] W11third_radiationImage = fuzzySynthesis(ratidationImageVector, third_radiationR);//辐射成像质量
            double[] W12third_geo = fuzzySynthesis(geoImageVector, third_geoR);//几何成像质量
            double[] W13third_three = fuzzySynthesis(threeLiTiGuanceVector, third_threeR);//三维立体观测能力

            //第二层模糊合成
            //响应时效性
            double[,] second_responseTimeR = index2Matrix(second_responseTime);
            W21second_responseTime = fuzzySynthesis(responseTimeVector, second_responseTimeR);//响应时效性模糊合成向量

            //成像能力
            double[][] temp1 = new double[][] { W11third_radiationImage , W12third_geo };
            double[,] second_imageR = mmToMatric(temp1);
            W22second_imageAbility = fuzzySynthesis(imageAbilityVector, second_imageR);//成像能力模糊合成向量

            //覆盖能力
            double[,] second_coverAbilityR = index2Matrix(second_cover);
            W23second_coverAbility = fuzzySynthesis(coverAbilityVector, second_coverAbilityR);

            //应用满足度
            double[] app1 = new double[1] { targetDetectionNor };//目标检测识别能力
            double[] app2 = new double[1] { physisObservationNor };//物理特性探测能力
            double[] app3 = new double[1] { dynamicNor };//动态监测能力
            double[] temp_app1 = sec2one(index2Matrix(app1));
            double[] temp_app2 = sec2one(index2Matrix(app2));
            double[] temp_app3 = sec2one(index2Matrix(app3));
            double[][] temp2 = new double[][] { temp_app1, temp_app2, W13third_three, temp_app3 };
            double[,] second_appSatisify = mmToMatric(temp2);
            W24second_appSatisify = fuzzySynthesis(appSatisfyVector, second_appSatisify);
            

            //星地资源利用
            double [,]second_starLandR = index2Matrix(second_starLand);
            W25second_starLand = fuzzySynthesis(starLandResouceVector, second_starLandR);

            //总的应用效能
            double[][] temp3 = new double[][] { W21second_responseTime , W22second_imageAbility , W23second_coverAbility , W24second_appSatisify , W25second_starLand };
            double[,] Q = mmToMatric(temp3);
            double[] O = fuzzySynthesis(comPerforVector, Q);

            return O;
        }

        //函数weightsTovector输入一个权重矩阵（对称）返回该矩阵的特征向量
        static double[] matrixTovector(double[,] weights)
        {

            int row = weights.GetLength(0);
            int column = weights.GetLength(1);
            double[] product_col = new double[row];//存每一行的连乘积 
            double[] sqrt_col = new double[row];//寸每一行连乘开根号后
            double sum = 0.0;//归一化的和
            //计算每一行的乘积   
            for (int i = 0; i < row; i++)
            {
                product_col[i] = 1;
                for (int j = 0; j < column; j++)
                {
                    product_col[i] = product_col[i] * weights[i, j];
                }
            }
            //开n次根号
            for (int i = 0; i < row; i++)
            {
                sqrt_col[i] = Math.Pow(product_col[i], 1.0 / row);
                sum = sum + sqrt_col[i];
            }
            for (int i = 0; i < row; i++)
            {
                sqrt_col[i] = sqrt_col[i] / sum;
            }
            return sqrt_col;//返回计算的特征值
        }
        //传入归一化指标向量，返回模糊关系矩阵
        public double[,] index2Matrix(double[] x)
        {
            double m1 = Convert.ToDouble(m1box.Text);
            double m2 = Convert.ToDouble(m2box.Text);
            double m3 = Convert.ToDouble(m3box.Text);
            int n = x.Length;
            double[] m = { 0, m1, m2, m3, 1 };//存取隶属度
            double[,] R = new double[n, 5];//指标模糊关系矩阵
            //计算隶属度
            for (int i = 0; i < n; i++)//计算隶属度
            {
                double xx = x[i];
                if (xx >= 0 && xx < m[1])
                {
                    R[i, 0] = (m[1] - xx) / m[1];
                }
                else
                {
                    R[i, 0] = 0.0;
                }
                for (int j = 1; j <= 3; j++)
                {
                    if (xx >= 0 && xx < m[j - 1])
                    {
                        R[i, j] = 0.0;
                    }
                    else if (xx >= m[j - 1] && xx < m[j])
                    {
                        R[i, j] = (xx - m[j - 1]) / (m[j] - m[j - 1]);
                    }
                    else if (xx >= m[j] && xx < m[j + 1])
                    {
                        R[i, j] = (m[j + 1] - xx) / (m[j + 1] - m[j]);
                    }
                    else
                    {
                        R[i, j] = 0.0;

                    }
                }
                if (xx >= 0 && xx < m[3])
                {
                    R[i, 4] = 0.0;
                }
                else
                {
                    R[i, 4] = (xx - m[3]) / (m[4] - m[3]);

                }
            }
            return R;
        }

        //权重向量，与模糊矩阵合成，第一个参数权重向量，第二个参数归一化指标放在隶属度函数之后的模糊矩阵。
        static double[] fuzzySynthesis(double[] vector, double[,] R)//模糊合成
        {
            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;
            Vector<double> vv = V.DenseOfArray(vector);
            Matrix<double> rr = M.DenseOfArray(R);
            double[] W = (vv * rr).ToArray();//将向量装换为一维数组
            return W;
        }

        //传入数组的数组，然后变为二维矩阵
        static double[,] mmToMatric(double[][] W123)//j将数组的数组转换为二维数组
        {
            int n = W123.GetLength(0);
            double[,] W = new double[n, 5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    W[i, j] = W123[i][j];
                }
            }
            return W;
        }

        //将一个二维的1乘1的转换为一维的1乘1的矩阵
        static double[] sec2one(double[,] W)
        {
            double [] w=new double[W.GetLength(1)];
            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                   w[j]=W[i,j];
                }
            }
            return w;
        }

        //体系贡献率连接线
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = contributionRateBtn.Location.X + contributionRateBtn.Width / 2.0;//btn1体系贡献率按钮的中下点
            btn1y = contributionRateBtn.Location.Y + contributionRateBtn.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//体系贡献率按钮的中下点

            btn2x = appPerformBtn.Location.X + appPerformBtn.Width / 2.0;//btn2是应用性能上中点
            btn2y = appPerformBtn.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是应用性能上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//体系贡献率按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 =y1;//应用性能按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = equipPerformBtn.Location.X + equipPerformBtn.Width / 2.0;//btn3装备性能按钮的上中点
            btn3y = equipPerformBtn.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//装备性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = targetPerfomBtn.Location.X + targetPerfomBtn.Width / 2.0;//btn4任务性能按钮的上中点
            btn4y = targetPerfomBtn.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//任务性能上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);
            //-------------------------------------------
            //---------------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8;
            btn5x = equipPerformBtn.Location.X + equipPerformBtn.Width / 2.0;//btn5装备性能按钮的中下点
            btn5y = equipPerformBtn.Location.Y + equipPerformBtn.Height;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//装备性能按钮的中下点

            btn6x = obserCoverageBtn.Location.X + obserCoverageBtn.Width / 2.0;//btn6观测覆盖范围上中点
            btn6y = obserCoverageBtn.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//btn6是观测覆盖范围上中点

            x5 = btn5x;
            y5 = btn5y + (btn6y - btn5y) / 2;//装备性能按钮下面的中点，重点
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));

            x6 = btn6x;
            y6 = y5;//观测覆盖范围上面的中点，重点
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));

            g.DrawLine(pen, btnPoint5, midPoint5);
            g.DrawLine(pen, midPoint5, midPoint6);
            g.DrawLine(pen, midPoint6, btnPoint6);

            btn7x = targetResponseBtn.Location.X + targetResponseBtn.Width / 2.0;//btn7任务响应时效性按钮的上中点
            btn7y = targetResponseBtn.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));

            x7 = btn7x;
            y7 = y5;//任务响应时效性上面的中点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));

            g.DrawLine(pen, btnPoint7, midPoint7);
            g.DrawLine(pen, midPoint7, midPoint5);
            //--------------------------------------------
            btn8x = starResouUseBtn.Location.X + starResouUseBtn.Width / 2.0;//btn8星地资源利用率按钮的上中点
            btn8y = starResouUseBtn.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));

            x8 = btn8x;
            y8 = y5;//任务性能上面的中点
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));

            g.DrawLine(pen, btnPoint8, midPoint8);
            g.DrawLine(pen, midPoint8, midPoint5);
            //--------------------------------------
            btn9x = appPerformBtn.Location.X + appPerformBtn.Width / 2.0;//btn9应用性能按钮的下中点
            btn9y = appPerformBtn.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));

            btn10x = imageAbilityBtn.Location.X + imageAbilityBtn.Width / 2.0;//btn10成像能力按钮的上中点
            btn10y = imageAbilityBtn.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, btnPoint9, btnPoint10);
            //--------------------------------------
            btn11x = targetPerfomBtn.Location.X + targetPerfomBtn.Width / 2.0;//btn11任务性能按钮的下中点
            btn11y = targetPerfomBtn.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            btn12x = appSatisifyBtn.Location.X + appSatisifyBtn.Width / 2.0;//btn12应用满足度按钮的上中点
            btn12y = appSatisifyBtn.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));
            g.DrawLine(pen, btnPoint11, btnPoint12);

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = contributionRateBtn2.Location.X + contributionRateBtn2.Width / 2.0;//btn1体系贡献率按钮的中下点
            btn1y = contributionRateBtn2.Location.Y + contributionRateBtn2.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//体系贡献率按钮的中下点

            btn2x = appPerformBtn2.Location.X + appPerformBtn2.Width / 2.0;//btn2是应用性能上中点
            btn2y = appPerformBtn2.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是应用性能上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//体系贡献率按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 = y1;//应用性能按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = equipPerformBtn2.Location.X + equipPerformBtn2.Width / 2.0;//btn3装备性能按钮的上中点
            btn3y = equipPerformBtn2.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//装备性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = targetPerfomBtn2.Location.X + targetPerfomBtn2.Width / 2.0;//btn4任务性能按钮的上中点
            btn4y = targetPerfomBtn2.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//任务性能上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);
            //-------------------------------------------
            //---------------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8;
            btn5x = equipPerformBtn2.Location.X + equipPerformBtn2.Width / 2.0;//btn5装备性能按钮的中下点
            btn5y = equipPerformBtn2.Location.Y + equipPerformBtn2.Height;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//装备性能按钮的中下点

            btn6x = obserCoverageBtn2.Location.X + obserCoverageBtn2.Width / 2.0;//btn6观测覆盖范围上中点
            btn6y = obserCoverageBtn2.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//btn6是观测覆盖范围上中点

            x5 = btn5x;
            y5 = btn5y + (btn6y - btn5y) / 2;//装备性能按钮下面的中点，重点
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));

            x6 = btn6x;
            y6 = y5;//观测覆盖范围上面的中点，重点
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));

            g.DrawLine(pen, btnPoint5, midPoint5);
            g.DrawLine(pen, midPoint5, midPoint6);
            g.DrawLine(pen, midPoint6, btnPoint6);

            btn7x = targetResponseBtn2.Location.X + targetResponseBtn2.Width / 2.0;//btn7任务响应时效性按钮的上中点
            btn7y = targetResponseBtn2.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));

            x7 = btn7x;
            y7 = y5;//任务响应时效性上面的中点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));

            g.DrawLine(pen, btnPoint7, midPoint7);
            g.DrawLine(pen, midPoint7, midPoint5);
            //--------------------------------------------
            btn8x = starResouUseBtn2.Location.X + starResouUseBtn2.Width / 2.0;//btn8星地资源利用率按钮的上中点
            btn8y = starResouUseBtn2.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));

            x8 = btn8x;
            y8 = y5;//任务性能上面的中点
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));

            g.DrawLine(pen, btnPoint8, midPoint8);
            g.DrawLine(pen, midPoint8, midPoint5);
            //--------------------------------------
            btn9x = appPerformBtn2.Location.X + appPerformBtn2.Width / 2.0;//btn9应用性能按钮的下中点
            btn9y = appPerformBtn2.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));

            btn10x = imageAbilityBtn2.Location.X + imageAbilityBtn2.Width / 2.0;//btn10成像能力按钮的上中点
            btn10y = imageAbilityBtn2.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, btnPoint9, btnPoint10);
            //--------------------------------------
            btn11x = targetPerfomBtn2.Location.X + targetPerfomBtn2.Width / 2.0;//btn11任务性能按钮的下中点
            btn11y = targetPerfomBtn2.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            btn12x = appSatisifyBtn2.Location.X + appSatisifyBtn2.Width / 2.0;//btn12应用满足度按钮的上中点
            btn12y = appSatisifyBtn2.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));
            g.DrawLine(pen, btnPoint11, btnPoint12);
        }
       
        //体系贡献率选择指标设置方法

        private void parameterComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parameterComboBox2.SelectedIndex == 0)
            {
                panel3.Visible = true;
                //panel2.Location = new Point(125, 28);
                panel4.Visible = false;
                panel3.Location = new Point(214, 108);
            }
            else
            {
                panel3.Visible = false;
                panel4.Location = new Point(214, 108);
                panel4.Visible = true;
                //panel1.Location = new Point(115, 30);
                
            }
        }


        #endregion
        public double equipmentPerfom_appPerform = 2,//装备性能—应用性能
            equipmentPerfom_taskPerfom = 3,//装备-任务
            appPerform_taskPerfom = 4;//应用-任务

        //体系贡献率按钮
        private void contributionRateBtn_Click_1(object sender, EventArgs e)
        {
            systemContriRate com = new systemContriRate();
            com.ShowDialog(this);
        }

        public double taskRespon_obserCoverRange = 4,//任务响应时效性—观测覆盖范围
           taskRespon_starResouUse = 5,//任务响应时效性—星地资源利用
           obserCoverRange_starResouUse = 6;//观测覆盖范围—星地资源利用
        private void equipPerformBtn_Click(object sender, EventArgs e)
        {
            equipmentPerform com = new equipmentPerform();
            com.ShowDialog(this);
        }

        private double[,] systemContriMatrix;//第一层权重矩阵，装备性能，应用性能，任务性能
        private double[,] equipmentMatrix;//装备性能权重矩阵

        private double[] systemContributionVector;//体系贡献率
        private double[] equipmentVector;//装备性能贡献率

        //获取重要性比例或者直接是权重,得到权重向量
        private void systemboxText2Vector() {
            if (parameterComboBox2.SelectedIndex == 0)
            {
                systemContriMatrix = new double[3, 3] {
                    {1,equipmentPerfom_appPerform, equipmentPerfom_taskPerfom},
                    { 1.0/equipmentPerfom_appPerform,1,appPerform_taskPerfom},
                    { 1.0/equipmentPerfom_taskPerfom,1.0/appPerform_taskPerfom,1}
                };
                equipmentMatrix = new double[3, 3] {
                    {1,taskRespon_obserCoverRange, taskRespon_starResouUse},
                    {1.0/taskRespon_obserCoverRange,1,obserCoverRange_starResouUse },
                    {1.0/taskRespon_starResouUse,1.0/obserCoverRange_starResouUse,1 }
                };

                equipmentVector = matrixTovector(equipmentMatrix);
                systemContributionVector = matrixTovector(systemContriMatrix);

            }
            else {
                systemContributionVector = new double[3] {
                    Convert.ToDouble(equipmentTxt.Text.ToString()),
                    Convert.ToDouble(appPerformTxt.Text.ToString()),
                    Convert.ToDouble(taskPerformTxt.Text.ToString()),
                };
                equipmentVector = new double[3] {
                    Convert.ToDouble(taskResponseTxt.Text.ToString()),
                    Convert.ToDouble(obserCoverRangeTxt.Text.ToString()),
                    Convert.ToDouble(starResourUseTxt.Text.ToString()),
                };
            }
        }

        //体系贡献率评估计算按钮
       
        private void AHPFCEsystemContribute_Click(object sender, EventArgs e)
        {
            systemboxText2Vector();
            double[] a = systemContributionCalculate();

            double[] b = { 0.2, 0.4, 0.6, 0.8, 1 };
            double result = 0;
            for (int i = 0; i < 5; i++)
            {
                result += a[i] * b[i];
            }
            systemPerformResult.Text = result.ToString("f3");
            //string str = "";
            //double[] a = systemContributionCalculate();
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    //for (int j = 0; j < systemContributionVector.GetLength(1); j++)
            //    //{
            //        str = str + a[i].ToString() + ",";
            //    //}
            //}

            //MessageBox.Show(str);
        }

        //响应时效性权重向量W21second_responseTime
        //观测覆盖范围W23second_coverAbility
        //星地资源利用率W25second_starLand
        //成像能力、应用性能W22second_imageAbility
        //应用满足度、任务性能W24second_appSatisify 
        double[] systemContributionCalculate()
        {
            double[][] temp1 = new double[][] { W21second_responseTime, W23second_coverAbility, W25second_starLand };
            double[,] equipmentR = mmToMatric(temp1);
            double[] WequipmentVector = fuzzySynthesis(equipmentVector, equipmentR);
            double[][] temp2 = new double[][] { WequipmentVector, W22second_imageAbility, W24second_appSatisify };
            double[,] systemContriR = mmToMatric(temp2);
            double[] WsystemVector = fuzzySynthesis(systemContributionVector, systemContriR);
            return WsystemVector;
        }
    }
}
