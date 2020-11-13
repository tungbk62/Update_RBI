using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;
using RBI.Object.ObjectMSSQL_CAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL.MSSQL_CAL;
using RBI.BUS.BUSMSSQL_CAL;

namespace RBI.BUS.BUSMSSQL_CAL
{
    public class MSSQL_CA_CAL_FINAL
    {
        MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
        //MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE();
        //MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC();
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();
        API_COMPONENT_TYPE_BUS API_COMPONENT_BUS = new API_COMPONENT_TYPE_BUS();
        public string API_COMPONENT_TYPE_NAME { get; set; }
        public float MATERIAL_COST { get; set; }
        public float EQUIPMENT_COST { get; set; }
        public float PRODUCTION_COST { get; set; }
        public float PERSON_DENSITY { get; set; }
        public float INJURE_COST { get; set; }
        public String FLUID { get; set; }
        public float ENVIRON_COST { get; set; }
        public float Outage_mul { get; set; }
        public int IDProposal { get; set; }
        public String RELEASE_DURATION { set; get; }
        public String TOXIC_PHASE { set; get; }
        public String FLUID_TOXIC { get; set; }
        public String FLUID_PHASE { set; get; }
        public float TOXIC_PERCENT { get; set; }
        public float STORE_TEMP { get; set; }



