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
    public partial class UCInternalLiningDegradation : UserControl
    {
        public UCInternalLiningDegradation()
        {
            InitializeComponent();
            float period = float.Parse(txtPeriod.Text == "" ? "0" : txtPeriod.Text);
            period /= 12;
            lb1.Text = 0 + " months";
            lb2.Text = period + " months";
            lb3.Text = period * 2 + " months";
        }
        public UCInternalLiningDegradation(int ID)
        {
            InitializeComponent();
            initinput(ID);
            //Calculate();
        }
        private void initinput(int ID)
        {
            int IDProposal = ID;
            RW_ASSESSMENT rW_ASSESSMENT = new RW_ASSESSMENT();
            EQUIPMENT_MASTER_BUS equipmentMasterBus = new EQUIPMENT_MASTER_BUS();
            RW_COATING_BUS coatBus = new RW_COATING_BUS();
            RW_EQUIPMENT_BUS eqBus = new RW_EQUIPMENT_BUS();
            RW_COATING coat = new RW_COATING();
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
            RW_INSPECTION_HISTORY_BUS busInspectionHistory = new RW_INSPECTION_HISTORY_BUS();
            //TimeSpan year = busAssessment.getAssessmentDate(IDProposal) - busInspectionHistory.getLastInsp(componentID, DM_ID[1], busEquipmentMaster.getComissionDate(equipmentID));
            //equipmentMasterBus.getComissionDate(equipmentID)
            int temp = 6;
            txtAssDate.Text = Convert.ToString(busAssessment.getAssessmentDate(IDProposal));
            txtPeriod.Text = Convert.ToString(rW_ASSESSMENT.RiskAnalysisPeriod);
            txtComDate.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            txtLastDate.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            txtLinearCon.Text = Convert.ToString(coat.InternalLinerCondition);
            txtLinearType.Text = Convert.ToString(coat.InternalLinerType);
            if (coat.InternalLining == 1)
                txtOnlineMonitor.Text = "True";
            else txtOnlineMonitor.Text = "False";
        }
        public void Calculate()
        {
            MessageBox.Show("đang gọi đến điểm test");
            //cal.YEAR_IN_SERVICE = (int)Math.Ceiling((decimal)year.Days / 365); 
            //cal.LINNER_CONDITION = 
            //cal.INTERNAL_LINNING =

            //MessageBox.Show("đang gọi đến điểm test");
            //MSSQL_DM_CAL_Lining CA_DM = new MSSQL_DM_CAL_Lining();
            //CA_DM.LinningType = txtLinearType.Text;
            //CA_DM.LINNER_ONLINE = Convert.ToBoolean(txtOnlineMonitor.Text == "True" ? 1: 0);
            //CA_DM.LINNER_CONDITION = txtLinearCon.Text;
            //CA_DM.INTERNAL_LINNING = true;

            //TimeSpan yearService = Convert.ToDateTime(txtAssDate.Text) - Convert.ToDateTime(txtLastDate.Text);
            //CA_DM.YEAR_IN_SERVICE =(int) (Math.Ceiling (yearService.TotalDays / 365.25)); //Yearinservice hiệu tham số giữa lần tính toán và ngày cài đặt hệ thống

            //TimeSpan age = Convert.ToDateTime(txtAssDate.Text) - Convert.ToDateTime(txtComDate.Text);
            //CA_DM.YEAR_IN_SERVICE = (int)(Math.Ceiling(age.TotalDays / 365.25)); //age dự đoán

            //int temp = 9;
            //txtFLC.Text = Convert.ToString(!float.IsNaN(CA_DM.FLC()) && CA_DM.FLC() > 0 ? CA_DM.FLC() : 0);
            //txtFLC.Text = Convert.ToString(!float.IsNaN(CA_DM.FOM()) && CA_DM.FOM() > 0 ? CA_DM.FOM() : 0);
            //double period = Convert.ToDouble(txtPeriod.Text);
            //period = 42;
            //period /= 12;
            //lb1.Text = 0 + " months";
            //lb2.Text = period + " months";
            //lb3.Text = period * 2  + " months";
            //txtAssDate.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtPeriod.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtComDate.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtLastDate.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtLinearCon.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtLinearType.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
            //txtOnlineMonitor.Text = Convert.ToString(!float.IsNaN(temp) && temp > 0 ? temp : 0);
        }

        private void UCInternalLiningDegradation_Load(object sender, EventArgs e)
        {

        }
    }
}
