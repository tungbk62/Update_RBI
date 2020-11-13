using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.BUS.BUSMSSQL_CAL.Table;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class CAL_DM_SCC_CRACKING
    {
        //<Sulphide Stress Cracking>
        // 1. material is carbon or allow stell
        // 2. the process environment contains water(Aqueous Phase During Operation)
        // 3. Environment Content H2S
        public Boolean ENVIRONMENT_H2S_CONTENT { set; get; }
        public Boolean AQUEOUS_OPERATOR { set; get; } // true
        public Boolean AQUEOUS_SHUTDOWN { set; get; }
        public string SULPHIDE_INSP_EFF { set; get; }
        public int SULPHIDE_INSP_NUM { set; get; }
        public float H2SContent { set; get; }
        public float PH { set; get; }
        public bool PRESENT_CYANIDE { set; get; }
        public String BRINNEL_HARDNESS { set; get; }
        public bool CRACK_PRESENT { set; get; }
        public bool PWHT { set; get; }
        public bool CARBON_ALLOY { set; get; } // "True"

        //Intermediate Results
        public string ENVIRONMENTAL_SEVERITY { set; get; }
        public string SUSCEPTIBILITY { set; get; }
        public int SVI { set; get; }
        public int BASE { set; get; }
        


        public string GET_ENVIRONMENTAL_SEVERITY()
        {
            string env = null;
            if (PH < 5.5)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }
            else if (PH <= 7.5 && PH >= 5.5)
            {
                if (H2SContent > 10000) env = "Moderate";
                else env = "Low";
            }
            else if (PH >= 7.6 && PH <= 8.3)
            {
                if (H2SContent < 50) env = "Low";
                else env = "Moderate";
            }
            else if (PH >= 8.4 && PH <= 8.9)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 10000 && PRESENT_CYANIDE) env = "High";
                else if (H2SContent <= 10000) env = "Moderate";
                else env = "High";
            }
            else
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }
            return env;
        }
        public string GET_SUSCEPTIBILITY_SULPHIDE()
        {
            string sus = "None";
            string env = ENVIRONMENTAL_SEVERITY;
            if (CRACK_PRESENT) sus = "High";
            else if (PWHT)
            {
                if (BRINNEL_HARDNESS == "Below 200") sus = "None";
                else if (BRINNEL_HARDNESS == "Between 200 and 237")
                {
                    sus = (env == "High") ? "Low" : "None";
                }
                else
                {
                    sus = (env == "High") ? "Medium" : (env == "Moderate" ? "Low" : "None");
                }
            }
            else
            {
                if (BRINNEL_HARDNESS == "Below 200") sus = "Low";
                else if (BRINNEL_HARDNESS == "Between 200 and 237")
                {
                    sus = (env == "Low") ? "Low" : "Medium";
                }
                else
                {
                    sus = (env == "Low") ? "Medium" : "High";
                }
            }
            return sus;
        }
        public int SVI_SULPHIDE()
        {
            switch (SUSCEPTIBILITY)
            {
                case "High": return 100;
                case "Medium": return 10;
                case "Low": return 1;
                default: return 0;
            }
        }
        public float DF_SULPHIDE(float age)
        {
            Table6_3 _table = new Table6_3();
            if (CARBON_ALLOY && AQUEOUS_OPERATOR && ENVIRONMENT_H2S_CONTENT)
            {
                float DFB_SULPHIDE = (float)_table.LookupSCCDamageFactor(SULPHIDE_INSP_EFF, SULPHIDE_INSP_NUM, SVI_SULPHIDE());
                //Console.WriteLine("DF_SULPHIDE = " + DFB_SULPHIDE * (float)Math.Pow(Math.Max(age, 1.0), 1.1));
                return DFB_SULPHIDE * (float)Math.Pow(Math.Max(age, 1.0), 1.1);
            }
            else
                return -1;
        }
    }
}
