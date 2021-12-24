using System;

namespace Trixter.XDream.API.Testing
{
    public class LeastSquaresInterpolator
    {

        private double sumX = 0, sumY = 0, sumXY = 0, sumXX = 0, sumYY=0;
        int n = 0;

        public LeastSquaresInterpolator()
        {

        }

        public void Add(double x, double y)
        {
            this.sumX += x;
            this.sumY += y;
            this.sumXX += x * x;
            this.sumXY += x * y;
            this.sumYY += y * y;
            this.n++;
        }
           
               
        public void GetCoefficients(
            out double rSquared,
            out double slope,
            out double intercept)
        {                     
            var ssX = sumXX - (sumX*sumX/ n);
            var rNumerator = (n * sumXY) - (sumX*sumY);
            var rDenom = (n * sumXX - (sumX*sumX)) * (n * sumYY - (sumY*sumY));
            var sCo = sumXY - ((sumX * sumY) / n);

            var meanX = sumX/n;
            var meanY = sumY/n;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            rSquared = dblR * dblR;
            intercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }

    }
}
