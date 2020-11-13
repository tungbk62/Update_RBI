using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.BUS.BUSMSSQL_CAL.Table;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class CAL_DM_CARBONATE_CRACKING
    {
        //<Carboonate Cracking>
        // 1. material is carbon or allow stell
        // 2. Environment Content H2S
        // 3. PH > 7.5
        public String CACBONATE_INSP_EFF { set; get; }
        public int CACBONATE_INSP_NUM { set; get; }
        public float CO3_CONCENTRATION { set; get; }
        public float PH { set; get; }
        public Boolean CRACK_PRESENT { set; get; }
        public Boolean PWHT { set; get; }
        public Boolean EXPOSED_SULFUR { set; get; }
        public Boolean CARBON_ALLOY { set; get; }

        //</Carboonate Cracking>
        public string GET_SUSCEPTIBILITY_CARBONATE()
        {
            string sus = "None";
            if (CRACK_PRESENT) sus = "High";
            else if (PWHT)
            {
                sus = "None";
            }
            else
            {
                if (CO3_CONCENTRATION < 100)
                    sus = (PH >= 9.0) ? "High" : ((PH >= 7.5) ? "Low" : "None");
                else
                    sus = (PH >= 8.0) ? "High" : ((PH >= 7.5) ? "Medium" : "None");
            }
            return sus;
        }

        public string GET_SUSCEPTIBILITY_CARBONATE(bool crackPresent, bool phwt, float co3Concentration, float ph)
        {
            string sus = "None";
            if (crackPresent) sus = "High";
            else if (phwt)
            {
                sus = "None";
            }
            else
            {
                if (co3Concentration < 100)
                    sus = (ph >= 9.0) ? "High" : ((ph >= 7.5) ? "Low" : "None");
                else
                    sus = (ph >= 8.0) ? "High" : ((ph >= 7.5) ? "Medium" : "None");
            }
            return sus;
        }

        
        public int SVI_CARBONATE()
        {
            switch (GET_SUSCEPTIBILITY_CARBONATE())
            {
                case "High": return 1000;
                case "Medium": return 100;
                case "Low": return 10;
                default: return 0;
            }
        }
        private int SVI_CARBONATE(string getSusceptibilityCarbonate)
        {
            switch (getSusceptibilityCarbonate)
            {
                case "High": return 1000;
                case "Medium": return 100;
                case "Low": return 10;
                default: return 0;
            }
        }
        Table6_3 table = new Table6_3();
        public float DF_CACBONATEforBase(float age)
        {
            if (CARBON_ALLOY && EXPOSED_SULFUR && PH >= 7.5)
            {
                float DFB_CACBONATE = (float)table.LookupSCCDamageFactor(CACBONATE_INSP_EFF, CACBONATE_INSP_NUM, SVI_CARBONATE());
                return DFB_CACBONATE;
            }
            else
                return -1;
        }
        public float BASE_VALUE(bool carbon_alloy, bool exposed_sulfur, float ph, string cacbonate_insp_eff, int cacbonate_insp_num, int svi)
        {
            float baseValue = -1;
            if (carbon_alloy && exposed_sulfur && ph >= 7.5)
            {
                baseValue = (float)table.LookupSCCDamageFactor(cacbonate_insp_eff, cacbonate_insp_num, svi);
                return baseValue;
            }
            else
                return baseValue;
        }
        public float DF_CACBONATE(float age)
        {
            if (CARBON_ALLOY && EXPOSED_SULFUR && PH >= 7.5)
            {
                float DFB_CACBONATE = (float)table.LookupSCCDamageFactor(CACBONATE_INSP_EFF, CACBONATE_INSP_NUM, SVI_CARBONATE());
                return DFB_CACBONATE * (float)Math.Pow(Math.Max(age, 1.0), 1.1);
            }
            else
                return -1;
        }
        private float[] DF_CACBONATE(float[] age, float baseValue)
        {
            float[] result = { 0, 0, 0 };
            if (baseValue > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    result[i] = baseValue * (float)Math.Pow(Math.Max(age[i], 1.0), 1.1);
                }
                return result;
            }
            else
                return result;
        }

        public Tuple<string, int, float[], float, float[]> Calculate(float[] age, bool crackPresent, bool phwt, float co3Concentration, float ph, bool carbon_alloy, bool exposed_sulfur, string cacbonate_insp_eff, int cacbonate_insp_num)
        {
            string sus = GET_SUSCEPTIBILITY_CARBONATE(crackPresent, phwt, co3Concentration, ph);
            int svi = SVI_CARBONATE(sus);
            //float[] yearSinceLastInspection = { 0, 0, 0 };
            float baseValue = BASE_VALUE(carbon_alloy, exposed_sulfur, ph, cacbonate_insp_eff, cacbonate_insp_num, svi);
            float[] result = DF_CACBONATE(age, baseValue);
            var tuple = new Tuple<string, int, float[], float, float[]>(sus, svi, age, baseValue, result);
            return tuple;
        }
    }

}
