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
    public partial class UCCarbonateCracking : UserControl
    {
        public UCCarbonateCracking()
        {
            InitializeComponent();
        }
        public UCCarbonateCracking(int ID)
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
            
            int equipmentID = busAssessment.getEquipmentID(ID);
            
            

            txtAssDate.Text = Convert.ToString(busAssessment.getAssessmentDate(ID).ToShortDateString());
            txtInspecDate.Text = busEquipmentMaster.getComissionDate(equipmentID).ToShortDateString(); //test theo riskwwise
            txtComDate.Text = busEquipmentMaster.getComissionDate(equipmentID).ToShortDateString();
            eq = eqBus.getData(equipmentID);
            txtCO3.Text = stream.CO3Concentration.ToString();
            txtPH.Text = stream.WaterpH.ToString();
            txtPeridod.Text = Convert.ToString(ass.RiskAnalysisPeriod);
            txtNumInspection.Text = "0"; //test
            txtHighEffective.Text = "E";
            txtCrack.Text = Convert.ToString(false);
            txtPHWT.Text = eq.PWHT != 1 ? "False" : "True"; ;
        }
        public float[] YearsFromCommisionDate(DateTime AssessmentDate, DateTime CommissionDate, int Period)
        {
            DateTime time = AssessmentDate;
            DateTime time2 = CommissionDate;
            int num = Period;
            float[] age = new float[3];
            TimeSpan span = (TimeSpan)(time - time2);
            age[0] = Convert.ToSingle((((span.TotalDays / 365.25) + (0.0 / 12.0)) < 0.0) ? 0.0 : (((span = (TimeSpan)(time - time2)).TotalDays / 365.25) + (0.0 / 12.0)));
            span = (TimeSpan)(time - time2);
            age[1] =Convert.ToSingle((((span.TotalDays / 365.25) + (((float)num) / 12.0)) < 0.0) ? 0.0 : (((span = (TimeSpan)(time - time2)).TotalDays / 365.25) + (((float)num) / 12.0)));
            span = (TimeSpan)(time - time2);
            age[2] = Convert.ToSingle((((span.TotalDays / 365.25) + (((double)(2 * num)) / 12.0)) < 0.0) ? 0.0 : (((span = (TimeSpan)(time - time2)).TotalDays / 365.25) + (((double)(2 * num)) / 12.0)));
            return age;
        }
        public void Calculate()
        {
            //Input
            CAL_DM_CARBONATE_CRACKING CA_DM = new CAL_DM_CARBONATE_CRACKING();
            //CA_DM.CACBONATE_INSP_NUM = txtNumInspection.Text != "" ? int.Parse(txtNumInspection.Text) : 0;
            int cacbonate_insp_num = txtNumInspection.Text != "" ? int.Parse(txtNumInspection.Text) : 0;
            //CA_DM.CACBONATE_INSP_EFF = txtHighEffective.Text;
            string cacbonate_insp_eff = txtHighEffective.Text;
            //CA_DM.CO3_CONCENTRATION = txtCO3.Text != "" ? int.Parse(txtCO3.Text) : 0;
            int co3Concentration = txtCO3.Text != "" ? int.Parse(txtCO3.Text) : 0;
            //CA_DM.PH = txtPH.Text != "" ?  float.Parse(txtPH.Text) : 0;
            float ph = txtPH.Text != "" ? float.Parse(txtPH.Text) : 0;
            
            bool crack;
            if (txtCrack.Text.ToLower() == "true")
            {
                //CA_DM.CRACK_PRESENT = true;
                crack = true;
            }
            else
            {
                //CA_DM.CRACK_PRESENT = false;
                crack = false;
            }
            bool phwt;
            if (txtPHWT.Text.ToLower() == "true")
            {
                //CA_DM.PWHT = true;
                phwt = true;
            }
            else
            {
                //CA_DM.PWHT = false;
                phwt = false;
            }

            // Select "true" to caculate
            //CA_DM.EXPOSED_SULFUR = true;
            //CA_DM.CARBON_ALLOY = true;
            
            // Result

            lbTime1.Text = lbTime4.Text = "0 months";
            int _period = txtPeridod.Text != "" ? int.Parse(txtPeridod.Text) : 36;
            lbTime2.Text = lbTime5.Text = _period + " months";
            lbTime3.Text = lbTime6.Text = _period * 2 + " months";

            DateTime CommissionDate = DateTime.Parse(txtComDate.Text);
            DateTime AssessmentDate = DateTime.Parse(txtAssDate.Text);
            
            float[] age = YearsFromCommisionDate(AssessmentDate, CommissionDate, _period);
            txtSinceLastInspec1.Text = age[0].ToString();
            txtSinceLastInspec2.Text = age[1].ToString();
            txtSinceLastInspec3.Text = age[2].ToString();

            var result = CA_DM.Calculate(age, crack, phwt, co3Concentration, ph, true, true, cacbonate_insp_eff, cacbonate_insp_num);

            txtSusceptibility.Text = result.Item1.ToString();
            txtSVI.Text = result.Item2.ToString();

            txtBaseValue1.Text = result.Item4.ToString();
            txtBaseValue2.Text = result.Item4.ToString();
            txtBaseValue3.Text = result.Item4.ToString();

            txtTotal1.Text = result.Item5[0].ToString();
            txtTotal2.Text = result.Item5[1].ToString();
            txtTotal3.Text = result.Item5[2].ToString();
            
        }
    }
}
