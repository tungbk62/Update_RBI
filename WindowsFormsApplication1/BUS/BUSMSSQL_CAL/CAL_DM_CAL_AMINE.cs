using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.BUS.BUSMSSQL_CAL.Table;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class CAL_DM_CAL_AMINE
    {
        private string getSusceptibility_Amine(bool CRACK_PRESENT, bool PWHT, bool AMINE_EXPOSED, string AMINE_SOLUTION, float MAX_OP_TEMP, bool HEAT_TRACE , bool STEAM_OUT)
        {
            string sus = null;
            if (CRACK_PRESENT) sus = "High";
            else if (PWHT) sus = "None";
            else if (!AMINE_EXPOSED) sus = "None";
            else
            {
                if (AMINE_SOLUTION == "Methyldiethanolamine MDEA" || AMINE_SOLUTION == "Disopropanolamine DIPA")
                {
                    if (MAX_OP_TEMP > 82.22f) sus = "High";
                    else if ((MAX_OP_TEMP < 82.22f && MAX_OP_TEMP > 37.78f) || HEAT_TRACE || STEAM_OUT) sus = "Medium";
                    else sus = "Low";
                }
                else if (AMINE_SOLUTION == "Diethanolamine DEA")
                {
                    if (MAX_OP_TEMP > 82.22f) sus = "Medium";
                    else if ((MAX_OP_TEMP < 82.22f && MAX_OP_TEMP > 60f) || HEAT_TRACE || STEAM_OUT) sus = "Low";
                    else sus = "None";
                }
                else
                {
                    sus = ((MAX_OP_TEMP > 82.22f) || HEAT_TRACE || STEAM_OUT) ? "Low" : "None";
                }
            }
            return sus;
        }
        private int SVI_AMINE(string getSusceptibility_Amine)
        {
            switch (getSusceptibility_Amine)
            {
                case "High": return 1000;
                case "Medium": return 100;
                case "Low": return 10;
                default: return 0;
            }
        }
        
        public float BASE_VALUE(bool carbon_alloy, bool exposed_sulfur, string cacbonate_insp_eff, int cacbonate_insp_num, int svi)
        {
            float baseValue = -1;
            if (carbon_alloy && exposed_sulfur)
            {
                Table6_3 table = new Table6_3();
                baseValue = (float)table.LookupSCCDamageFactor(cacbonate_insp_eff, cacbonate_insp_num, svi);
                return baseValue;
            }
            else
                return baseValue;
        }
        
        private float[] DFB_AMIN(float[] age, float baseValue)
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

        public Tuple<string, int, float[], float, float[]> Calculate(float[] age, bool CRACK_PRESENT, bool PWHT, bool AMINE_EXPOSED, string AMINE_SOLUTION, float MAX_OP_TEMP, bool HEAT_TRACE, bool STEAM_OUT, bool carbon_alloy, bool exposed_sulfur, string cacbonate_insp_eff, int cacbonate_insp_num)
        {
            string sus = getSusceptibility_Amine( CRACK_PRESENT, PWHT, AMINE_EXPOSED, AMINE_SOLUTION, MAX_OP_TEMP, HEAT_TRACE, STEAM_OUT);
            int svi = SVI_AMINE(sus);
            float baseValue = BASE_VALUE(carbon_alloy, exposed_sulfur, cacbonate_insp_eff,cacbonate_insp_num, svi);
            float[] result = DFB_AMIN(age, baseValue);
            var tuple = new Tuple<string, int, float[], float, float[]>(sus, svi, age, baseValue, result);
            return tuple;
        }
    }
}
