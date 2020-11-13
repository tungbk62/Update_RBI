using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class CAL_DM_EXTERN_CUI_CLSCC //external clscc
    {
        ///<summary>
        /// CAL EXTERN CUI CLSCC
        ///</summary>
        
        //Step 1
        private String CUI_CLSCC_SUSCEP(bool CRACK_PRESENT, string EXTERNAL_EVIRONMENT, float MAX_OP_TEMP)
        {
            String SUSCEP = null;
            if (CRACK_PRESENT)
                SUSCEP = "High";
            else
            {
                if (EXTERNAL_EVIRONMENT == "Arid/dry")
                {
                    if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "Low";
                    else
                        SUSCEP = "Not";
                }
                else if (EXTERNAL_EVIRONMENT == "Marine")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "High";
                    else
                        SUSCEP = "Medium";
                }
                else if (EXTERNAL_EVIRONMENT == "Severe")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else
                        SUSCEP = "High";
                }
                else if (EXTERNAL_EVIRONMENT == "Temperate")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "Medium";
                    else
                        SUSCEP = "Low";
                }
                else
                    SUSCEP = "Not";
            }
            return SUSCEP;
        }
        //Step 2
        private int SVI(string getCUI_CLSCC_SUSCEP)
        {
            if (getCUI_CLSCC_SUSCEP == "High")
                return 50;
            else if (getCUI_CLSCC_SUSCEP == "Medium")
                return 10;
            else
                return 1;
        }
        //Step 3
        /*public float[] InServiceTime(DateTime AssessmentDate, DateTime ParameterDate, int[] AP)
        {
            float[] numArray = new float[3];
            for (int i = 0; i < 3; i++)
            {
                TimeSpan span = (TimeSpan)(AssessmentDate - ParameterDate);
                numArray[i] = Math.Max((float)0.0, (float)((span.TotalDays / 365.0) + (((float)AP[i]) / 12.0)));
            }
            return numArray;
        }

        
        */
    }
}
