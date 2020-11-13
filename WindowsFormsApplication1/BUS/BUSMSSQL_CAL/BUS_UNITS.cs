using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class BUS_UNITS
    {
        public double NpM2 = Math.Pow(10,-6); // mặc định MPA
        public double meter = 1000;
        public double NpCM2 = 0.01; // MPA
        public double psi = 0.00689476; // MPA áp suất
        public double bar = 0.1; // MPA áp suất
        public double ksi = 6.89476; // MPA  kg/in
        public double inch = 25.4; // mm
        public double mil = 0.0254; // mm mặc định: đổi mil sang mm
        public double ft3 = 0.028316846592; //m3
        public double FahToCel(double fah) // mặc định độ C
        {
            return (fah - 32) * 5 / 9;
        }
        public double KenvinToCel(double k)
        {
            return k - 273;
        }
        public double CelToFah(double cel)
        {
            return cel * 1.8 + 32;
        }
        public double CelToKenvin(double cel)
        {
            return cel + 273;
        }
    }
}