        public API_COMPONENT_TYPE GET_DATA_API_COM()
        {
            return API_COMPONENT_BUS.getData(API_COMPONENT_TYPE_NAME);
        }
        public String GET_AMBIENT()
        {
            //Console.WriteLine(DAL_CAL.GET_RELEASE_PHASE(FLUID));
            return DAL_CAL.GET_RELEASE_PHASE(FLUID);
        }
        //public String GET_AMBIENT_TOXIC()
        //{
        //    //Console.WriteLine(DAL_CAL.GET_RELEASE_PHASE(FLUID));
        //    return DAL_CAL.GET_RELEASE_PHASE(FLUID_TOXIC);
        //}
        public float GET_NBP()
        {
            //Console.WriteLine(DAL_CAL.GET_NBP(FLUID));
            return DAL_CAL.GET_NBP(FLUID);
        }
        //public float GET_NBP_TOXIC()
        //{
        //    //Console.WriteLine(DAL_CAL.GET_NBP(FLUID));
        //    return DAL_CAL.GET_NBP(FLUID_TOXIC);
        //}
        public String GET_RELEASE_PHASE()
        {
            if (FLUID_PHASE == "Gas")
            {
                return "Gas";
            }
            else if (GET_AMBIENT() == "Liquid" && FLUID_PHASE == "Liquid")
            {
                return "Liquid";
            }
            else if (GET_NBP() <= 300)
            {
                return "Liquid";
            }
            else
                return "Gas";
        }
        // Step 12: financial
        public float fc_cmd() //Component Damage Cost
        {           
            float fc_cmd = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            float t = 0;
            t = obj.GFFSmall * obj.HoleCostSmall + obj.GFFMedium * obj.HoleCostMedium + obj.GFFLarge * obj.HoleCostLarge + obj.GFFRupture * obj.HoleCostRupture;
            fc_cmd = t * MATERIAL_COST / obj.GFFTotal;
            return fc_cmd;
        }
        public float fc_affa() //Damage Costs to Surrounding Equipment in Affected Area
        {
            float fc_affa = 0;
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE(FLUID, API_COMPONENT_TYPE_NAME, IDProposal, STORE_TEMP, FLUID_TOXIC, FLUID_PHASE);
            float cacmd = CA_CAL_FLA.ca_cmd();
            fc_affa = cacmd * EQUIPMENT_COST;
            return fc_affa;
        }
        public float outage_cmd()
        {
            float outage_cmd = 0;
            float t = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            t = obj.GFFSmall * obj.OutageSmall + obj.GFFMedium * obj.OutageMedium + obj.GFFLarge * obj.OutageLarge + obj.GFFRupture * obj.OutageRupture;
            outage_cmd = t / obj.GFFTotal * Outage_mul;
            return outage_cmd;
        }
        public float outage_affa()
        {
            float outage_affa = 0;
            float fcaffa = Math.Abs(fc_affa());
            float b = (float)(1.242 + 0.585 * Math.Log10(fcaffa * Math.Pow(10, -6)));
            outage_affa = (float)Math.Pow(10, b);
            return outage_affa;
        }
        public float fc_prod() //Business Interruption Costs 
        {
            float fc_prod = (outage_cmd() + outage_affa()) * PRODUCTION_COST;
            return fc_prod;
        }
        public float fc_inj(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase) //Potential Injury Costs
        {
            MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC(FLUID, API_COMPONENT_TYPE_NAME, IDProposal, STORE_TEMP, FLUID_TOXIC, FLUID_PHASE, RELEASE_DURATION, TOXIC_PHASE, TOXIC_PERCENT);
            float fc_inj = CA_CAL_TOX.ca_inj(releasetype1, releasetype2, releasetype3, releasetype4, ToxicName, releasephase) * PERSON_DENSITY * INJURE_COST;
            return fc_inj;
        }
        public float vol_n_env(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS bus = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bus.getData(IDProposal);
            float vol_n_env = 0;
            float frac_evap = 1;
            switch (FLUID)
            {
                case "C6-C8":
                    frac_evap = 0.9f;
                    break;
                case "Acid":
                    frac_evap = 0.9f;
                    break;
                case "C9-C12":
                    frac_evap = 0.5f;
                    break;
                case "C13-C16":
                    frac_evap = 0.1f;
                    break;
                case "C17-C25":
                    frac_evap = 0.05f;
                    break;
                case "C25+":
                    frac_evap = 0.02f;
                    break;
                case "Nitric Acid":
                    frac_evap = 0.8f;
                    break;
                case "NO2":
                    frac_evap = 0.75f;
                    break;
                case "EE":
                    frac_evap = 0.75f;
                    break;
                case "TDI":
                    frac_evap = 0.15f;
                    break;
                case "Styrene":
                    frac_evap = 0.6f;
                    break;
                case "EEA":
                    frac_evap = 0.65f;
                    break;
                case "EG":
                    frac_evap = 0.45f;
                    break;
                default:
                    frac_evap = 1;
                    break;
            }
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            if (n == 1)
            {
                vol_n_env = (float)(1.8* obj.mass_1 * (1 - frac_evap) / (data[1] * 16.02));
            }
            if (n == 2)
            {
                vol_n_env = (float)(1.8* obj.mass_2 * (1 - frac_evap) / (data[1] * 16.02));
            }
            if (n == 3)
            {
                vol_n_env = (float)(1.8* obj.mass_3 * (1 - frac_evap) / (data[1] * 16.02));
            }
            if (n == 4)
            {
                vol_n_env = (float)(1.8 * obj.mass_4 * (1 - frac_evap) / (data[1] * 16.02));
            }
            return vol_n_env;
        }
        public float fc_environ() //Environmental Cleanup Costs
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            float fc_environ = 0;
            float t = 0;
            t = obj.GFFSmall * vol_n_env(1) + obj.GFFMedium * vol_n_env(2) + obj.GFFLarge * vol_n_env(3) + obj.GFFRupture * vol_n_env(4);
            fc_environ = t * ENVIRON_COST / obj.GFFTotal;
            return fc_environ;
        }
        public float fc(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        {
            float fc = 0;
            float fccmd = fc_cmd();
            float fcaffa = fc_affa();
            float fcprod = fc_prod();
            float fcinj = fc_inj( releasetype1,  releasetype2,  releasetype3,  releasetype4,  ToxicName,  releasephase);
            float fcenviron = fc_environ();
            fc = fccmd + fcaffa + fcprod + fcinj + fcenviron;
            return fc;
        }
    }
}
