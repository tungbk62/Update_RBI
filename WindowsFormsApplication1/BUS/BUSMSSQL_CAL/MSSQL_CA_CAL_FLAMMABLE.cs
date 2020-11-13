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
    public class MSSQL_CA_CAL_FLAMMABLE
    {
        public String FLUID { set; get; }
        public String FLUID_TOXIC { get; set; }
        public int IDProposal { get; set; }
        public float MITIGATION_SYSTEM { get; set; }
        public float STORE_TEMP { get; set; }
        public String FLUID_PHASE { set; get; }
        public float TOXIC_PERCENT { get; set; }
        public string API_COMPONENT_TYPE_NAME { get; set; }

        API_COMPONENT_TYPE_BUS API_COMPONENT_BUS = new API_COMPONENT_TYPE_BUS();
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();
        MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
        //MSSQL_CA_CAL_TOXIC CA_CAL_TOX = new MSSQL_CA_CAL_TOXIC();

        public MSSQL_CA_CAL_FLAMMABLE(String f, String api, int id, float Ts,String ft, String ff)
        {
            FLUID = f;
            API_COMPONENT_TYPE_NAME=api;
            IDProposal = id;
            STORE_TEMP = Ts;
            FLUID_TOXIC = ft;
            FLUID_PHASE = ff;
        }
        public MSSQL_CA_CAL_FLAMMABLE()
        {

        }
        private String TYPE_FLUID()
        {
            String API_TYPE = null;
            if (FLUID == null || FLUID == "")
                API_TYPE = "TYPE 0";
            else
            {
                switch (FLUID)
                {
                    case "C1-C2":
                    case "C13-C16":
                    case "C17-C25":
                    case "C25+":
                    case "C3-C4":
                    case "C5":
                    case "C6-C8":
                    case "C9-C12":
                    case "Acid":
                    case "AlCl3":
                    case "H2":
                    case "H2S":
                    case "HCl":
                    case "HF":
                    case "Nitric Acid":
                    case "NO2":
                    case "Phosgene":
                    case "Pyrophoric":
                    case "Steam":
                    case "TDI":
                    case "Water":
                        API_TYPE = "TYPE 0";
                        break;
                    case "CO":
                    case "DEE":
                    case "EE":
                    case "EEA":
                    case "EG":
                    case "EO":
                    case "Methanol":
                    case "PO":
                    case "Styrene":
                        API_TYPE = "TYPE 1";
                        break;
                    default:
                        API_TYPE = "TYPE 0";
                        break;
                }
            }
            return API_TYPE;
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
            if(FLUID_PHASE=="Gas")
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
        public float fact_mit()
        {
            RW_FULL_COF_INPUT_BUS bus = new RW_FULL_COF_INPUT_BUS();
            RW_FULL_COF_INPUT obj = bus.getData(IDProposal);
            float fact_mit = 0;
            if (obj.Mitigation == "Inventory Blowdown, coupled with isolation system actived remotely or automatically")
                fact_mit = 0.25f;
            else if (obj.Mitigation == "Fire water deluge system and monitors")
                fact_mit = 0.2f;
            else if (obj.Mitigation == "Fire water monitor only")
                fact_mit = 0.05f;
            else
                fact_mit = 0.15f;
            return fact_mit;
        }
        public float eneff_n(int n)
        {
            float eff = (float)(4 * Math.Log10(DAL_CAL.GET_TBL_3B21(4) * CA_CAL.mass_n(n)) - 15);
            if (eff < 1 )
                return 1;
            else
                return eff;
        }
        public float a_cmd(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID);
            float[] a_cmd = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                a_cmd[0] = data[0];
                a_cmd[1] = data[4];
                a_cmd[2] = data[8];
                a_cmd[3] = data[12];
            }
            else
            {
                a_cmd[0] = data[2];
                a_cmd[1] = data[6];
                a_cmd[2] = data[10];
                a_cmd[3] = data[14];
            }
            if (a_cmd[select - 1] == 1)
                return 0;
            else                   
                return a_cmd[select - 1];
        }
        public float b_cmd(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID);
            float[] b_cmd = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                b_cmd[0] = data[1];
                b_cmd[1] = data[5];
                b_cmd[2] = data[9];
                b_cmd[3] = data[13];
            }
            else
            {
                b_cmd[0] = data[3];
                b_cmd[1] = data[7];
                b_cmd[2] = data[11];
                b_cmd[3] = data[15];
            }
            if (b_cmd[select - 1] == 1)
                return 0;
            else
                return b_cmd[select - 1];
        }
        public float a_inj(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID);
            float[] a_inj = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                a_inj[0] = data[0];
                a_inj[1] = data[4];
                a_inj[2] = data[8];
                a_inj[3] = data[12];
            }
            else
            {
                a_inj[0] = data[2];
                a_inj[1] = data[6];
                a_inj[2] = data[10];
                a_inj[3] = data[14];
            }
            return a_inj[select - 1];
        }
        public float b_inj(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID);
            float[] b_inj = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                b_inj[0] = data[1];
                b_inj[1] = data[5];
                b_inj[2] = data[9];
                b_inj[3] = data[13];
            }
            else
            {
                b_inj[0] = data[3];
                b_inj[1] = data[7];
                b_inj[2] = data[11];
                b_inj[3] = data[15];
            }
            return b_inj[select - 1];
        }
        public float a_cmd_toxic(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID_TOXIC);
            float[] a_cmd_toxic = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                a_cmd_toxic[0] = data[0];
                a_cmd_toxic[1] = data[4];
                a_cmd_toxic[2] = data[8];
                a_cmd_toxic[3] = data[12];
            }
            else
            {
                a_cmd_toxic[0] = data[2];
                a_cmd_toxic[1] = data[6];
                a_cmd_toxic[2] = data[10];
                a_cmd_toxic[3] = data[14];
            }
            if (a_cmd_toxic[select - 1] == 1)
                return 0;
            else
                return a_cmd_toxic[select - 1];
        }
        public float b_cmd_toxic(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID_TOXIC);
            float[] b_cmd_toxic = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                b_cmd_toxic[0] = data[1];
                b_cmd_toxic[1] = data[5];
                b_cmd_toxic[2] = data[9];
                b_cmd_toxic[3] = data[13];
            }
            else
            {
                b_cmd_toxic[0] = data[3];
                b_cmd_toxic[1] = data[7];
                b_cmd_toxic[2] = data[11];
                b_cmd_toxic[3] = data[15];
            }
            if (b_cmd_toxic[select - 1] == 1)
                return 0;
            else
                return b_cmd_toxic[select - 1];
        }
        public float a_inj_toxic(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID_TOXIC);
            float[] a_inj_toxic = { 0, 0, 0, 0 };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                a_inj_toxic[0] = data[0];
                a_inj_toxic[1] = data[4];
                a_inj_toxic[2] = data[8];
                a_inj_toxic[3] = data[12];
            }
            else
            {
                a_inj_toxic[0] = data[2];
                a_inj_toxic[1] = data[6];
                a_inj_toxic[2] = data[10];
                a_inj_toxic[3] = data[14];
            }
            return a_inj_toxic[select - 1];
        }
        public float b_inj_toxic(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID_TOXIC);
            float[] b_inj_toxic = { 0, 0, 0, 0 };//{ data[1], data[3], data[5], data[7], data[9], data[11], data[13], data[15] };
            if (GET_RELEASE_PHASE() == "Gas")
            {
                b_inj_toxic[0] = data[1];
                b_inj_toxic[1] = data[5];
                b_inj_toxic[2] = data[9];
                b_inj_toxic[3] = data[13];
            }
            else
            {
                b_inj_toxic[0] = data[3];
                b_inj_toxic[1] = data[7];
                b_inj_toxic[2] = data[11];
                b_inj_toxic[3] = data[15];
            }
            return b_inj_toxic[select - 1];
        }
        public float ca_cmdn_cont(int select, int n) // model
        {
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            float ca_cmdn_cont = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            float x = 0;
            if (n == 1){
                x = obj.rate_1;
            }
            else if (n== 2){
                x = obj.rate_2;

            }
            else if (n == 3)
            {
                x = obj.rate_3;
            }
            else
            {
                x = obj.rate_4;
            }
            ca_cmdn_cont = (float)Math.Round(a_cmd(select) * Math.Pow( x, b_cmd(select)) * (1 - fact_mit()), 5);
            return ca_cmdn_cont;
        }
        private float effrate_n(int select, int n)
        {
            float effrate_n = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            if ((CA_CAL.GET_RELEASE_PHASE() == "Liquid") && (API_FLUID_TYPE == "TYPE 0"))
                effrate_n = (float)Math.Round((1 / (DAL_CAL.GET_TBL_3B21(4)) * Math.Exp(Math.Log10(ca_cmdn_cont(select, n) / (a_cmd(select) * (DAL_CAL.GET_TBL_3B21(8)))) * Math.Pow(b_cmd(select), -1))), 2);
            else
                effrate_n = CA_CAL.rate_n(n);
            return effrate_n;
        }
        public float ca_cmdn_inst(int select, int n)
        {
            float ca_cmdn_inst = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_inst = (float)Math.Round(a_cmd(select) * Math.Pow((obj.mass_1), b_cmd(select)) * ((1 - fact_mit()) / obj.eneff_1), 5);
            }
            else if (n == 2)
            {
                ca_cmdn_inst = (float)Math.Round(a_cmd(select) * Math.Pow((obj.mass_2), b_cmd(select)) * ((1 - fact_mit()) / obj.eneff_2), 5);
            }
            else if (n == 3)
            {
                ca_cmdn_inst = (float)Math.Round(a_cmd(select) * Math.Pow((obj.mass_3), b_cmd(select)) * ((1 - fact_mit()) / obj.eneff_3), 5);
            }
            else if (n == 4)
            {
                ca_cmdn_inst = (float)Math.Round(a_cmd(select) * Math.Pow((obj.mass_4), b_cmd(select)) * ((1 - fact_mit()) / obj.eneff_4), 5);
            }
           
            return ca_cmdn_inst;
        }
        public float ca_injn_cont(int select, int n)
        {
            float ca_injn_cont;
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            String API_FLUID_TYPE = TYPE_FLUID();
            float x = 0;
            if (n == 1)
            {
                x = obj.rate_1;
            }
            else if (n == 2)
            {
                x = obj.rate_2;

            }
            else if (n == 3)
            {
                x = obj.rate_3;
            }
            else
            {
                x = obj.rate_4;
            }
            ca_injn_cont = (float)Math.Round(a_inj(select) * Math.Pow(x, b_inj(select)) * (1 - fact_mit()), 5);
            return ca_injn_cont;
        }
        public float ca_injn_inst(int select, int n)
        {
            float ca_injn_inst=0;
            String API_FLUID_TYPE = TYPE_FLUID();
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_injn_inst = (float)Math.Round(a_inj(select) * Math.Pow((obj.mass_1), b_inj(select)) * ((1 - fact_mit()) / obj.eneff_1), 5);
            }
            else if (n == 2)
            {
                ca_injn_inst = (float)Math.Round(a_inj(select) * Math.Pow((obj.mass_2), b_inj(select)) * ((1 - fact_mit()) / obj.eneff_2), 5);
            }
            else if (n == 3)
            {
                ca_injn_inst = (float)Math.Round(a_inj(select) * Math.Pow((obj.mass_3), b_inj(select)) * ((1 - fact_mit()) / obj.eneff_3), 5);
            }
            else if (n == 4)
            {
                ca_injn_inst = (float)Math.Round(a_inj(select) * Math.Pow((obj.mass_4), b_inj(select)) * ((1 - fact_mit()) / obj.eneff_4), 5);
            }
          
            return ca_injn_inst;
        }
        public float ca_cmdn_cont_toxic(int select, int n) //Toxic
        {
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            float ca_cmdn_cont_toxic = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            float x = 0;
            if (n == 1)
            {
                x = obj.rate_1*TOXIC_PERCENT;
            }
            else if (n == 2)
            {
                x = obj.rate_2*TOXIC_PERCENT;

            }
            else if (n == 3)
            {
                x = obj.rate_3*TOXIC_PERCENT;
            }
            else
            {
                x = obj.rate_4*TOXIC_PERCENT;
            }
            ca_cmdn_cont_toxic = (float)Math.Round(a_cmd_toxic(select) * Math.Pow(x, b_cmd_toxic(select)) * (1 - fact_mit()), 5);
            return ca_cmdn_cont_toxic;
        }
        private float effrate_n_toxic(int select, int n)
        {
            float effrate_n_toxic = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            if ((CA_CAL.GET_RELEASE_PHASE() == "Liquid") && (API_FLUID_TYPE == "TYPE 0"))
                effrate_n_toxic = (float)Math.Round((1 / (DAL_CAL.GET_TBL_3B21(4)) * Math.Exp(Math.Log10(ca_cmdn_cont_toxic(select, n) / (a_cmd_toxic(select) * (DAL_CAL.GET_TBL_3B21(8)))) * Math.Pow(b_cmd_toxic(select), -1))), 2);
            else
                effrate_n_toxic = CA_CAL.rate_n(n)*TOXIC_PERCENT;
            return effrate_n_toxic;
        }
        public float ca_cmdn_inst_toxic(int select, int n)
        {
            float ca_cmdn_inst_toxic = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_inst_toxic = (float)Math.Round(a_cmd_toxic(select) * Math.Pow((obj.mass_1*TOXIC_PERCENT), b_cmd_toxic(select)) * ((1 - fact_mit()) / obj.eneff_1), 5);
            }
            else if (n == 2)
            {
                ca_cmdn_inst_toxic = (float)Math.Round(a_cmd_toxic(select) * Math.Pow((obj.mass_2*TOXIC_PERCENT), b_cmd_toxic(select)) * ((1 - fact_mit()) / obj.eneff_2), 5);
            }
            else if (n == 3)
            {
                ca_cmdn_inst_toxic = (float)Math.Round(a_cmd_toxic(select) * Math.Pow((obj.mass_3*TOXIC_PERCENT), b_cmd_toxic(select)) * ((1 - fact_mit()) / obj.eneff_3), 5);
            }
            else if (n == 4)
            {
                ca_cmdn_inst_toxic = (float)Math.Round(a_cmd_toxic(select) * Math.Pow((obj.mass_4*TOXIC_PERCENT), b_cmd_toxic(select)) * ((1 - fact_mit()) / obj.eneff_4), 5);
            }

            return ca_cmdn_inst_toxic;
        }
        public float ca_injn_cont_toxic(int select, int n)
        {
            float ca_injn_cont_toxic;
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            String API_FLUID_TYPE = TYPE_FLUID();
            float x = 0;
            if (n == 1)
            {
                x = obj.rate_1*TOXIC_PERCENT;
            }
            else if (n == 2)
            {
                x = obj.rate_2*TOXIC_PERCENT;

            }
            else if (n == 3)
            {
                x = obj.rate_3*TOXIC_PERCENT;
            }
            else
            {
                x = obj.rate_4*TOXIC_PERCENT;
            }
            ca_injn_cont_toxic = (float)Math.Round(a_inj_toxic(select) * Math.Pow(x, b_inj_toxic(select)) * (1 - fact_mit()), 5);
            return ca_injn_cont_toxic;
        }
        public float ca_injn_inst_toxic(int select, int n)
        {
            float ca_injn_inst_toxic = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_injn_inst_toxic = (float)Math.Round(a_inj_toxic(select) * Math.Pow((obj.mass_1*TOXIC_PERCENT), b_inj_toxic(select)) * ((1 - fact_mit()) / obj.eneff_1), 5);
            }
            else if (n == 2)
            {
                ca_injn_inst_toxic = (float)Math.Round(a_inj_toxic(select) * Math.Pow((obj.mass_2*TOXIC_PERCENT), b_inj_toxic(select)) * ((1 - fact_mit()) / obj.eneff_2), 5);
            }
            else if (n == 3)
            {
                ca_injn_inst_toxic = (float)Math.Round(a_inj_toxic(select) * Math.Pow((obj.mass_3*TOXIC_PERCENT), b_inj_toxic(select)) * ((1 - fact_mit()) / obj.eneff_3), 5);
            }
            else if (n == 4)
            {
                ca_injn_inst_toxic = (float)Math.Round(a_inj_toxic(select) * Math.Pow((obj.mass_4*TOXIC_PERCENT), b_inj_toxic(select)) * ((1 - fact_mit()) / obj.eneff_4), 5);
            }

            return ca_injn_inst_toxic;
        }
        public double fact_n_ic(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (obj.ReleaseType_1 == "Continuous" && n == 1)
                return obj.factIC_1;
            else if (obj.ReleaseType_2 == "Continuous" && n == 2)
            {
                return obj.factIC_2;
            }
            else if (obj.ReleaseType_3 == "Continuous" && n == 3)
            {
                return obj.factIC_3;
            }
            else if (obj.ReleaseType_4 == "Continuous" && n == 4)
            {
                return obj.factIC_4;
            }
            else
                return 1.0;
        }
        public float fact_ait()
        {
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            float fact_ait = 0;
            float ait = (float)Math.Round((data[9] - 32) / 1.8, 2);
            if ((STORE_TEMP + (DAL_CAL.GET_TBL_3B21(7))) <= ait)
                fact_ait = 0;
            else if ((STORE_TEMP - (DAL_CAL.GET_TBL_3B21(7))) >= ait)
                fact_ait = 1;
            else
                fact_ait = (STORE_TEMP - ait + (DAL_CAL.GET_TBL_3B21(7))) / (2 * (DAL_CAL.GET_TBL_3B21(7)));
            //Console.WriteLine("fact_ait= " + fact_ait);
            return fact_ait;
        }
        public float fact_ait_toxic()
        {
            RW_STREAM_BUS busst = new RW_STREAM_BUS();
            RW_STREAM st = busst.getData(IDProposal);
            float[] data = DAL_CAL.GET_TBL_52(FLUID_TOXIC);
            float fact_ait_toxic = 0;
            float ait =(float)Math.Round((data[9] - 32) / 1.8, 2);
            //Console.WriteLine("ait= " + ait);
            if ((CA_CAL.STORED_TEMP + (DAL_CAL.GET_TBL_3B21(7))) <= ait)
                fact_ait_toxic = 0;
            else if ((CA_CAL.STORED_TEMP - (DAL_CAL.GET_TBL_3B21(7))) >= ait)
                fact_ait_toxic = 1;
            else
                fact_ait_toxic = (STORE_TEMP - ait + (DAL_CAL.GET_TBL_3B21(7))) / (2 * (DAL_CAL.GET_TBL_3B21(7)));
            //Console.WriteLine("fact_ait_toxic= " + fact_ait_toxic);
            return fact_ait_toxic;
        }
        public float ca_cmdn_ainl(int n)
        {
            float ca_cmdn_ainl = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_ainl = (float)(ca_cmdn_inst(3, 1) * obj.factIC_1 + ca_cmdn_cont(1, 1) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_cmdn_ainl = (float)(ca_cmdn_inst(3, 2) * obj.factIC_2 + ca_cmdn_cont(1, 2) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_cmdn_ainl = (float)(ca_cmdn_inst(3, 3) * obj.factIC_3 + ca_cmdn_cont(1, 3) * (1 - obj.factIC_3));
            }
            else
            {
                ca_cmdn_ainl = (float)(ca_cmdn_inst(3, 4) * obj.factIC_4 + ca_cmdn_cont(1, 4) * (1 - obj.factIC_4));
            }

            return ca_cmdn_ainl;
        }
        public float ca_cmdn_ail(int n)
        {
            float ca_cmdn_ail = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_ail = (float)(ca_cmdn_inst(4, 1) * obj.factIC_1 + ca_cmdn_cont(2, 1) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_cmdn_ail = (float)(ca_cmdn_inst(4, 2) * obj.factIC_2 + ca_cmdn_cont(2, 2) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_cmdn_ail = (float)(ca_cmdn_inst(4, 3) * obj.factIC_3 + ca_cmdn_cont(2, 3) * (1 - obj.factIC_3));
            }
            else
            {
                ca_cmdn_ail = (float)(ca_cmdn_inst(4, 4) * obj.factIC_4 + ca_cmdn_cont(2, 4) * (1 - obj.factIC_4));
            }

            return ca_cmdn_ail;
        }
        public float ca_injn_ainl(int n)
        {
            float ca_injn_ainl = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_injn_ainl = (float)(Math.Abs(ca_injn_inst(3, 1)) * obj.factIC_1 + Math.Abs(ca_injn_cont(1, 1)) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_injn_ainl = (float)(Math.Abs(ca_injn_inst(3, 2)) * obj.factIC_2 + Math.Abs(ca_injn_cont(1, 2)) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_injn_ainl = (float)(Math.Abs(ca_injn_inst(3, 3)) * obj.factIC_3 + Math.Abs(ca_injn_cont(1, 3)) * (1 - obj.factIC_3));
            }
            else
            {
                ca_injn_ainl = (float)(Math.Abs(ca_injn_inst(3, 4)) * obj.factIC_4 + Math.Abs(ca_injn_cont(1, 4)) * (1 - obj.factIC_4));
            }

            return ca_injn_ainl;
        }
        public float ca_inji_ail(int n)
        {
            float ca_inji_ail = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_inji_ail = (float)(Math.Abs(ca_injn_inst(4, 1)) * obj.factIC_1 + Math.Abs(ca_injn_cont(2, 1)) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_inji_ail = (float)(Math.Abs(ca_injn_inst(4, 2)) * obj.factIC_2 + Math.Abs(ca_injn_cont(2, 2)) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_inji_ail = (float)(Math.Abs(ca_injn_inst(4, 3)) * obj.factIC_3 + Math.Abs(ca_injn_cont(2, 3)) * (1 - obj.factIC_3));
            }
            else
            {
                ca_inji_ail = (float)(Math.Abs(ca_injn_inst(4, 4)) * obj.factIC_4 + Math.Abs(ca_injn_cont(2, 4)) * (1 - obj.factIC_4));
            }


            return ca_inji_ail;
        }
        public float ca_cmdn_ainl_toxic(int n)
        {
            float ca_cmdn_ainl_toxic = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_ainl_toxic = (float)(ca_cmdn_inst_toxic(3, 1) * obj.factIC_1 + ca_cmdn_cont_toxic(1, 1) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_cmdn_ainl_toxic = (float)(ca_cmdn_inst_toxic(3, 2) * obj.factIC_2 + ca_cmdn_cont_toxic(1, 2) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_cmdn_ainl_toxic = (float)(ca_cmdn_inst_toxic(3, 3) * obj.factIC_3 + ca_cmdn_cont_toxic(1, 3) * (1 - obj.factIC_3));
            }
            else
            {
                ca_cmdn_ainl_toxic = (float)(ca_cmdn_inst_toxic(3, 4) * obj.factIC_4 + ca_cmdn_cont_toxic(1, 4) * (1 - obj.factIC_4));
            }

            return ca_cmdn_ainl_toxic;
        }
        public float ca_cmdn_ail_toxic(int n)
        {
            float ca_cmdn_ail_toxic = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_cmdn_ail_toxic = (float)(ca_cmdn_inst_toxic(4, 1) * obj.factIC_1 + ca_cmdn_cont_toxic(2, 1) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_cmdn_ail_toxic = (float)(ca_cmdn_inst_toxic(4, 2) * obj.factIC_2 + ca_cmdn_cont_toxic(2, 2) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_cmdn_ail_toxic = (float)(ca_cmdn_inst_toxic(4, 3) * obj.factIC_3 + ca_cmdn_cont_toxic(2, 3) * (1 - obj.factIC_3));
            }
            else
            {
                ca_cmdn_ail_toxic = (float)(ca_cmdn_inst_toxic(4, 4) * obj.factIC_4 + ca_cmdn_cont_toxic(2, 4) * (1 - obj.factIC_4));
            }

            return ca_cmdn_ail_toxic;
        }
        public float ca_injn_ainl_toxic(int n)
        {
            float ca_injn_ainl_toxic = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_injn_ainl_toxic = (float)(Math.Abs(ca_injn_inst_toxic(3, 1)) * obj.factIC_1 + Math.Abs(ca_injn_cont_toxic(1, 1)) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_injn_ainl_toxic = (float)(Math.Abs(ca_injn_inst_toxic(3, 2)) * obj.factIC_2 + Math.Abs(ca_injn_cont_toxic(1, 2)) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_injn_ainl_toxic = (float)(Math.Abs(ca_injn_inst_toxic(3, 3)) * obj.factIC_3 + Math.Abs(ca_injn_cont_toxic(1, 3)) * (1 - obj.factIC_3));
            }
            else
            {
                ca_injn_ainl_toxic = (float)(Math.Abs(ca_injn_inst_toxic(3, 4)) * obj.factIC_4 + Math.Abs(ca_injn_cont_toxic(1, 4)) * (1 - obj.factIC_4));
            }

            return ca_injn_ainl_toxic;
        }
        public float ca_inji_ail_toxic(int n)
        {
            float ca_inji_ail_toxic = 0;
            RW_FULL_COF_HOLE_SIZE_BUS bushs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = bushs.getData(IDProposal);
            if (n == 1)
            {
                ca_inji_ail_toxic = (float)(Math.Abs(ca_injn_inst_toxic(4, 1)) * obj.factIC_1 + Math.Abs(ca_injn_cont_toxic(2, 1)) * (1 - obj.factIC_1));
            }
            else if (n == 2)
            {
                ca_inji_ail_toxic = (float)(Math.Abs(ca_injn_inst_toxic(4, 2)) * obj.factIC_2 + Math.Abs(ca_injn_cont_toxic(2, 2)) * (1 - obj.factIC_2));
            }
            else if (n == 3)
            {
                ca_inji_ail_toxic = (float)(Math.Abs(ca_injn_inst_toxic(4, 3)) * obj.factIC_3 + Math.Abs(ca_injn_cont_toxic(2, 3)) * (1 - obj.factIC_3));
            }
            else
            {
                ca_inji_ail_toxic = (float)(Math.Abs(ca_injn_inst_toxic(4, 4)) * obj.factIC_4 + Math.Abs(ca_injn_cont_toxic(2, 4)) * (1 - obj.factIC_4));
            }


            return ca_inji_ail_toxic;
        }
        public float ca_cmdn_ait(int n)
        {
            float ca_cmdn_ait = 0;
            ca_cmdn_ait = (float)ca_cmdn_ail(n) * fact_ait() + (float)ca_cmdn_ainl(n) * (1 - fact_ait());
            return ca_cmdn_ait;
        }
        public float ca_injn_ait(int n)
        {
            return (float)ca_inji_ail(n) * fact_ait() + (float)ca_injn_ainl(n) * (1 - fact_ait());

        }
        public float ca_cmdn_ait_toxic(int n)
        {
            return (float)ca_cmdn_ail_toxic(n) * fact_ait_toxic() + (float)ca_cmdn_ainl_toxic(n) * (1 - fact_ait_toxic());
        }
        public float ca_injn_ait_toxic(int n)
        {
            return (float)ca_inji_ail_toxic(n) * fact_ait_toxic() + (float)ca_injn_ainl_toxic(n) * (1 - fact_ait_toxic());

        }
        private Boolean checkFlame()
        {
            Boolean check = false;
            string[] itemsFrammable = { "C1-C2", "C3-C4", "C5", "C6-C8", "C9-C12", "C13-C16", "C17-C25", "C25+", "H2", "H2S", "HF", "CO", "DEE", "Methanol", "PO", "Styrene", "Aromatics", "EEA", "EE", "EG", "EO" };
            for (int i = 0; i < itemsFrammable.Length; i++)
            {
                if (FLUID == itemsFrammable[i])
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private Boolean checkToxic()
        {
            Boolean checkToxic = false;
            string[] itemsToxic = { "H2S", "HFAcid", "CO", "HCL", "Nitric Acid", "ALCL3", "NO2", "Phosgene", "TDI", "PO", "EE", "EO", "Pyrophoric", "Ammonia", "Chlorine"};
            for (int i = 0; i < itemsToxic.Length; i++)
            {
                if (FLUID_TOXIC == itemsToxic[i])
                {
                    checkToxic = true;
                    break;
                }
            }
            return checkToxic;
        }
        public float ca_cmd_flame()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            if (!checkFlame())
            {
                //Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                return 0;
            }
            else
            {
                float t = 0;               
                t = obj.GFFSmall * ca_cmdn_ait(1) + obj.GFFMedium * ca_cmdn_ait(2) + obj.GFFLarge * ca_cmdn_ait(3) + obj.GFFRupture * ca_cmdn_ait(4);
                float ca_cmd_flame = t / obj.GFFTotal;
                return Math.Abs(ca_cmd_flame);
            }

        }
        //public String ca_cmd_flame_cat()
        //{
        //    String cat = "";

        //}
        public float ca_inj_flame()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            if (!checkFlame())
            {
                return 0;
            }
            else
            {
                float t;
                t = obj.GFFSmall * ca_injn_ait(1) + obj.GFFMedium * ca_injn_ait(2) + obj.GFFLarge * ca_injn_ait(3) + obj.GFFRupture * ca_injn_ait(4);
                float ca_inj = t / obj.GFFTotal;
                return Math.Abs(ca_inj);
            }
        }
        public float ca_cmd_flame_toxic()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            if (!checkToxic())
            {
                return 0;
            }
            else
            {
                float t = 0;
                t = obj.GFFSmall * ca_cmdn_ait_toxic(1) + obj.GFFMedium * ca_cmdn_ait_toxic(2) + obj.GFFLarge * ca_cmdn_ait_toxic(3) + obj.GFFRupture * ca_cmdn_ait_toxic(4);
                float ca_cmd_flame_toxic = t / obj.GFFTotal;
                return Math.Abs(ca_cmd_flame_toxic);
            }

        }
        public float ca_inj_flame_toxic()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            if (!checkToxic())
            {
                return 0;
            }
            else
            {
                float t;
                t = obj.GFFSmall * ca_injn_ait_toxic(1) + obj.GFFMedium * ca_injn_ait_toxic(2) + obj.GFFLarge * ca_injn_ait_toxic(3) + obj.GFFRupture * ca_injn_ait_toxic(4);
                float ca_inj_flame_toxic = t / obj.GFFTotal;
                return Math.Abs(ca_inj_flame_toxic);
            }
        }
        #region non flamable non toxic
        public float STORED_PRESSURE { set; get; }
        public float ATMOSPHERIC_PRESSURE = 101.325f;
        public float ca_injn_contnfnt(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            float x = 0;
            if (n == 1)
            {
                x = obj.rate_1;
            }
            else if (n == 2)
            {
                x = obj.rate_2;

            }
            else if (n == 3)
            {
                x = obj.rate_3;
            }
            else
            {
                x = obj.rate_4;
            }
            float ca_injn_cont = 0;
            float num3 = 0;
            if (STORED_PRESSURE < 163)
            {
                num3 = 163;
            }
            else
            {
                if (STORED_PRESSURE > 590)
                {
                    num3 = 590;
                }
                else
                {
                    num3 = STORED_PRESSURE;
                }
            }
            double g = (2696.0 - (3.1754999999999995 * (num3 - 101.325))) + (1.474 * Math.Pow(0.145 * (num3 - 101.325), 2.0));
            double h = 0.31 - (0.00032 * Math.Pow((0.145 * (num3 - 101.325)) - 40.0, 2.0));
            if (FLUID == "Steam")
                ca_injn_cont = (float)Math.Round((DAL_CAL.GET_TBL_3B21(9)) * x, 4);
            else if (FLUID == "Water")
                ca_injn_cont = 0;
            else
                ca_injn_cont = (float)Math.Round(0.2 * (0.0929) * g * Math.Pow((2.205) * x, h), 2);
            return ca_injn_cont;
        }
        public float ca_injn_instnfnt(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            float mass_n = 0;
            if (n == 1)
            {
                mass_n = obj.mass_1;
            }
            else if (n == 2)
            {
                mass_n = obj.mass_2;

            }
            else if (n == 3)
            {
                mass_n = obj.mass_3;
            }
            else
            {
                mass_n = obj.mass_4;
            }
            float ca_injn_inst = 0;
            if (FLUID == "Steam")
                ca_injn_inst = (float)Math.Round((DAL_CAL.GET_TBL_3B21(10)) * Math.Pow(mass_n, 0.6384), 4);
            else
                ca_injn_inst = 0;
            return ca_injn_inst;
        }
        public float fact_n_icnfnt(int n)
        {
            RW_FULL_COF_HOLE_SIZE_BUS busfchs = new RW_FULL_COF_HOLE_SIZE_BUS();
            RW_FULL_COF_HOLE_SIZE obj = busfchs.getData(IDProposal);
            float x = 0;
            if (n == 1)
            {
                x = obj.rate_1;
            }
            else if (n == 2)
            {
                x = obj.rate_2;

            }
            else if (n == 3)
            {
                x = obj.rate_3;
            }
            else
            {
                x = obj.rate_4;
            }
            float fact_n_icnfnt = 0;
            if (FLUID == "Steam")
                fact_n_icnfnt = Math.Min(x / (25.2f), 1);
            else
                fact_n_icnfnt = 0;
            return fact_n_icnfnt;
        }
        public float ca_injn_leaknfnt(int n)
        {
            return ca_injn_instnfnt(n) * fact_n_icnfnt(n) + ca_injn_contnfnt(n) * (1 - fact_n_icnfnt(n));
        }
        private Boolean checkNone()
        {
            Boolean check = false;
            string[] itemsNoneTF = { "Steam", "Acid", "Caustic" };
            for (int i = 0; i < itemsNoneTF.Length; i++)
            {
                if (FLUID == itemsNoneTF[i])
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public float ca_inj_nfnt()
        {
            if (!checkNone())
            {
                return 0;
            }
            else
            {
                float t = 0;
                API_COMPONENT_TYPE obj = GET_DATA_API_COM();
                t = obj.GFFSmall * ca_injn_leaknfnt(1) + obj.GFFMedium * ca_injn_leaknfnt(2) + obj.GFFLarge * ca_injn_leaknfnt(3) + obj.GFFRupture * ca_injn_leaknfnt(4);
                float ca_inj_nfnt = t / obj.GFFTotal;
                return Math.Abs(ca_inj_nfnt);
            }
        }

        #endregion
        //#region CA
        public float ca_cmd()
        {
            float cacmdflame = ca_cmd_flame();
            return cacmdflame;
        }
        //public float ca_inj(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        //{
        //    float cainjflame = ca_inj_flame();
        //    Console.WriteLine("ca_inj= " + cainjflame);
        //    float cainjtox = CA_CAL_TOX.ca_inj_tox(releasetype1, releasetype2, releasetype3, releasetype4, ToxicName, releasephase);
        //    Console.WriteLine("ca_inj_tox= " + cainjtox);
        //    float cainjnfnt = ca_inj_nfnt();
        //    Console.WriteLine("ca_inj_nfnt= " + cainjnfnt);
        //    Console.WriteLine("ca= " + Math.Max(Math.Max(cainjflame, cainjtox), cainjnfnt));
        //    return Math.Max(Math.Max(cainjflame, cainjtox), cainjnfnt);
        //}
        //public float ca_consequence(string releasetype1, string releasetype2, string releasetype3, string releasetype4, string ToxicName, string releasephase)
        //{
        //    float cacmd = ca_cmd();
        //    float cainj = ca_inj(releasetype1, releasetype2, releasetype3, releasetype4, ToxicName, releasephase);
        //    Console.WriteLine("max= " + Math.Max(cacmd, cainj));
        //    return Math.Max(cacmd, cainj);
        //}
        //#endregion
    }
}
