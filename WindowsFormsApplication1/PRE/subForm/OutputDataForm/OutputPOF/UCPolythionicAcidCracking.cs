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
    public partial class UCPolythionicAcidCracking : UserControl
    {
        public UCPolythionicAcidCracking()
        {
            InitializeComponent();
        }
        public UCPolythionicAcidCracking(int ID)
        {
            InitializeComponent();
            initinput(ID);
            //Calculate();
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
            RW_COMPONENT_BUS comBus = new RW_COMPONENT_BUS();
            RW_COMPONENT component = comBus.getData(ID);
            RW_MATERIAL_BUS MaterialBus = new RW_MATERIAL_BUS();
            RW_MATERIAL material = MaterialBus.getData(ID);
            RW_INSPECTION_DETAIL detail = new RW_INSPECTION_DETAIL();

            int equipmentID = busAssessment.getEquipmentID(ID);



            txtAssDate.Text = Convert.ToString(busAssessment.getAssessmentDate(ID).ToShortDateString());
            txtLastInspection.Text = busEquipmentMaster.getComissionDate(equipmentID).ToShortDateString(); //test theo riskwwise
            txtCommissionDate.Text = busEquipmentMaster.getComissionDate(equipmentID).ToShortDateString();
            eq = eqBus.getData(equipmentID);
            txtPeridod.Text = Convert.ToString(ass.RiskAnalysisPeriod);
            txtHighestInspection.Text = "E";
            txtNumberInspection.Text = "E";
            txtMaxOperating.Text = Convert.ToString(stream.MaxOperatingTemperature);
            txtCrack.Text = Convert.ToString(component.CracksPresent);
            txtPresenceSulphidesOperating.Text = Convert.ToString(eq.PresenceSulphidesO2);
            txtPresenceSulphidesShutdown.Text = Convert.ToString(eq.PresenceSulphidesO2Shutdown);
            txtDowntime.Text = Convert.ToString(eq.DowntimeProtectionUsed);
            txtThermalHistory.Text = eq.ThermalHistory;
            txtPresenceCyan.Text = "E";
            txtPTA.Text = material.PTAMaterialCode;
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
            age[1] = Convert.ToSingle((((span.TotalDays / 365.25) + (((float)num) / 12.0)) < 0.0) ? 0.0 : (((span = (TimeSpan)(time - time2)).TotalDays / 365.25) + (((float)num) / 12.0)));
            span = (TimeSpan)(time - time2);
            age[2] = Convert.ToSingle((((span.TotalDays / 365.25) + (((double)(2 * num)) / 12.0)) < 0.0) ? 0.0 : (((span = (TimeSpan)(time - time2)).TotalDays / 365.25) + (((double)(2 * num)) / 12.0)));
            return age;
        }
    }
}