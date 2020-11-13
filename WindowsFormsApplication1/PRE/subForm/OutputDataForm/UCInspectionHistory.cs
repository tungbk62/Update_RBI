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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using RBI.PRE.subForm.InputDataForm;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCInspectionHistory : UserControl
    {
        public UCInspectionHistory(int PlanID)
        {
            InitializeComponent();
            initData(PlanID);
            Showtab(PlanID);
        }
        int IDPlan = 0;
        private List<RW_INSPECTION_DETAIL> getDataInspectionHistory()
        {
            RW_INSPECTION_HISTORY_BUS busInspHis = new RW_INSPECTION_HISTORY_BUS();
            List<RW_INSPECTION_DETAIL> listInspHis = busInspHis.getDataSource();
            List<RW_INSPECTION_DETAIL> listData = new List<RW_INSPECTION_DETAIL>();
            EQUIPMENT_MASTER_BUS busEqMaster = new EQUIPMENT_MASTER_BUS();
            SITES_BUS busSite = new SITES_BUS();
            FACILITY_BUS busFacility = new FACILITY_BUS();
            foreach (RW_INSPECTION_DETAIL inspHis in listInspHis)
            {
          
                int eqID = inspHis.EquipmentID;
                RW_INSPECTION_DETAIL rwInspHis = inspHis;
                rwInspHis.SiteName = busSite.getSiteName(busEqMaster.getSiteID(eqID));
                rwInspHis.FacilityName = busFacility.getFacilityName(busEqMaster.getFacilityID(eqID));
                listData.Add(rwInspHis);
            }
            return listData;
        }

        private List<INSPECTION_COVERAGE> getDataPlanCoverage(int PlanID)
        {
            INSPECTION_COVERAGE_BUS busInspcove = new INSPECTION_COVERAGE_BUS();
            List<INSPECTION_COVERAGE> listInscove = busInspcove.getDataID(PlanID);
            List<INSPECTION_COVERAGE> listData = new List<INSPECTION_COVERAGE>();
            EQUIPMENT_MASTER_BUS buseq = new EQUIPMENT_MASTER_BUS();
            COMPONENT_MASTER_BUS buscom = new COMPONENT_MASTER_BUS();
            INSPECTION_PLAN_BUS businsplan = new INSPECTION_PLAN_BUS();  
            foreach (INSPECTION_COVERAGE inspCove in listInscove)
            {
                INSPECTION_COVERAGE rwInspCove = inspCove;
                rwInspCove.EquipmentName = buseq.getEquipmentNumber(inspCove.EquipmentID);
                rwInspCove.ComponentName = buscom.getComponentNumber(inspCove.ComponentID);
                rwInspCove.InspectionPlanName = businsplan.getPlanName(inspCove.PlanID);
                rwInspCove.InspectionPlanDate = businsplan.getPlanDate(inspCove.PlanID).ToString();
                listData.Add(rwInspCove);    
            }
            return listData;
        }

        public void initData(int PlanID)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));

            string[] header = { "Inspection Plan ID", "Inspection Plan Date", "Equipment", "Component", "Remarks", "Findings"};
            try
            {
                gridControl1.DataSource = getDataPlanCoverage(PlanID);
                gridView1.Columns.Remove(gridView1.Columns["ID"]);
                gridView1.Columns.Remove(gridView1.Columns["PlanID"]);
                gridView1.Columns.Remove(gridView1.Columns["EquipmentID"]);
                gridView1.Columns.Remove(gridView1.Columns["ComponentID"]);
                gridView1.Columns.Remove(gridView1.Columns["FindingRTF"]);
            }
            catch
            {
                // do nothing
            }
            SplashScreenManager.CloseForm();
            
        }
        public void Showtab(int PlanID)
        {
            try
            {
                INSPECTION_PLAN_BUS businsplan = new INSPECTION_PLAN_BUS();              
                InspectionPlanName.Text = businsplan.getPlanName(PlanID);
                InspectionDate.Text = businsplan.getPlanDate(PlanID).ToString();
                IDPlan = PlanID;
            }
            catch
            {
                // do nothing
            }
        }       
        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateInspectionPlan create = new frmCreateInspectionPlan();
            create.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {           
            frmSearchInspectionPlan search = new frmSearchInspectionPlan();            
            search.ShowDialog();                                 
            initData(search.ButtonSelectClicked);
            Showtab(search.ButtonSelectClicked);
            
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (IDPlan == 0)
            {
                MessageBox.Show("Please create/ select an inspection plan before adding inspection coverage", "Inspection / Mitigation Planner", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            else
            {
                frmInspectionPlanDetail detail = new frmInspectionPlanDetail(IDPlan);
                detail.ShowDialog();
            }
            
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            initData(0);
        }
    }
}
