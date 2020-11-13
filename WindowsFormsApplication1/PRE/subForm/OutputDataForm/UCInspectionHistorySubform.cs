using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
using RBI.PRE.subForm.InputDataForm;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCInspectionHistorySubform : UserControl
    {
        //RW_INSPECTION_HISTORY_BUS inspectionHistoryBus = new RW_INSPECTION_HISTORY_BUS();
        //RW_ASSESSMENT_BUS assessmentBus = new RW_ASSESSMENT_BUS();
        //COMPONENT_MASTER_BUS comMasterBus = new COMPONENT_MASTER_BUS();
        public int IDAss { set; get; }
        public UCInspectionHistorySubform()
        {
            InitializeComponent();
        }
        public UCInspectionHistorySubform(int ID)
        {
            InitializeComponent();
           // setupGridControl(ID);
            this.Dock = DockStyle.Fill;
            IDAss = ID;
        }
        private void setupGridControl(int ID)
        {
            //string[] title = { "Inspection Plan Name", "Inspection Coverage Name",  "Equipment Number", "Component Number" , "Damage Mechanisms", "Inspection Type", "Inspection Date", "Inspection Effectiveness"};
            //string[] Header = { "InspectionPlanName", "InspectionCoverageName", "EquipmentNumber", "ComponentNumber", "DamageMechanisms", "InspectionType", "InspectionDate", "InspectionEffectiveness" };
            //int[] ComID = assessmentBus.getEquipmentID_ComponentID(ID);
            //List<RW_INSPECTION_DETAIL> list = inspectionHistoryBus.getDataComp(ComID[1]);
            //if(list.Count > 0)
            //{
            //    gridControl1.DataSource = list;
            //    gridView1.Columns.Remove(gridView1.Columns["ID"]);
            //    gridView1.Columns.Remove(gridView1.Columns["SiteName"]);
            //    gridView1.Columns.Remove(gridView1.Columns["FacilityName"]);
            //    for (int i = 0; i < title.Length; i++)
            //    {
            //        gridView1.Columns[i].Caption = title[i];
            //    }
            //    gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            //    gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            //    gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //    gridView1.BestFitColumns();
            //}
            //else
            //{
               
            //}
           

        }

        private void UCInspectionHistorySubform_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dtvcInsPlan = new DataGridViewTextBoxColumn();
            dtvcInsPlan.HeaderText = "Inspection Plan";
            DataGridViewTextBoxColumn dtvcInsDate = new DataGridViewTextBoxColumn();
            dtvcInsDate.HeaderText = "Inspection Date";
            DataGridViewComboBoxColumn dtvcDamaMechan = new DataGridViewComboBoxColumn();
            dtvcDamaMechan.HeaderText = "Damage Mechanism";
            //add items cho dtvcDamaMechan
            DM_ITEMS_BUS dmItemsBus = new DM_ITEMS_BUS();
            List<string> listDMItems = dmItemsBus.getDMDescription();
            foreach(String dm in listDMItems)
            {
                dtvcDamaMechan.Items.Add(dm);
            }
            dtvcDamaMechan.MaxDropDownItems = 4;
            DataGridViewTextBoxColumn dtvcInsSum = new DataGridViewTextBoxColumn();
            dtvcInsSum.HeaderText = "Inspection Summary";
            DataGridViewButtonColumn dtvcSumDetail = new DataGridViewButtonColumn();
            dtvcSumDetail.HeaderText = "Summary Detail";
            dtvcSumDetail.Name = "dtvcSumDetail";
            DataGridViewComboBoxColumn dtvcEffective = new DataGridViewComboBoxColumn();
            dtvcEffective.Items.Add("A");
            dtvcEffective.Items.Add("B");
            dtvcEffective.Items.Add("C");
            dtvcEffective.Items.Add("D");
            dtvcEffective.Items.Add("E");
            dtvcEffective.HeaderText = "Effectiveness";
            DataGridViewCheckBoxColumn dtvcCarriedOut = new DataGridViewCheckBoxColumn();
            dtvcCarriedOut.HeaderText = "Carried Out";
            DataGridViewTextBoxColumn dtvcICarriedOutDate = new DataGridViewTextBoxColumn();
            dtvcICarriedOutDate.HeaderText = "Carried Out Date";
            DataGridViewButtonColumn dtvcDelete = new DataGridViewButtonColumn();
            dtvcDelete.HeaderText = "";
            dtvcDelete.Name = "dtvcDelete";
            dtgvInsHis.Columns.Add(dtvcInsPlan);
            dtvcInsPlan.Width = 100;
            dtgvInsHis.Columns.Add(dtvcInsDate);
            dtvcInsDate.Width = 80;
            dtgvInsHis.Columns.Add(dtvcDamaMechan);
            dtvcDamaMechan.Width = 150;
            dtgvInsHis.Columns.Add(dtvcInsSum);
            dtvcInsSum.Width = 200;
            dtgvInsHis.Columns.Add(dtvcSumDetail);
            dtvcSumDetail.Width = 50;
            dtgvInsHis.Columns.Add(dtvcEffective);
            dtvcEffective.Width = 70;
            dtgvInsHis.Columns.Add(dtvcCarriedOut);
            dtvcCarriedOut.Width = 60;
            dtgvInsHis.Columns.Add(dtvcICarriedOutDate);
            dtvcICarriedOutDate.Width = 80;
            dtgvInsHis.Columns.Add(dtvcDelete);
            dtvcDelete.Width = 50;
            RW_INSPECTION_HISTORY_BUS rwInspHisBus = new RW_INSPECTION_HISTORY_BUS();
            List<RW_INSPECTION_DETAIL> lstRwInsDe= rwInspHisBus.getDataSourcebyID(IDAss);
            foreach(RW_INSPECTION_DETAIL de in lstRwInsDe)
            {
                dtgvInsHis.Rows.Add(de.InspPlanName, de.InspectionDate.ToShortDateString(), dmItemsBus.getDMDescriptionbyDMItemID(de.DMItemID), de.InspectionSummary, "...", de.EffectivenessCode, de.IsCarriedOut, de.CarriedOutDate, "✖");
            }
            dtgvInsHis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgvInsHis.AllowUserToAddRows = false;
        }
        private void btnRestoreInspectionPlan_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            dtgvInsHis.Rows.Clear();
           
           RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            INSPECTION_COVERAGE_BUS insCovBus = new INSPECTION_COVERAGE_BUS();
            INSPECTION_PLAN_BUS inPlanBus = new INSPECTION_PLAN_BUS();
            INSPECTION_COVERAGE_DETAIL_BUS insCovDeBus = new INSPECTION_COVERAGE_DETAIL_BUS();
            DM_ITEMS_BUS dmItemsBus = new DM_ITEMS_BUS();
        List <int> listIDCoverage=insCovBus.getlistIDbyEquipmentIDandComponentID(rwAssBus.getEquipmentID(IDAss), rwAssBus.getComponentID(IDAss));
            foreach(int i in listIDCoverage)
            {
                List<int> listIDDetal = insCovDeBus.getIDbyCoverageID(i);
                foreach (int j in listIDDetal)
                {
                    INSPECTION_COVERAGE_DETAIL insCovDe = insCovDeBus.getDataSourcebyID(j);
                    dtgvInsHis.Rows.Add(inPlanBus.getPlanName(insCovBus.getPlanIDbyID(i)), insCovDe.InspectionDate.ToShortDateString(), dmItemsBus.getDMDescriptionbyDMItemID(insCovDe.DMItemID), insCovDe.InspectionSummary,"...", insCovDe.EffectivenessCode, insCovDe.IsCarriedOut, insCovDe.CarriedOutDate.ToShortDateString(), "✖");
                }
            }
            int n = dtgvInsHis.RowCount;
            for (int i = 0; i < n; i++)
            {
                dtgvInsHis.Rows[i].ReadOnly = true;
                dtgvInsHis.Rows[i].Cells[6].ReadOnly = false;
                dtgvInsHis.Rows[i].Cells[5].ReadOnly = false;
                dtgvInsHis.Rows[i].Cells[8].ReadOnly = false;
                dtgvInsHis.Rows[i].Cells[3].ReadOnly = false;
            }
            SplashScreenManager.CloseForm();

        }
        public void saveData(int ID)
        {
           
            RW_INSPECTION_DETAIL InsHis = null;
            RW_INSPECTION_HISTORY_BUS InsHisBus = new RW_INSPECTION_HISTORY_BUS();
            EQUIPMENT_MASTER_BUS eqMasBus = new EQUIPMENT_MASTER_BUS();
            RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            DM_ITEMS_BUS dmItemsBus = new DM_ITEMS_BUS();
            InsHisBus.delete(ID);
            for (int i = 0; i < dtgvInsHis.RowCount; i++)
            {
                InsHis = new RW_INSPECTION_DETAIL();
                InsHis.ID = ID;
                InsHis.InspPlanName = dtgvInsHis.Rows[i].Cells[0].Value.ToString();
                InsHis.EquipmentID = rwAssBus.getEquipmentID(ID);
                InsHis.ComponentID = rwAssBus.getComponentID(ID);
                InsHis.DMItemID= dmItemsBus.getDMIteamIDbyDMDescription(dtgvInsHis.Rows[i].Cells[2].Value.ToString());
                InsHis.InspectionDate = Convert.ToDateTime(dtgvInsHis.Rows[i].Cells[1].Value.ToString());
                InsHis.InspectionSummary = dtgvInsHis.Rows[i].Cells[3].Value.ToString();
                InsHis.EffectivenessCode= dtgvInsHis.Rows[i].Cells[5].Value.ToString();
                InsHis.IsCarriedOut = (int)dtgvInsHis.Rows[i].Cells[6].Value;
                InsHis.CarriedOutDate= Convert.ToDateTime(dtgvInsHis.Rows[i].Cells[7].Value.ToString());
                InsHis.IsActive = 1;
                InsHisBus.add(InsHis);
            }
            
        }

        private void btnAddInspectionPlan_Click(object sender, EventArgs e)
        {
            RW_INSPECTION_HISTORY_BUS rwInsHisBus = new RW_INSPECTION_HISTORY_BUS();
            RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            int n = rwInsHisBus.getDataComp(rwAssBus.getComponentID(IDAss)).Count;
            if(n>0)
            {
                dtgvInsHis.Rows.Add("-", DateTime.Now.ToShortDateString(), "Corrosion Under Insulation", "", "", "E", 0, DateTime.Now.ToShortDateString(), "✖");
            }
            else
            {
                if(dtgvInsHis.RowCount>0)
                {
                    dtgvInsHis.Rows.Add("-", DateTime.Now.ToShortDateString(), "Corrosion Under Insulation", "", "", "E", 0, DateTime.Now.ToShortDateString(), "✖");
                }
                else
                {
                    MessageBox.Show("This proposal does not have mitigation plan, please add mitigation planning.", "Inspection / Mitigation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
        }

        private void dtgvInsHis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.Columns[e.ColumnIndex].Name=="dtvcSumDetail" &&
                e.RowIndex >= 0)
            {
                frmInspectionSummary f = new frmInspectionSummary();
                f.ShowDialog();
                //senderGrid.Columns[e.ColumnIndex].
                senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value = f.result;
            }
            else
            {
                if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.Columns[e.ColumnIndex].Name == "dtvcDelete" &&
                e.RowIndex >= 0)
                {
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void UCInspectionHistorySubform_ContextMenuStripChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("su kien");
        }
    }
}
