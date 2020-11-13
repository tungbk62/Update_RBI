using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
using RBI.Object;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.DAL.MSSQL_CAL;
using DevExpress.XtraSplashScreen;

namespace RBI.PRE.subForm.OutputDataForm.OutputPOF
{
    public partial class UCSulphideStressCracking : UserControl
    {
        public UCSulphideStressCracking()
        {
            InitializeComponent();
        }
        public UCSulphideStressCracking(int ID)
        {
            InitializeComponent();
            initinput(ID);
            Calculate();
        }
        private void initinput(int ID)
        {
            RW_COATING_BUS coatBus = new RW_COATING_BUS();
            RW_EQUIPMENT_BUS eqBus = new RW_EQUIPMENT_BUS();
            EQUIPMENT_MASTER_BUS busEquipmentMaster = new EQUIPMENT_MASTER_BUS();
            RW_COATING coat = new RW_COATING();
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            RW_ASSESSMENT ass = busAssessment.getData(ID);
            RW_INSPECTION_HISTORY_BUS busInspectionHistory = new RW_INSPECTION_HISTORY_BUS();
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_STREAM stream = SteamBus.getData(ID);
            //TimeSpan year = busAssessment.getAssessmentDate(IDProposal) - busInspectionHistory.getLastInsp(componentID, DM_ID[1], busEquipmentMaster.getComissionDate(equipmentID));
            int equipmentID = busAssessment.getEquipmentID(ID);

            txtAssDate.Text = Convert.ToString(busAssessment.getAssessmentDate(ID));
            txtLastInspecDate.Text = Convert.ToString(busEquipmentMaster.getComissionDate(equipmentID)); //test theo riskwwise
            txtComDate.Text = Convert.ToString(busEquipmentMaster.getComissionDate(equipmentID));
            txtH2SinWater.Text = stream.CO3Concentration.ToString();
            txtH2S.Text = stream.CO3Concentration.ToString();
            txtPHofWater.Text = stream.WaterpH.ToString();
            txtPeriod.Text = Convert.ToString(ass.RiskAnalysisPeriod);
            txtNumInspec.Text = "0"; //test
            txtInspecEffective.Text = "E";
            txtCrack.Text = Convert.ToString(true);
            txtPHWT.Text = Convert.ToString(true);
            txtCrack.Text = Convert.ToString(true);
            txtHardnessWeld.Text = Convert.ToString(true);
        }
        public void Calculate()
        {
            MessageBox.Show("đang gọi đến điểm test");

            //cal.YEAR_IN_SERVICE = (int)Math.Ceiling((decimal)year.Days / 365); 
            //cal.LINNER_CONDITION = 
            //cal.INTERNAL_LINNING =


            //Input
            CAL_DM_SCC_CRACKING CA_DM = new CAL_DM_SCC_CRACKING();
            CA_DM.SULPHIDE_INSP_NUM = txtNumInspec.Text != "" ? int.Parse(txtNumInspec.Text) : 0;
            CA_DM.SULPHIDE_INSP_EFF = txtInspecEffective.Text;
            CA_DM.H2SContent = txtH2SinWater.Text != "" ? int.Parse(txtH2SinWater.Text) : 0;
            CA_DM.PH = txtH2S.Text != "" ? float.Parse(txtH2S.Text) : 0;
            string temp = txtCrack.Text.ToLower();
            if (txtCrack.Text.ToLower() == "true")
            {
                CA_DM.CRACK_PRESENT = true;
            }
            else
            {
                CA_DM.CRACK_PRESENT = false;
            }
            if (txtPHWT.Text.ToLower() == "true")
            {
                CA_DM.PWHT = true;
            }
            else
            {
                CA_DM.PWHT = false;
            }

            // Select "true" to caculate
            CA_DM.ENVIRONMENT_H2S_CONTENT = true;
            CA_DM.CARBON_ALLOY = true;

            // Time
            lbTime1.Text = lbTime4.Text = "0 months";
            int _period = txtPeriod.Text != "" ? int.Parse(txtPeriod.Text) : 36;
            lbTime2.Text = lbTime5.Text = _period + " months";
            lbTime3.Text = lbTime6.Text = _period * 2 + " months";
            //lbTime4.Text = "0 months";
            //lbTime5.Text = txtPeridod.Text + " months";
            //lbTime6.Text = int.Parse(txtPeridod.Text) * 2 + " months";

            // Result
            txtSusceptibility.Text = CA_DM.GET_SUSCEPTIBILITY_SULPHIDE();
            txtSVI.Text = (CA_DM.SVI_SULPHIDE()).ToString();
            float age = 7;
            float i = _period / 12;
            txtYear1.Text = age.ToString();
            txtYear2.Text = (age + i).ToString();
            txtYear3.Text = (age + 2 * i).ToString();
            txtBase1.Text = CA_DM.DF_SULPHIDE(age).ToString();
            txtBase2.Text = CA_DM.DF_SULPHIDE(age + i).ToString();
            txtBase3.Text = CA_DM.DF_SULPHIDE(age + 2 * i).ToString();

            txtTotal1.Text = CA_DM.DF_SULPHIDE(age).ToString();
            txtTotal2.Text = CA_DM.DF_SULPHIDE(age + i).ToString();
            txtTotal3.Text = CA_DM.DF_SULPHIDE(age + 2 * i).ToString();
           
        }

       
    }
}
