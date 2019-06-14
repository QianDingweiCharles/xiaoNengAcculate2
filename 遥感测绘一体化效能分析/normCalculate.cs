using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Integration;
using MathNet.Numerics;

namespace 遥感测绘一体化效能分析
{
    class normCalculate
    {
        public normCalculate()
        {

        }
        //计算重访周期
        //T5为下次观测到该目标的时间
        //T4为某次观测到某目标的时间
        public double reVisiteTimeCal(double T5, double T4)
        {
            return T5 - T4;
        }

        //计算最小连续观测时长
        //传入不同任务下面有很多条记录，找到这个任务里面很多条记录里面的最小的相对时间，所组成数组
        public double minContinueObservation(double[] time)
        {
            return time.Min();
        }

        //计算最大连续观测时长
        //传入不同任务下面有很多条记录，找到这个任务里面很多条记录里面的最大的相对时间，所组成数组
        public double maxContinueObservation(double[] time)
        {
            return time.Max();
        }

        //计算信噪比
        public double SNR(double reflectivity, double altitudeAngle, double AOD, 
            double viewAngle, double sensorSize, double cameraSize,
            double initialBand, double endBand, double integralTime)
        {
            double f = 1.0 / (2 * integralTime);
            double tao = Math.Exp(-1 * AOD);
            double A0 = 3.14 * (cameraSize / 2.0) * (cameraSize / 2.0);
            double D = cameraSize * Math.Sqrt(sensorSize * f);//D不确定
            double snr = D * reflectivity * viewAngle * A0 * tao * Math.Cos(altitudeAngle) * Math.Sqrt(integralTime) * Integrate.OnClosedInterval(x => x * x, 0, 10);
            return snr;
        }
    }
}
