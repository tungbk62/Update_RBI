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
    public partial class UCBrittleFracture : UserControl
    {
        public UCBrittleFracture()
        {
            InitializeComponent();
        }
        public UCBrittleFracture(int ID)
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

            int equipmentID = busAssessment.getEquipmentID(ID);


            txtNorminalThickness.Text = Convert.ToString(component.NominalThickness);
            txtPreConAd.Text = Convert.ToString(eq.PressurisationControlled);
            txtCriticalExTem.Text = Convert.ToString(stream.CriticalExposureTemperature);
            txtReferenceTem.Text = Convert.ToString(material.ReferenceTemperature);
            txtMinRequiredTem.Text = Convert.ToString(eq.MinReqTemperaturePressurisation);
            txtTheComponent.Text = "E";
            txtNomialOperating.Text = Convert.ToString(component.NominalOperatingConditions);
            txtEquipmentSatisfied.Text = Convert.ToString(component.EquipmentSatisfied);
            txtPWHT.Text = Convert.ToString(eq.PWHT);
            txtBrittleFracture.Text = Convert.ToString(component.BrittleFractureThickness);
            txtMinDesignMetal.Text = "E";
            txtPreConAd1.Text = Convert.ToString(eq.PressurisationControlled);
            txtYieldStrength.Text = Convert.ToString(material.YieldStrength);
            txtCET.Text = Convert.ToString(component.CETGreaterOrEqual);
            txtNominalUncorroded.Text = Convert.ToString(component.NominalThickness);
            txtCyclicService.Text = Convert.ToString(component.CyclicServiceFatigueVibration);
            txtEquipmentCircuit.Text = "E";
            txtEquipmentCircuitAPI.Text = Convert.ToString(component.EquipmentCircuitShock);
            textEdit1.Text = "E";
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
