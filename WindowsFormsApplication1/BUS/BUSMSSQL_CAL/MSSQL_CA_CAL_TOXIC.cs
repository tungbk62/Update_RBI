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
    public class MSSQL_CA_CAL_TOXIC
    {
        public float TOXIC_PERCENT { get; set; }
        public String FLUID { set; get; }
        public String FLUID_TOXIC { get; set; }
        public String FLUID_PHASE { set; get; }
        public String RELEASE_DURATION { set; get; }
        public String TOXIC_PHASE { set; get; }
        public string API_COMPONENT_TYPE_NAME { get; set; }
        public int IDProposal { get; set; }
        public float STORE_TEMP { get; set; }

        API_COMPONENT_TYPE_BUS API_COMPONENT_BUS = new API_COMPONENT_TYPE_BUS();
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();        
        MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
        
        public MSSQL_CA_CAL_TOXIC(String f, String api, int id, float Ts, String ft, String ff, String rd,String tp, float tper)
        {
            FLUID = f;
            API_COMPONENT_TYPE_NAME = api;
            IDProposal = id;
            STORE_TEMP = Ts;
            FLUID_TOXIC = ft;
            FLUID_PHASE = ff;
            RELEASE_DURATION = rd;
            TOXIC_PHASE = tp;
            TOXIC_PERCENT = tper;
        }
        public MSSQL_CA_CAL_TOXIC()
        {

        }
        public API_COMPONENT_TYPE GET_DATA_API_COM()
        {
            return API_COMPONENT_BUS.getData(API_COMPONENT_TYPE_NAME);
        }
        public String GET_AMBIENT()
        {
            //Console.WriteLine(DAL_CAL.GET_RELEASE_PHASE(FLUID));
            return DAL_CAL.GET_RELEASE_PHASE(FLUID);
        }
        public String GET_AMBIENT_TOXIC()
        {
            //Console.WriteLine(DAL_CAL.GET_RELEASE_PHASE(FLUID));
            return DAL_CAL.GET_RELEASE_PHASE(FLUID_TOXIC);
        }
        public float GET_NBP()
        {
            //Console.WriteLine(DAL_CAL.GET_NBP(FLUID));
            return DAL_CAL.GET_NBP(FLUID);
        }
        public float GET_NBP_TOXIC()
        {
            //Console.WriteLine(DAL_CAL.GET_NBP(FLUID));
            return DAL_CAL.GET_NBP(FLUID_TOXIC);
        }
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
        public float toxic_leak_duration(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            float ld = 0;
            if (n == 1)
            {
                float ld1 = Math.Min(3600, (hole.mass_1 / hole.W1));
                float ld2 = Math.Min((hole.mass_1 / hole.W1), 60*hole.ld_max_1);
                ld = Math.Min(ld1, ld2);
            }
            else if (n == 2)
            {
                float ld1 = Math.Min(3600, (hole.mass_2 / hole.W2));
                float ld2 = Math.Min((hole.mass_2 / hole.W2), 60 * hole.ld_max_2);
                ld = Math.Min(ld1, ld2);
            }
            else if (n == 3)
            {
                float ld1 = Math.Min(3600, (hole.mass_3 / hole.W3));
                float ld2 = Math.Min((hole.mass_3 / hole.W3), 60 * hole.ld_max_3);
                ld = Math.Min(ld1, ld2);
            }
            else if (n==4)
            {
                double ld1 = (float)Math.Min(3600, Math.Round((hole.mass_4 / hole.W4),5));
                double ld2 = (float)Math.Min((hole.mass_4 / hole.W4), 60 * hole.ld_max_4);
                ld = (float)Math.Min(ld1, ld2);
            }
            
            return ld;
        }
        public float rate_tox_n(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushole.getData(IDProposal);
            float rate_tox = 0;
            if (n == 1)
            {
                rate_tox = TOXIC_PERCENT * obj.W1;
            }
            else if (n == 2)
            {
                rate_tox = TOXIC_PERCENT * obj.W2;
            }
            else if (n == 3)
            {
                rate_tox = TOXIC_PERCENT * obj.W3;
            }
            else
            {
                rate_tox = TOXIC_PERCENT * obj.W4;
            }
            return rate_tox;

        }
        public float mass_tox_n(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushole.getData(IDProposal);
            float mass_tox = 0;
            if (n == 1)
            {
                mass_tox = TOXIC_PERCENT * obj.mass_1;
            }
            else if (n == 2)
            {
                mass_tox = TOXIC_PERCENT * obj.mass_2;
            }
            else if (n == 3)
            {
                mass_tox = TOXIC_PERCENT * obj.mass_3;
            }
            else
            {
                mass_tox = TOXIC_PERCENT * obj.mass_4;
            }
            //Console.WriteLine("TOXIC_PERCENT= " + TOXIC_PERCENT);
            return mass_tox;
            
        }
        public TOXIC_511_512 getToxic(string type, string toxicName, int n)
        {
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            
            float ld = toxic_leak_duration(n);
            if (type == "Instantaneous")
            {
                RELEASE_DURATION = "Instantaneous Releases";
            }
            else {
                if (ld <= 300)
                {
                    RELEASE_DURATION = "5";
                }
                else if (ld > 300 && ld <= 600)
                {
                    RELEASE_DURATION = "10";
                }
                else if (ld > 600 && ld <= 900)
                {
                    RELEASE_DURATION = "15";
                }
                else if (ld > 900 && ld <= 1200)
                {
                    RELEASE_DURATION = "20";
                }
                else if (ld > 1200 && ld <= 1500)
                {
                    RELEASE_DURATION = "25";
                }
                else if (ld >1500 && ld <= 1800)
                {
                    RELEASE_DURATION = "30";
                }
                else if (ld > 1800 && ld <= 2100)
                {
                    RELEASE_DURATION = "35";
                }
                else if (ld > 2100 && ld <= 2400)
                {
                    RELEASE_DURATION = "40";
                }
                else if (ld > 2400 && ld <= 2700)
                {
                    RELEASE_DURATION = "45";
                }
                else if (ld > 2700 && ld <= 3000)
                {
                    RELEASE_DURATION = "50";
                }
                else if (ld > 3000 && ld <= 3300)
                {
                    RELEASE_DURATION = "55";
                }
                else if (ld > 3300 && ld <= 3600)
                {
                    RELEASE_DURATION = "60";
                }

            }
            //Console.writeline("release_duration= " + release_duration);
            //console.writeline("fluid_toxic= " + fluid_toxic);
            TOXIC_511_512 obj = DAL_CAL.GET_TBL_511_512(toxicName, RELEASE_DURATION);           
            return obj;
        }
        public TOXIC_513 getToxic513 (string ReleasePhase, string toxicName, int n)
        {
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            float ld = toxic_leak_duration(n);
            if (ReleasePhase == "Gas")
                TOXIC_PHASE = "Gas";
            else
                TOXIC_PHASE = "Liquid";
            if (ld <= 90)
            {
                RELEASE_DURATION = "1.5";
            }
            else if (ld > 90 && ld <= 180)
            {
                RELEASE_DURATION = "3";
            }
            else if (ld > 180 && ld <= 300)
            {
                RELEASE_DURATION = "5";
            }
            else if (ld > 300 && ld <= 600)
            {
                RELEASE_DURATION = "10";
            }
            else if (ld > 600 && ld <= 1200)
            {
                RELEASE_DURATION = "20";
            }
            else if (ld > 1200 && ld <= 1800)
            {
                RELEASE_DURATION = "30";
            }
            else if (ld > 1800 && ld <= 2400)
            {
                RELEASE_DURATION = "40";
            }
            else if (ld > 2400 && ld <= 3000)
            {
                RELEASE_DURATION = "50";
            }
            else if (ld > 3000 && ld <= 3600)
            {
                RELEASE_DURATION = "60";
            }
            TOXIC_513 obj = DAL_CAL.GET_TBL_513(toxicName, ReleasePhase, RELEASE_DURATION );
            return obj;
        }
        public float ca_injn_tox(string releasetype, string ToxicName, string releasephase, int n)
        {
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            RW_FULL_COF_HOLE_SIZE_BUS bushole = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE hole = bushole.getData(IDProposal);
            float C8 = 0.0929f;
            float C4 = 2.205f;
            TOXIC_511_512 obj = getToxic(releasetype, ToxicName, n);
            //Console.WriteLine("Toxic name_1= " + obj.ToxicName);
            TOXIC_513 obj1 = getToxic513(releasephase, ToxicName, n);
            //Console.WriteLine("Toxic name_2= " + obj1.Toxic);
            if (ToxicName == "HFAcid" || ToxicName == "H2S")
            {
                double log = 0;
                if (releasetype == "Continuous")
                    log = obj.c * Math.Log10(C4 * rate_tox_n(n)) + obj.d;
                else
                    log = obj.c * Math.Log10(C4 * mass_tox_n(n)) + obj.d;
                return (float)Math.Round(C8 * Math.Pow(10, log), 4);
            }
            else if (ToxicName == "Ammonia" || ToxicName == "Chlorine")
            {
                if (releasetype == "Continuous")
                    return (float)Math.Round(obj.e * Math.Pow(rate_tox_n(n), obj.f), 4);
                else
                    return (float)Math.Round(obj.e * Math.Pow(mass_tox_n(n), obj.f)*1000, 4);
            }
            else if (ToxicName == "AlCl3" || ToxicName == "CO" || ToxicName == "HCl" || ToxicName == "Nitric Acid" || ToxicName == "NO2"
                    || ToxicName == "Phosgene" || ToxicName == "TDI" || ToxicName == "EE" || ToxicName == "EO" || ToxicName == "PO")
            {
                if (releasetype == "Continuous")
                    return (float)Math.Round(obj1.e * Math.Pow(rate_tox_n(n), obj1.f), 4);
                else
                    return (float)Math.Round(obj1.e * Math.Pow(rate_tox_n(n), obj1.f), 4);
            }
            else
            {
                return 0;
            }
        }
        private Boolean checkToxic()
        {
            Boolean check = false;
            string[] itemsToxic = { "Nitric Acid", "AlCl3", "TDI", "EE" };
            if (FLUID == "H2S" && TOXIC_PERCENT > (100 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "HF" && TOXIC_PERCENT > (30 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "CO" && TOXIC_PERCENT > (1200 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "HCl" && TOXIC_PERCENT > (50 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "NO2" && TOXIC_PERCENT > (20 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "Phosgene" && TOXIC_PERCENT > (2 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "PO" && TOXIC_PERCENT > (400 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "EO" && TOXIC_PERCENT > (800 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "Ammonia" && TOXIC_PERCENT > (10 * Math.Pow(10, -4)))
                check = true;
            else if (FLUID == "Chlorine" && TOXIC_PERCENT > (10 * Math.Pow(10, -4)))
                check = true;
            else
            {
                for (int i = 0; i < itemsToxic.Length; i++)
                {
                    if (FLUID == itemsToxic[i])
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }
        
        public float ca_inj_tox(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            //Console.WriteLine("Toxic name= " + ToxicName);
            float ca_injn_tox1 = ca_injn_tox(releasetype1, ToxicName, releasephase, 1);
            float ca_injn_tox2 = ca_injn_tox(releasetype2, ToxicName, releasephase, 2);
            float ca_injn_tox3 = ca_injn_tox(releasetype3, ToxicName, releasephase, 3);
            float ca_injn_tox4 = ca_injn_tox(releasetype4, ToxicName, releasephase, 4);
            float t = obj.GFFSmall * ca_injn_tox1 + obj.GFFMedium * ca_injn_tox2 + obj.GFFLarge * ca_injn_tox3 + obj.GFFRupture * ca_injn_tox4;
            float ca_inj_tox = t / obj.GFFTotal;
            return Math.Abs(ca_inj_tox);

        }
        #region
        //public float ca_cmd()
        //{
        //    float cacmdflame = CA_CAL_FLA.ca_cmd_flame();
        //    Console.WriteLine("ca_cmd= " + cacmdflame);
        //    return cacmdflame;
        //}
        public float ca_inj(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        {
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE(FLUID, API_COMPONENT_TYPE_NAME, IDProposal, STORE_TEMP, FLUID_TOXIC, FLUID_PHASE);
            float cainjflame = CA_CAL_FLA.ca_inj_flame();
            //Console.WriteLine("ca_inj= " + cainjflame);
            float cainjtox = ca_inj_tox(releasetype1, releasetype2, releasetype3, releasetype4, ToxicName, releasephase);
            //Console.WriteLine("ca_inj_tox= " + cainjtox);
            float cainjnfnt = CA_CAL_FLA.ca_inj_nfnt();
            //Console.WriteLine("ca_inj_nfnt= " + cainjnfnt);
            return Math.Max(Math.Max(cainjflame, cainjtox), cainjnfnt);
        }
        public float ca_consequence(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        {
            MSSQL_CA_CAL_FLAMMABLE CA_CAL_FLA = new MSSQL_CA_CAL_FLAMMABLE(FLUID, API_COMPONENT_TYPE_NAME, IDProposal, STORE_TEMP, FLUID_TOXIC, FLUID_PHASE);
            float cacmd = CA_CAL_FLA.ca_cmd();
            float cainj = ca_inj(releasetype1, releasetype2, releasetype3, releasetype4, ToxicName, releasephase);
            //Console.WriteLine("max= " + Math.Max(cacmd, cainj));
            return Math.Max(cacmd, cainj);
        }
        #endregion
    }
}
