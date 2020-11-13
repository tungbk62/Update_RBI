using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL_CAL.Table
{
    class Table6_3
    {
        private Dictionary<double, double[]> TableA = new Dictionary<double, double[]>();
        private Dictionary<double, double[]> TableB = new Dictionary<double, double[]>();
        private Dictionary<double, double[]> TableC = new Dictionary<double, double[]>();
        private Dictionary<double, double[]> TableD = new Dictionary<double, double[]>();
        private Dictionary<double, double[]> TableE = new Dictionary<double, double[]>();

        public Table6_3()
        {
            this.TableA.Add(1.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(10.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(50.0, new double[] { 3.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(100.0, new double[] { 5.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(500.0, new double[] { 25.0, 5.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(1000.0, new double[] { 50.0, 10.0, 2.0, 1.0, 1.0, 1.0 });
            this.TableA.Add(5000.0, new double[] { 250.0, 50.0, 10.0, 2.0, 1.0, 1.0 });
            this.TableB.Add(1.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableB.Add(10.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableB.Add(50.0, new double[] { 5.0, 2.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableB.Add(100.0, new double[] { 10.0, 4.0, 2.0, 1.0, 1.0, 1.0 });
            this.TableB.Add(500.0, new double[] { 50.0, 20.0, 8.0, 2.0, 1.0, 1.0 });
            this.TableB.Add(1000.0, new double[] { 100.0, 40.0, 16.0, 5.0, 2.0, 1.0 });
            this.TableB.Add(5000.0, new double[] { 500.0, 250.0, 80.0, 25.0, 5.0, 2.0 });
            this.TableC.Add(1.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableC.Add(10.0, new double[] { 3.0, 2.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableC.Add(50.0, new double[] { 17.0, 10.0, 5.0, 2.0, 1.0, 1.0 });
            this.TableC.Add(100.0, new double[] { 33.0, 20.0, 10.0, 5.0, 2.0, 1.0 });
            this.TableC.Add(500.0, new double[] { 170.0, 100.0, 50.0, 25.0, 10.0, 5.0 });
            this.TableC.Add(1000.0, new double[] { 330.0, 200.0, 100.0, 50.0, 25.0, 10.0 });
            this.TableC.Add(5000.0, new double[] { 1670.0, 1000.0, 500.0, 250.0, 125.0, 50.0 });
            this.TableD.Add(1.0, new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 });
            this.TableD.Add(10.0, new double[] { 8.0, 6.0, 4.0, 2.0, 1.0, 1.0 });
            this.TableD.Add(50.0, new double[] { 40.0, 30.0, 20.0, 10.0, 5.0, 1.0 });
            this.TableD.Add(100.0, new double[] { 80.0, 60.0, 40.0, 20.0, 10.0, 5.0 });
            this.TableD.Add(500.0, new double[] { 400.0, 300.0, 200.0, 100.0, 50.0, 25.0 });
            this.TableD.Add(1000.0, new double[] { 800.0, 600.0, 400.0, 200.0, 100.0, 50.0 });
            this.TableD.Add(5000.0, new double[] { 4000.0, 3000.0, 2000.0, 1000.0, 500.0, 250.0 });
        }
       
        public double? LookupSCCDamageFactor(string eff, int nInspections, double severity)
        {
            if ((severity < 1.0) || (nInspections < 1))
            {
                return new double?(severity);
            }
            if (nInspections > 6)
            {
                nInspections = 6;
            }
            switch (eff)
            {
                case "E":
                    return new double?(severity);

                case "B":
                    return new double?(this.TableB[severity][nInspections - 1]);

                case "C":
                    return new double?(this.TableC[severity][nInspections - 1]);

                case "D":
                    return new double?(this.TableD[severity][nInspections - 1]);

                case "A":
                    return new double?(this.TableA[severity][nInspections - 1]);
            }
            return null;
        }
    }
}
